$(function () {
    $.ajax({
        type: "post", url: "UserController.ashx", dataType: "json",
        data: { action: "isLogin" },
        success: function (data) {
            if (data.status == "yes") {
                $("#liUserName").show();
                $("#liLogout").show();
                $("#spanUserName").text(data.msg);
            }
            else {
                $("#liLogin").show();
                $("#liRegister").show();
            }
        },
        error: function () {
            alert("获取登陆状态失败");
        }
    });
});