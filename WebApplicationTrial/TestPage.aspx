<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="WebApplicationTrial.TestPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <h1>Hello All</h1>
        <p>Welcome to Asp.Net</p>
        <p>Name</p>
            
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
            <input id="Suubmit1" type="submit" value="submit" />
            <hr />
            <div style=""background-color:aqua">
                <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" Text="Button" />
            </div>
        </div>
    </form>
</body>
</html>
