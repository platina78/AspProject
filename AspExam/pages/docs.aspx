<%@ Page Language="C#" AutoEventWireup="true" CodeFile="docs.aspx.cs" Inherits="AspExam_pages_docs"   ValidateRequest="False" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Faketion | Docs</title>
    <link rel="stylesheet" href="../style/base.css" />
    <link rel="stylesheet" href="../style/main.css" />
    <script src="https://cdn.jsdelivr.net/npm/@editorjs/editorjs@latest"></script>
    <script src="https://cdn.jsdelivr.net/npm/@editorjs/header@latest"></script>
    <script src="https://cdn.jsdelivr.net/npm/@editorjs/list@latest"></script>
    <script src="https://cdn.jsdelivr.net/npm/@editorjs/quote@latest"></script>
    <script src="https://cdn.jsdelivr.net/npm/@editorjs/embed@latest"></script>
    <script src="https://cdn.jsdelivr.net/npm/@editorjs/simple-image@latest"></script>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
                <div class="section_wrap">
                        <h1 class="section_title"><img src="../images/docs.png" />Docs</h1>
                        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="제목을 입력해주세요!" Display="Dynamic" ControlToValidate="docs_title"></asp:RequiredFieldValidator>--%>
                        <asp:Button ID="docs_save" runat="server" Text="저장" OnClick="docs_save_Click" />
                        <asp:Button ID="docs_delete" runat="server" Text="삭제" OnClick="docs_delete_Click" /><br />
                        <asp:TextBox ID="docs_title" runat="server" placeholder="제목을 입력해주세요!"></asp:TextBox>
                        <asp:Button ID="docs_add" runat="server" Text="추가" OnClick="docs_add_Click" />
                        <div id="editorjs"></div>
                        <asp:HiddenField ID="hiddenData" runat="server" />
                </div>
        </div>
    </form>
    <script src="../js/docs.js"></script>
    <script>
        
        let dummy = [];
        let hidden = document.querySelector("#hiddenData");
            saveBtn.addEventListener('click', function () {
                    dummy = [];
                doc_editor.save().then((outputData) => {
                    console.log('Article data:', outputData);
                    outputData.blocks.map((v,i) => {
                        console.log(v);
                        dummy.push(v);
                        console.log(dummy);
                    });
                    hidden.value = JSON.stringify(dummy);
                }).catch((error) => {
                    console.log('saving Failed', error);
                }); 
            });
        
            addBtn.addEventListener('click', function () {
                dummy = [];
            doc_editor.save().then((outputData) => {
                console.log('Article data:', outputData);
                outputData.blocks.map((v, i) => {
                    console.log(v);
                    dummy.push(v);
                });
                hidden.value = JSON.stringify(dummy);
            }).catch((error) => {
                console.log('saving Failed', error);
            });
        });

    </script>
</body>
</html>
