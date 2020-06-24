<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="AspExam_index"  Debug="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Faketion</title>
    <link href="https://fonts.googleapis.com/css2?family=Noto+Sans+KR:wght@400;500;900&display=swap" rel="stylesheet"/>
    <link rel="stylesheet" href="./style/base.css" />
    <link rel="stylesheet" href="./style/main.css" />
    
    <script src="https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/monaco-editor/0.16.2/min/vs/loader.js"></script>
    <script src="./js/programming.js"></script>

</head>
<body>
    <form id="form1" runat="server">

        <nav id="sidemenu">
            <ul>
                <li>
                    <img src="./images/todo.png" /><asp:Button ID="todo_btn" runat="server" Text="todo" OnClick="todo_Click" CssClass="font-bold" />
                </li>
                <li>
                     <img src="./images/programming.png" /><asp:Button ID="programming_btn" runat="server" Text="programming" OnClick="programming_Click" CssClass="font-bold" />
                </li>
                <li>
                     <img src="./images/docs.png" /><asp:Button ID="docs_btn" runat="server" Text="docs" OnClick="docs_Click" CssClass="font-bold" />
                </li>
            </ul>
            <div id="user_wrap">
                <div id="user_view_icon">
                    <%Response.Write(selectUserName()[0].ToString());%>
                </div>
                <div id="user_view_id">
                    <a href="./pages/edit.aspx"><%Response.Write(selectUserName());%></a>
                </div>
                <asp:Button ID="logOut" runat="server" Text="logout" OnClick="logOut_Click" />
            </div>
        </nav>
        <section>
            <asp:Panel ID="todo_section" runat="server">
                    <div class="section_wrap">
                        <h1><img src="./images/todo.png" />Todo</h1><br />
                        <asp:TextBox ID="todo_add_title" runat="server" placeholder="제목을 입력해주세요!"></asp:TextBox>
                        <asp:Button ID="todo_add_btn" runat="server" Text="추가" OnClick="todo_add_btn_Click" />
                        <br />
                        선택한 Todo:<asp:Label ID="Label1" runat="server" Text=""></asp:Label><br />
                           <asp:GridView ID="GridView1" runat="server"
                        AutoGenerateColumns="false" DataKeyNames="contents"
                        OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting"
                        OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" 
                        OnSelectedIndexChanging="GridView1_SelectedIndexChanging" >
                            <Columns>
                                <asp:BoundField DataField="contents" HeaderText="Todo"  ItemStyle-CssClass="todo_contents" ControlStyle-CssClass="control_class" FooterStyle-CssClass="footer_class" HeaderStyle-CssClass="header_class" />
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Button ID="edit_btn" runat="server" Text="편집" CommandName="Edit" CssClass="edit_btn_style" />
                                        <asp:Button ID="delete_btn" runat="server" Text="삭제" CommandName="Delete"  CssClass="delete_btn_style" />
                                        <asp:Button ID="select_btn" runat="server" Text="선택" CommandName="Select" CssClass="select_btn_style"/>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Button ID="update_btn" runat="server" Text="업데이트" CommandName="Update" CssClass="update_btn_style" />
                                        <asp:Button ID="cancel_btn" runat="server" Text="취소" CommandName="Cancel" CssClass="cancel_btn_style" />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <%--<SelectedRowStyle BackColor="Silver" />--%>
                    </asp:GridView>
                    </div>
            </asp:Panel>
            <asp:Panel ID="programming_section" runat="server">
                <h1><img src="./images/programming.png" />Programming</h1><br />
                <asp:Button ID="compile_btn" runat="server" Text="Run"  OnClientClick="update()"  />
                <div id="monaco"></div>
                <iframe id="design"></iframe>
            </asp:Panel>
            <asp:Panel ID="docs_section" runat="server">
                <iframe src ="./pages/docs.aspx" id="docs_frame"/>
            </asp:Panel>
        </section>
    </form>
    
    <footer>

    </footer>
    
</body>
</html>
