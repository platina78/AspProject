<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit.aspx.cs" Inherits="AspExam_pages_edit" Debug="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="../style/base.css" />
    <link rel="stylesheet" href="../style/main.css" />
    <link rel="stylesheet" href="../style/form.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="edit_wrap">
            <div>
                <h2>Faketion 회원 수정</h2>
                    <asp:TextBox ID="edit_id" runat="server" placeholder="Id" ReadOnly="True"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="edit_pw" runat="server" placeholder="Pw" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="비밀번호를 입력해주세요!" ForeColor="#FF3300" ControlToValidate="edit_pw" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="비밀번호가 틀립니다!" ControlToValidate="edit_pw" ControlToCompare="edit_pw_check" ForeColor="#FF3300" SetFocusOnError="True"></asp:CompareValidator>
                    <br />
                    <asp:TextBox ID="edit_pw_check" runat="server" placeholder="Pw_Check" TextMode="Password"></asp:TextBox><br />
                    <asp:TextBox ID="edit_email" runat="server" placeholder="email@email.com"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="이메일형식에 맞게 써주세요!" 
                        ValidationExpression="[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?" ForeColor="#FF3300" ControlToValidate="edit_email"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="이메일을 입력해주세요!" ForeColor="#FF3300" ControlToValidate="edit_email" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </div>
            <br />
            <div id="btn_flex_wrap">
                <asp:Button ID="edit_btn" runat="server" Text="수정" OnClick="edit_btn_Click" />
                <asp:Button ID="delete_btn" runat="server" Text="탈퇴" OnClick="delete_btn_Click" CausesValidation="false" />
            </div>
        </div>
    </form>
</body>
</html>
