<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="AspExam_login" Debug="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Faketion | Login</title>
    <link href="https://fonts.googleapis.com/css2?family=Noto+Sans+KR:wght@400;500;900&display=swap" rel="stylesheet"/>
    <link rel="stylesheet" href="../style/base.css" />
    <link rel="stylesheet" href="../style/main.css" />
    <link rel="stylesheet" href="../style/form.css" />

</head>
<body>
    <form id="form1" runat="server">
        <div id="login_wrap">
            <h2>Faketion 로그인</h2>
            <asp:TextBox ID="login_id" runat="server" placeholder="Id"></asp:TextBox>
            <asp:TextBox ID="login_pw" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
            <div id="btn_wrap">
                <asp:Button ID="login_btn" runat="server" Text="로그인" OnClick="login_btn_Click" />
                <asp:Button ID="signup_btn" runat="server" Text="회원가입" PostBackUrl="./singup.aspx" />
            </div>
        </div>
    </form>
</body>
</html>
