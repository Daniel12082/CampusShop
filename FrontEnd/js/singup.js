document.addEventListener("DOMContentLoaded", function() {
    const form = document.getElementById('signupForm');

    form.addEventListener('submit', function(event) {
        event.preventDefault(); // Evita la recarga de la página al enviar el formulario

        const email = document.getElementById('email').value;
        const user = document.getElementById('user').value;
        const password = document.getElementById('password').value;

        const userData = {
            email: email,
            user: user,
            password: password
        };

        registerUser(userData); // Llama a la función para registrar al usuario
    });
});

function registerUser(data) {
    fetch('http://localhost:5043/Usuario/register', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
    })
    .then(response => {
        if (response.ok) {
            // Registro exitoso
            console.log('Usuario registrado correctamente.');
            window.location.href = "/index.html"; // Redirige si el registro es exitoso
        } else {
            // Manejo de errores de registro
            throw new Error('Error al registrar usuario.');
        }
    })
    .catch(error => {
        // Manejo de errores generales
        console.error('Error:', error);
    });
}