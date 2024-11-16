$(document).ready(function () {
    $('#submitBtn').on('click', function () {
        let isValid = true;
        let confirmat = false;

        const nameRegex = /^[a-zA-Zа-яА-Я]{1,20}$/;
        const emailRegex = /^[^\s@]+@[a-zA-Z]{2,5}\.[a-zA-Z]{2,3}$/;
        const phoneRegex = /^\(0\d{2}\)\d{3}-\d{2}-\d{2}$/;

        if (!nameRegex.test($('#surname').val())) {
            $('#surnameError').show();
            isValid = false;
        } else {
            $('#surnameError').hide();
        }

        if (!nameRegex.test($('#name').val())) {
            $('#nameError').show();
            isValid = false;
        } else {
            $('#nameError').hide();
        }

        if (!emailRegex.test($('#email').val())) {
            $('#emailError').show();
            isValid = false;
        } else {
            $('#emailError').hide();
        }

        if (!phoneRegex.test($('#phone').val())) {
            $('#phoneError').show();
            isValid = false;
        } else {
            $('#phoneError').hide();
        }

        if ($('#about').val().length > 250 || $('#about').val().trim() === "") {
            $('#aboutError').show();
            isValid = false;
        } else {
            $('#aboutError').hide();
        }

        const city = $('#city').val();
        const course = $('input[name="course"]:checked').val();
        const isStudentAtBGTU = $('#bgtu').is(':checked');

        if (city !== 'Минск' || course !== '3' || !isStudentAtBGTU) {
            if (!confirm("Вы уверены в своем ответе?")) {
                confirmat = false;
                isValid = true;
            }
        }

        if (isValid && confirmat) {
            alert("Форма успешно отправлена!");
        } else if (isValid) {
            alert("Пожалуйста, исправьте ошибки перед отправкой.");
        }
    });
});
