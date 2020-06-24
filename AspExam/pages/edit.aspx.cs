using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AspExam_pages_edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Page.Session["[alla]"] == null)
        {

            Response.Write("<script>alert('잘못된 접근입니다');</script>");
            Response.StatusCode = 404;
            Response.End();

        }
        else
        {
            selectUser();
        }
        
    }

    protected void edit_btn_Click(object sender, EventArgs e)
    {
        editUser();
        Response.Redirect("../main.aspx");

    }

    protected void delete_btn_Click(object sender, EventArgs e)
    {
        deleteUserAllTodo();
        deleteUserAllDocs();
        deleteUser();
        Response.Redirect("../pages/login.aspx");
    }

    void selectUser()
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=TodoDB;" +
            "Integrated Security=False; uid=host; pwd=asp2020;");
        con.Open();

        string query = "Select * From [User] where no=@userno";

        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@userno", Page.Session["[alla]"].ToString());
        SqlDataReader rd = cmd.ExecuteReader();

        if (rd.Read())
        {
            edit_id.Text = rd["id"].ToString();
            edit_email.Text = rd["email"].ToString();
        }

        rd.Close();
        con.Close();
    }

    void editUser()
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=TodoDB;" +
           "Integrated Security=False; uid=host; pwd=asp2020");

        String query = "Update [User] set password=@password,email=@email where no=@userNo";
        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@password", edit_pw.Text);
        cmd.Parameters.AddWithValue("@email", edit_email.Text);
        cmd.Parameters.AddWithValue("@userNo", Page.Session["[alla]"].ToString());

        con.Open();
        int count = cmd.ExecuteNonQuery();
        con.Close();
    }

    void deleteUser()
    {

        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=TodoDB;" +
           "Integrated Security=False; uid=host; pwd=asp2020");
        String query = "Delete from [User] where no=@userno";
        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@userno", Page.Session["[alla]"].ToString());

        con.Open();
        cmd.ExecuteNonQuery();

        con.Close();

    }

    void deleteUserAllTodo()
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=TodoDB;" +
           "Integrated Security=False; uid=host; pwd=asp2020");
        String query = "Delete from Todo where userno=@userno";
        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@userno", Page.Session["[alla]"].ToString());

        con.Open();
        cmd.ExecuteNonQuery();

        con.Close();
    }

    void deleteUserAllDocs()
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=TodoDB;" +
           "Integrated Security=False; uid=host; pwd=asp2020");
        String query = "Delete from Docs where userno=@userno";
        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@userno", Page.Session["[alla]"].ToString());
        
        con.Open();
        cmd.ExecuteNonQuery();

        con.Close();
    }

}