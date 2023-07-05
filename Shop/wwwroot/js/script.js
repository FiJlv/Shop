//Menu
$(document).ready(function ($) {
	$('.header__burger').click(function (event) {
		$('.header__burger,.header__menu').toggleClass('active');
		$('body').toggleClass('lock');
	});
});

"use strict"

//Validation
document.addEventListener('DOMContentLoaded', function () {
	const form = document.getElementById('form');
	//form.addEventListener('submit',formSend);

	async function formSend(e) {
		e.preventDefault();
		let error = formValidate(form);

	}

	function formValidate(form) {

		let error = 0;
		let formReq = document.querySelectorAll('._req');

		for (var index = 0; index < formReq.length; index++) {
			const input = formReq[index];
			formRemoveError(input);

			if (input.classList.contains('_email')) {
				if (emailTest(input)) {
					formAddError(input);
					error++;
				}
			} else {
				if (input.value === '') {
					formAddError(input);
					error++;
				}
			}
		}
	}
	function formAddError(input) {
		input.parentElement.classList.add('_error');
		input.classList.add('_error');
	}
	function formRemoveError(input) {
		input.parentElement.classList.remove('_error');
		input.classList.remove('_error');
	}
	function emailTest(input) {
		return ! /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,8})+$/.test(input.value);
	}
});

//Button
$(function () {

	$('loadmore').on('click', function () {
		const btn = $(this);
		const loader = btn.find('span');
		$.ajax({
			url: '/data.txt',
			type: 'GET',
			beforeSend: function () {
				btn.attr('disabled', true);
				loader.addClass('d-inline-block');
			},
			succses: function (responce) {
				setTimeout(function () {
					loader.removeClass('d-inline-block');
					btn.attr('disabled', false);
					console.log(responce);
				}, 1000);
			},
			error: function () {
				alert('Error!');
			}

		});
	});

});