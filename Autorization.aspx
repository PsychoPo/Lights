<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Autorization.aspx.cs" Inherits="autorization.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p style="width: 314px; margin-left: 429px">
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
        <p style="width: 256px; margin-left: 460px; margin-top: 53px">
            Логин<asp:TextBox ID="TextBox1" runat="server" style="margin-left: 20px; margin-top: 27px; margin-bottom: 0px" Width="140px"></asp:TextBox>
        </p>
        <p style="width: 250px; height: 70px; margin-left: 460px">
            Пароль<asp:TextBox ID="TextBox2" runat="server" style="margin-left: 20px; margin-top: 26px" TextMode="Password" Width="140px"></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 510px" Text="Войти в аккаунт" />
        <p style="width: 320px; margin-left: 443px">
            <asp:LinkButton ID="LinkButton1" runat="server" Text="Еще не зарегистрировались? Нажмите сюда и зарегистрируйтесь" OnClick="LinkButton1_Click" PostBackUrl="~/Registration.aspx"></asp:LinkButton>
        </p>
    </form>
</body>
</html>
