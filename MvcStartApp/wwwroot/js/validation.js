document.addEventListener("DOMContentLoaded", function () {
    $.validator.setDefaults({
        errorClass: "text-danger",
        highlight: function (element) {
            $(element).closest(".form-control").addClass("is-invalid");
        },
        unhighlight: function (element) {
            $(element).closest(".form-control").removeClass("is-invalid");
        }
    });

    $("form").validate({
        rules: {
            Name: {
                required: true,
                minlength: 2
            },
            Email: {
                required: true,
                email: true
            },
            Message: {
                required: true,
                maxlength: 500
            }
        },
        messages: {
            Name: {
                required: "Введите имя",
                minlength: "Имя должно содержать минимум 2 символа"
            },
            Email: {
                required: "Введите почту",
                email: "Некорректный формат почты"
            },
            Message: {
                required: "Введите сообщение",
                maxlength: "Сообщение не должно превышать 500 символов"
            }
        }
    });
});