
var href = location.href;

$(function () {
    $("#commentInput").on('click', function () {
        $.ajax({
            type: "POST",
            url: "/View/Comment",
            data: { "comment": $("#comment").val(), "movieID": href.match(/([^\/]*)\/*$/)[1] },
            success: function (result) {
                $("#comment-section").append(result);
            }
        });
    });
});