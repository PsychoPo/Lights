<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lvl_E1.aspx.cs" Inherits="Lights.lvl_E1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript"> //Таймер здесь
        function init() {
            sec = 0;
            setInterval(tick, 1000);
        }
        function tick() {
            sec++;
            document.getElementById("label_time").innerHTML = sec;
        }
    </script>
    <style type="text/css">
        .header {
            width: 100%;
            background: #808080;
            height: 55px;
        }
        .container {
            width: 80%;
            margin: auto auto;
            text-align: center;
            background: #ebc2c2;
            height: 400px;
        }
        .navigation {
            width: 100%;
            background: #dbb643;
            height: 25px;
        }
        .leftbar {
            width: 20%;
            float: left;
            display: block;
            position:relative;
            background: #b81d1d;
            height: 280px;
        }
        .rightbar {
            width: 20%;
            float: left;
            display: block;
            position:relative;
            background: #b81d1d;
            height: 280px;
        }
        .content {
            width: 60%;
            float: left;
            display: flex;
            background: #56cb66;
            height: 280px;
        }
        .clear{
            clear: both;
        }
        .footer {
            width: 100%;
            background: #ffd800;
            height: 40px;
        }
        .levels {
            width:  180px;
            height: 180px;
            margin: auto auto;
        }
    </style>
</head>
<body onload="init()">
    <form id="form1" runat="server">
            <div class="container">
                <div class="header"></div>
                <div class="navigation"></div>
                <div class="leftbar">
                    <div style="display:block">
                        <asp:Button ID="Back" runat="server" Text="НАЗАД" OnClick="Back_Click"></asp:Button>
                    </div>
                    
                    <div style="position: absolute; bottom: 0">
                        <asp:Label ID="label_time" runat="server"></asp:Label>
                    </div>
                </div>
                <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <div class="content">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="levels">
                                <asp:ImageButton ID="ImageButton1" runat="server" BorderStyle="Dotted" Height="50px" Width="50px" OnClick="ImageButton_Click" />
                                <asp:ImageButton ID="ImageButton2" runat="server" BorderStyle="Dotted" Height="50px" Width="50px" OnClick="ImageButton_Click" />
                                <asp:ImageButton ID="ImageButton3" runat="server" BorderStyle="Dotted" Height="50px" Width="50px" OnClick="ImageButton_Click" />
                                <asp:ImageButton ID="ImageButton4" runat="server" BorderStyle="Dotted" Height="50px" Width="50px" OnClick="ImageButton_Click" />
                                <asp:ImageButton ID="ImageButton5" runat="server" BorderStyle="Dotted" Height="50px" Width="50px" OnClick="ImageButton_Click" />
                                <asp:ImageButton ID="ImageButton6" runat="server" BorderStyle="Dotted" Height="50px" Width="50px" OnClick="ImageButton_Click" />
                                <asp:ImageButton ID="ImageButton7" runat="server" BorderStyle="Dotted" Height="50px" Width="50px" OnClick="ImageButton_Click" />
                                <asp:ImageButton ID="ImageButton8" runat="server" BorderStyle="Dotted" Height="50px" Width="50px" OnClick="ImageButton_Click" />
                                <asp:ImageButton ID="ImageButton9" runat="server" BorderStyle="Dotted" Height="50px" Width="50px" OnClick="ImageButton_Click" />
                                
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="rightbar">
                    <div style="display:block">
                        <asp:Button ID="remove" runat="server" Text="СБРОСИТЬ" OnClick="remove_Click"></asp:Button>
                    </div>
                    <div style="display:block">
                        
                    </div>
                    <div style="position: absolute; bottom: 0">
                        <asp:Label ID="label1" runat="server" Text="УРОВЕНЬ 1-1"></asp:Label>
                    </div>
                </div>
                <div class="clear"></div>
                <div class="footer"></div>
            </div>
            
    </form>
</body>
</html>
