// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/loginHub")
    .build();

connection.on("UserVerified", function () {
    window.location.href = "/Home/Index"; // Redirige al usuario a la página principal
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});
