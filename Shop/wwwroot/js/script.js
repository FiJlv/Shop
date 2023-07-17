//Menu
$(document).ready(function ($) {
	$('.header__burger').click(function (event) {
		$('.header__burger,.header__menu').toggleClass('active');
		$('body').toggleClass('lock');
	});
});

function toggleMenu() {
	var headerMenu = document.querySelector('.header__menu');
	headerMenu.classList.toggle('active');
}

"use strict"

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