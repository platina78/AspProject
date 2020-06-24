using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data.SqlClient;
using System.Globalization;

public partial class AspExam_index : System.Web.UI.Page
{
    public String  dummyData;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
            if (Page.Session["[alla]"]==null)
            {
                
                Response.Write("<script>alert('잘못된 접근입니다');</script>");
                logOut.Visible = false;
                Response.StatusCode = 404;
                Response.End();

            }
            else
            {
                logOut.Visible = true;
                BindTodo();
            }
        }
        todo_section.Visible = true;
        programming_section.Visible = false;
        docs_section.Visible = false;

        this.compile_btn.Attributes.Add("Onclick", "return false");
        



    }

    /*메뉴 바*/
    protected void todo_Click(object sender, EventArgs e)
    {
        todo_section.Visible = true;
        programming_section.Visible = false;
        docs_section.Visible = false;
    }

    protected void programming_Click(object sender, EventArgs e)
    {
        todo_section.Visible = false;
        programming_section.Visible = true;
        docs_section.Visible = false;
    }

    protected void docs_Click(object sender, EventArgs e)
    {
        todo_section.Visible = false;
        programming_section.Visible = false;
        docs_section.Visible = true;
    }

    /*
     * 해야할 것
     * 추가 버튼을 누르게 되면 새로운 날짜를 받는다. creaeteDate와 updateDate에 new Date가 들어가고
     * default값으로 createdDate가 들어가고 저장 버튼을 누르게 되면 updateDate데이터와 바꿔진 blocks데이터가 들어가게 됨
     * where로 이름을 받아서
     * 
     이름을 입력하는 칸 옆에 추가 버튼을 누르면 docs파일이 만들어지고
       새로고침이 되면서 select박스에 만든 이름이 나온다.
         
         */

    protected void logOut_Click(object sender, EventArgs e)
    {
        Session.Remove("[alla]");
        Response.Redirect("./pages/login.aspx");
    }


    void BindTodo()
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=TodoDB;" +
            "Integrated Security=False; uid=host; pwd=asp2020");
        String query = "Select * from Todo where userno=@userno";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@userno", Page.Session["[alla]"].ToString());
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        GridView1.DataSource = rd;
        GridView1.DataBind();
        rd.Close();
        con.Close();
        

    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string oldcontents = Label1.Text;
        if (oldcontents.Equals(""))
        {
            Response.Write("<script>alert('바꾸실 todo를 선택해주세요!');</script>");
            e.Cancel = true;
        }
        else if (oldcontents != GridView1.Rows[e.NewEditIndex].Cells[0].Text)
        {
            //Response.Write("<script>alert('" + GridView1.Rows[e.NewEditIndex].Cells[0].Text + "')</script>");
            Response.Write("<script>alert('편집할 Todo를 선택해 주세요!');</script>");
            e.Cancel = true;
        }
        
        else
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindTodo();

        }
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string contents = e.NewValues["contents"].Equals(null) ? "":e.NewValues["contents"].ToString();
        string oldcontents = Label1.Text;
        if (oldcontents.Equals(""))
        {
            Response.Write("<script>alert('바꾸실 todo를 선택해주세요!');</script>");
        }
        UpdateTodo(Page.Session["[alla]"].ToString(), contents,oldcontents);
        GridView1.EditIndex = -1;
        BindTodo();
        Label1.Text = "";
    }

    void UpdateTodo(string userno, string contents,string oldcontents)
    {
        //Response.Write("<script>alert('" + oldcontents + "');</script>");
        //Response.Write("<script>alert('" + contents + "');</script>");
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=TodoDB;" +
            "Integrated Security=False; uid=host; pwd=asp2020");
            String query = "Update  Todo set contents=@contents where userno=@userno and contents like @oldcontents";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@contents", contents);
            cmd.Parameters.AddWithValue("@userno", userno);
            cmd.Parameters.AddWithValue("@oldcontents", oldcontents);

            cmd.ExecuteNonQuery();
            con.Close();
            

        BindTodo();
    }
    bool SelectTodo(string contents,string userno)
    {
        bool checkTodo;
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=TodoDB;" +
          "Integrated Security=False; uid=host; pwd=asp2020");
        String query = "Select contents from Todo where userno=@userno and contents=@contents";
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@userno", userno);
        cmd.Parameters.AddWithValue("@contents", contents);
        SqlDataReader rd = cmd.ExecuteReader();
        if (rd.Read())
        {
            checkTodo = true;
        }
        else
        {
            checkTodo = false;
        }

        rd.Close();
        con.Close();

        return checkTodo;

    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string content=GridView1.DataKeys[e.RowIndex].Value.ToString();
        //Response.Write("<script>alert('" + content + "')</script>");
        DeleteTodo(Page.Session["[alla]"].ToString(), content);
        BindTodo();
    }

    void DeleteTodo(string userno,string content )
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=TodoDB;" +
           "Integrated Security=False; uid=host; pwd=asp2020");
        String query = "Delete from Todo where userno=@userno and contents=@content";
        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@userno", userno);
        cmd.Parameters.AddWithValue("@content", content);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    void InsertTodo(string content)
    {
        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=TodoDB;" +
             "Integrated Security=False; uid=host; pwd=asp2020;");
        conn.Open();

        string query = "Insert into todo(contents,userno) values(@contents,@userno)";

        SqlCommand cmd = new SqlCommand(query, conn);

        cmd.Parameters.AddWithValue("@contents", content);
        cmd.Parameters.AddWithValue("@userno", Page.Session["[alla]"].ToString());
        cmd.ExecuteNonQuery();
        conn.Close();

        todo_add_title.Text = "";
        BindTodo();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindTodo();
    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        
        Label1.Text = GridView1.DataKeys[e.NewSelectedIndex].Value.ToString();
    }



    protected void todo_add_btn_Click(object sender, EventArgs e)
    {
        if (todo_add_title.Text.Equals(""))
        {
            Response.Write("<script>alert('todo를 입력해주세요!');</script>");
        }
        else
        {
            if (SelectTodo(todo_add_title.Text, Page.Session["[alla]"].ToString()))
            {
                Response.Write("<script>alert('존재하는 todo입니다!');</script>");
            }
            else
            {
                InsertTodo(todo_add_title.Text);
            }
            
        }
    }

    public string selectUserName()
    {
        string name="";
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=TodoDB;" +
          "Integrated Security=False; uid=host; pwd=asp2020");
        String query = "Select id from [User] where no=@userno";
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@userno", Page.Session["[alla]"].ToString());
        SqlDataReader rd = cmd.ExecuteReader();

        if (rd.Read())
        {
            name = rd["id"].ToString();
        }

        return name;
    }


}