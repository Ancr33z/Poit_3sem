$(document).ready(function () {
    $('#submitBtn').on('click', function () {
        let isValid = true;
        let confirmat = true; // Флаг подтверждения

        // Регулярное выражение для проверки только букв русского и английского алфавита
        const nameRegex = /^[a-zA-Zа-яА-Я]+$/;
        const emailRegex = /^[^\s@]+@[a-zA-Z]{2,5}\.[a-zA-Z]{2,3}$/;
        const phoneRegex = /^\(0\d{2}\)\d{3}-\d{2}-\d{2}$/;

        // Проверка фамилии
        const surname = $('#surname').val();
        if (surname.length > 20 || !nameRegex.test(surname)) {
            $('#surnameError').show();
            isValid = false;
        } else {
            $('#surnameError').hide();
        }

        // Проверка имени
        const name = $('#name').val();
        if (name.length > 20 || !nameRegex.test(name)) {
            $('#nameError').show();
            isValid = false;
        } else {
            $('#nameError').hide();
        }

        // Проверка email
        if (!emailRegex.test($('#email').val())) {
            $('#emailError').show();
            isValid = false;
        } else {
            $('#emailError').hide();
        }

        // Проверка телефона
        if (!phoneRegex.test($('#phone').val())) {
            $('#phoneError').show();
            isValid = false;
        } else {
            $('#phoneError').hide();
        }

        // Проверка поля "О себе"
        if ($('#about').val().length > 250 || $('#about').val().trim() === "") {
            $('#aboutError').show();
            isValid = false;
        } else {
            $('#aboutError').hide();
        }

        // Проверка, выбрано ли "Я учусь в БГТУ"
        if (!$('#bgtu').is(':checked')) {
            $('#bgtuError').show();
            isValid = false;
        } else {
            $('#bgtuError').hide();
        }

        // Проверка, выбран ли курс обучения
        if (!$('input[name="course"]:checked').val()) {
            $('#courseError').show();
            isValid = false;
        } else {
            $('#courseError').hide();
        }

        // Проверка города и курса для уточнения
        const city = $('#city').val();
        const course = $('input[name="course"]:checked').val();
        const isStudentAtBGTU = $('#bgtu').is(':checked');

        // Если выбраны значения, отличные от стандартных (например, город не Минск или курс не 3)
        if (city !== 'Минск' || course !== '2' || !isStudentAtBGTU) {
            confirmat = confirm("Вы уверены в своем ответе?"); // Модальное окно
        }

        // Если форма валидна и пользователь подтвердил свои ответы
        if (isValid && confirmat) {
            alert("Форма успешно отправлена!");
        } else if (!isValid) {
            alert("Пожалуйста, проверьте свои ответы.");
        }
    });
});
