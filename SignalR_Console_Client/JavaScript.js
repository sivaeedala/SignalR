$(function () {
    
    var myHub = $.connection.testHub;
    $.connection.hub.url = "http://localhost:8282/signalr/hubs";
    $.connection.hub.start().done(function () {
        console.log("Connected");
        $("#btnClick").click(function () {
            myHub.server.sendMessage($("#txt").val());
            $("#txt").val(' ');
        })

    }).fail(function () {
        console.log("error");
    });

    myHub.client.pushMessage = function (msg) {
        $("#messages").append("<li>" + msg + "</li>");
    };
});