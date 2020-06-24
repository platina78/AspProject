<%@ Page Language="C#" AutoEventWireup="true" CodeFile="singup.aspx.cs" Inherits="AspExam_pages_singup" Debug="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Faketion | SignUp</title>
    <link href="https://fonts.googleapis.com/css2?family=Noto+Sans+KR:wght@400;500;900&display=swap" rel="stylesheet"/>
    <link rel="stylesheet" href="../style/base.css" />
    <link rel="stylesheet" href="../style/main.css" />
    <link rel="stylesheet" href="../style/form.css" />
    
</head>
<body>
    <form id="form1" runat="server">
        <div id="signup_wrap">
            <div>
                <h2>Faketion 회원가입</h2>
                <asp:TextBox ID="signup_id" runat="server" placeholder="Id"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="아이디를 입력해주세요!" ForeColor="#FF3300" ControlToValidate="signup_id" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="signup_pw" runat="server" placeholder="Pw" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="비밀번호를 입력해주세요!" ForeColor="#FF3300" ControlToValidate="signup_pw" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="비밀번호가 틀립니다!" ControlToValidate="signup_pw" ControlToCompare="signup_pw_check" ForeColor="#FF3300" SetFocusOnError="True"></asp:CompareValidator>
                <br />
                <asp:TextBox ID="signup_pw_check" runat="server" placeholder="Pw_Check" TextMode="Password"></asp:TextBox><br />
                <asp:TextBox ID="signup_email" runat="server" placeholder="email@email.com"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="이메일형식에 맞게 써주세요!" 
                    ValidationExpression="[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?" ForeColor="#FF3300" ControlToValidate="signup_email"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="이메일을 입력해주세요!" ForeColor="#FF3300" ControlToValidate="signup_email" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </div>
            <br />
            <div id="btn_wrap">
                <asp:Button ID="add_user_btn" runat="server" Text="회원가입 완료" OnClick="add_user_btn_Click" />
            </div>
        </div>
    </form>
</body>
</html>
