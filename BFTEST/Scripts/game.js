$(document).ready(function () {

    $("#btnPlay").click(function () {
        //reset previous message
        $("#attemptResult").hide().text("");

        var selectedNumber = $("#selectedNumber").val();
        if (selectedNumber.length < 1) {
            $("#selectedNumberVal").show();
            return;
        }

        $.post('Home/Attempt', { userid: userid, selectedNumber: selectedNumber }, function (result) {
            if (result === "UserIdNotFound") {
                $("#attemptResult").show().text("Failed to cheet");
                $("#attemtps").text(0);
                $("#btnPlay").attr("disabled", true);
            }
            else if (result === "TryAgain") {
                $("#attemptResult").show().text("Failed to guess");
                var attempts = $("#attemtps").text();
                $("#attemtps").text(attempts - 1)
            } else if (result === "WelDone")
            {
                $("#attemptResult").show().text("WEL DONE!!!");
                $("#btnPlay").attr("disabled", true);
                $("#attemptscount").hide();
            }
            else if (result === "GameOver") {
                $("#attemptResult").show().text("GAME OVER!!!");
                $("#btnPlay").attr("disabled", true);
                $("#attemptscount").hide();
            }
           
        },);
    });

    $("#userName").keypress(function () { $("#userNameVal").hide(); });
    $("#selectedNumber").keypress(function () { $("#selectedNumberVal").hide(); });
});

