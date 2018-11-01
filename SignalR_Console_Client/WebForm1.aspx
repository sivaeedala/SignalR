<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SignalR_Console_Client.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.6.4.js"></script>
    <script src="Scripts/jquery.signalR-2.3.0.js"></script>
    <script src='http://localhost:8282/signalr/js'></script>
    <%--<script src="/signalr/hubs" type="text/javascript"></script>--%>
    <script src="JavaScript.js"></script>
    
    

    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="text" id="txt" />
            <br />
            <input type="button" id="btnClick" value="send" />
        </div>

        <div id="messages"></div>
    </form>
</body>
</html>
