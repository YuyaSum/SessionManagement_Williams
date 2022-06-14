<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecondPage.aspx.cs" Inherits="SessionManagement_Williams.SecondPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Member's Second Page</h2>
            <asp:Label ID="lblUser" runat="server" Font-Size="Large" />
            <br/>
            <asp:Button ID="btnClick" runat="server" Text="Click Me" OnClick="btnClick_Click" />
        </div>
    </form>
</body>
</html>
