<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="levels.aspx.cs" Inherits="Lights.levels" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 172px">
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" Height="50px" Width="270px" >
                        <asp:Button ID="Button2" runat="server" Text ="1" Height="50px" Width="50px" OnClick="Button2_Click" />
                        <asp:Button ID="Button3" runat="server" Height="50px" Text="2" Width="50px" OnClick="Button3_Click" />
                        <asp:Button ID="Button4" runat="server" Height="50px" Text="3" Width="50px" OnClick="Button4_Click" />
                    </asp:Panel>
            <asp:Button runat="server" Text="Выйти из системы" OnClick="Unnamed1_Click"></asp:Button>
        </div>
    </form>
</body>
</html>
