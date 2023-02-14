$(document).ready(function () {
    let location = window.location.href;
    let partialLink = location.split('/')[3];
    $(".link").removeClass('active');
    switch (partialLink) {
        case "":
            $("#linkHome").addClass('active');
            break;
        case "AboutUs":
            $("#linkAboutUs").addClass('active');
            break;
        case "Service":
            $("#LinkService").addClass('active');
            break;
        case "ContactUs":
            $("#linkContactUs").addClass('active');
            break;
        default:
    }
});

function Success(response) {
    $("#btnSubmit").removeAttr('style');
    $("#btnSubmitLoading").attr("style", "display:none");
    alertify.alert(response)
    setTimeout(() => { location.reload(); },3000)
}

function AjaxBeginMethod() {
    $("#btnSubmit").attr("style", "display:none");
    $("#btnSubmitLoading").removeAttr('style');
}
