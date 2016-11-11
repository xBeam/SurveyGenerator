$(document).ready(function () {
    console.log(1);
    $('form')
        .submit(function () {

            var dataToSend = {};

            dataToSend.fromName = $('.fromName').val();
            dataToSend.fromEmail = $('.fromEmail').val();
            dataToSend.messageToSend = $('.messageToSend').val();
            dataToSend.recaptcha = $(".g-recaptcha-response")[0].value;

            $.post(window.routeController.urlToSendEmail,
                dataToSend,
                function (response) {
                    //swal({
                    //    title: response,
                    //    type: "info",
                    //    confirmButtonColor: "#27408B",
                    //    confirmButtonText: "Thanks"
                    //});
                    alert(response);
                });

            $('.js-sendEmail')
                .each(function () {
                    this.reset();
                });

            return false;
        });
});
