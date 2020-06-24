using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AspExam_pages_singup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void add_user_btn_Click(object sender, EventArgs e)
    {

        InsertUser(signup_id.Text, signup_pw.Text, signup_email.Text);
    }

    public  void InsertUser(string userId,string password,string email)
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=TodoDB;" +
            "Integrated Security=False; uid=host; pwd=asp2020;");
        con.Open();
        String query = "insert into [user](id,password,email) values(@userid,@password,@email)";
        if (checkUser())
        {
            Response.Write("<script>alert('아이디가 존재합니다!');</script>");
            con.Close();
        }
        else
        {
            
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@userId",userId );
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@email", email);
            
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("./login.aspx");
        }
    }

    bool checkUser()
    {

        bool checkDuplicate;
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=TodoDB;" +
            "Integrated Security=False;  uid=host; pwd=asp2020;");//uid=host; pwd=asp2020;
        con.Open();
        string query = "Select * from [user] where id=@userid";//유저 정보 검색
        //[]감싸는 이유는 다른 곳에 user라는 동일 테이블이 존재하여 검색 스코프를 []으로 Initial Catalog의 정의된 DB로 맞춤으로
        //쿼리를 사용할 수 있다.
        SqlCommand cmd = new SqlCommand(query, con);
        
        cmd.Parameters.AddWithValue("@userid", signup_id.Text);
        SqlDataReader rd = cmd.ExecuteReader();

        if (rd.Read())
        {
            checkDuplicate = true;
        }else
        {
            checkDuplicate = false;
        }

        rd.Close();
        con.Close();

        return checkDuplicate;
        
    }
}