<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="autorization.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            width: 1159px;
            height: 50px;
        }
    </style>
</head>
<body style="width: 1196px">
    <form id="form1" runat="server">
        <p style="width: 227px; margin-left: 460px; margin-top: 133px">
            Логин<asp:TextBox ID="TextBox1" runat="server" style="margin-left: 20px"></asp:TextBox>
        </p>
        <p style="width: 235px; margin-left: 460px; margin-top: 10px">
            Пароль<asp:TextBox ID="TextBox2" runat="server" style="margin-left: 13px" TextMode="Password" Width="120px"></asp:TextBox>
        </p>
        <p style="width: 319px; height: 40px; margin-left: 373px; margin-top: 9px">
            Повторите пароль
            <asp:TextBox ID="TextBox4" runat="server" style="margin-left: 21px" TextMode="Password" Width="126px"></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" style="margin-left: 472px" Text="Зарегистрироваться" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Отмена" />
        <p style="width: 261px; margin-left: 459px">
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
