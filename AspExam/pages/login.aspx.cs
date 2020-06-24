using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AspExam_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        
    }



    protected void login_btn_Click(object sender, EventArgs e)
    {
        if(SelectUser(login_id.Text, login_pw.Text))
        {
            Response.Redirect("../main.aspx");
        }
        else
        {
            Response.Write("<script>alert('아이디 또는 비밀번호가 잘못되었습니다!');</script>");
        }
    }

    bool SelectUser(string id,string pw)
    {
        bool checkedUser;
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=TodoDB;" +
            "Integrated Security=false; uid=host; pwd=asp2020; ");//false;uid=host; pwd=asp2020;
        con.Open();

        string query = "Select no,id From [user] where id=@id and password=@password";

        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@password", pw);


        SqlDataReader rd = cmd.ExecuteReader();

        if (rd.Read())
        {
            checkedUser = true;
            Session.Timeout = 300;
            Page.Session["[alla]"] = rd["no"].ToString();
            //Response.Write("<script>alert('두두둥장!"+Page.Session["[alla]"]+"');</script>");

        }
        else
        {
            checkedUser = false;
        }

        rd.Close();
        con.Close();

        return checkedUser;
    
    }
}