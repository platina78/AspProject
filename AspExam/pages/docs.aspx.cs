using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AspExam_pages_docs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Page.Session["[alla]"] == null)
            {
                Response.Write("<script>alert('잘못된 접근입니다');</script>");
                Response.StatusCode = 404;
                Response.End();
            }
            else
            {
                BindDocTitle();
                SetInfo();
            }
            
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetInfo();
    }


    protected void docs_save_Click(object sender, EventArgs e)
    {
        //if (CheckDocTitle(docs_title.Text))
        //{
        //    InsertBlock(hiddenData.Value);
        //}
        //else
        //{
        //    UpdateBlock(hiddenData.Value);
        //}
        UpdateBlock(hiddenData.Value);
        SetInfo();
    }

    protected void docs_add_Click(object sender, EventArgs e)
    {
        InsertBlock(hiddenData.Value);

            
        SetInfo();
        docs_title.Text = "";
    }

    protected void docs_delete_Click(object sender, EventArgs e)
    {
        DeleteDocs(Page.Session["[alla]"].ToString());
        SetInfo();
    }

    void BindDocTitle()
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=TodoDB;" +
            "Integrated Security=False; uid=host; pwd=asp2020;");
        con.Open();
        String query = "select title from docs where userno=@userno";
        SqlCommand com = new SqlCommand(query, con);
        
        com.Parameters.AddWithValue("@userno", Page.Session["[alla]"].ToString());
        SqlDataReader rd = com.ExecuteReader();
        DropDownList1.DataSource = rd;
        DropDownList1.DataValueField = "title";
        DropDownList1.DataTextField = "title";
        DropDownList1.DataBind();

        rd.Close();
        con.Close();
    }
    bool CheckDocTitle(string data) //오류나게 되면 다시 한번 보기
    {
        bool checkData;
        if (data.Equals(""))
        {
            checkData = false;
        }
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=TodoDB;" +
             "Integrated Security=False; uid=host; pwd=asp2020;");
        con.Open();
        String query = "select title from docs where userno=@userno and title=@title";
        SqlCommand com = new SqlCommand(query, con);
        com.Parameters.AddWithValue("@userno", Page.Session["[alla]"].ToString());
        com.Parameters.AddWithValue("@title", data);
        SqlDataReader rd = com.ExecuteReader();
        if (rd.Read()) //select한 데이터가 있다면
        {
            checkData = false;
            Response.Write("<script>alert('" + data + "');</script>");
        }
        else
        {
            checkData = true;
            Response.Write("<script>alert('" + data + "');</script>");
        }
        
        

        rd.Close();
        con.Close();

        return checkData;
    }
    public void InsertBlock(string data)
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=TodoDB;" +
            "Integrated Security=False; uid=host; pwd=asp2020");


        String query = "Insert into Docs(title,blocks,userno) values(@title,@blocks,@userno)";
        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@title", docs_title.Text);
        cmd.Parameters.AddWithValue("@blocks", data);
        cmd.Parameters.AddWithValue("@userno", Page.Session["[alla]"].ToString());
        if (docs_title.Text.Equals(""))
        {
            Response.Write("<script>alert('제목을 입력해주세요!');</script>");

        }
        else
        {
            con.Open();
            int count = cmd.ExecuteNonQuery();
            con.Close();
        }
        

        BindDocTitle();//추가가 되면 리렌더링
    }
    public void UpdateBlock(string data)
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=TodoDB;" +
            "Integrated Security=False; uid=host; pwd=asp2020");

        String query = "Update Docs set blocks=@blocks,updatedDate=@updatedDate where userNo=@userNo and title=@title";
        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@blocks", data);
        cmd.Parameters.AddWithValue("@updatedDate", DateTime.Now.ToString("s"));
        cmd.Parameters.AddWithValue("@userNo", Page.Session["[alla]"].ToString());
        cmd.Parameters.AddWithValue("@title", DropDownList1.SelectedValue);

        con.Open();
        int count = cmd.ExecuteNonQuery();
        con.Close();

        //BindDocTitle(); 
    }

    void SetInfo()
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=TodoDB;" +
            "Integrated Security=False; uid=host; pwd=asp2020;");
        con.Open();

        string query = "Select createdDate,updatedDate,blocks From docs where userno=@userNo and title=@title";

        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@userNO", Page.Session["[alla]"].ToString());
        cmd.Parameters.AddWithValue("@title", DropDownList1.SelectedValue);
        SqlDataReader rd = cmd.ExecuteReader();

        String data = "";
        if (rd.Read())
        {
            data = "<script>" +
                "const testData='" + rd["blocks"].ToString() + "'; \n" +
            "const serverData=JSON.parse(testData);" +
                " </script>";
            //data = "<script>" +
            //    "const testData='" + rd["blocks"].ToString() + "'; \n" +
            //    "</script>";
        }
        else
        {
            data = "<script>const serverData=undefined</script>";
        }
        Response.Write(data);

        rd.Close();
        con.Close();

    }
    void DeleteDocs(string data)
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=TodoDB;" +
           "Integrated Security=False; uid=host; pwd=asp2020");
        String query = "Delete from docs where userno=@userno and title=@title";
        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@userno", data);
        cmd.Parameters.AddWithValue("@title", DropDownList1.SelectedValue);


        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        BindDocTitle();//삭제 후 리렌더링
    }






}