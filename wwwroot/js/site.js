﻿// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function showBusy() {
    $('.loading').show();
}

function hideBusy() {
    $('.loading').hide();
}

$(window).on('beforeunload', function () {
    showBusy();
});

$(document).on('submit', 'form', function () {
    hideBusy();
});

window.setTimeout(function () {
    hideBusy();
}, 500);
