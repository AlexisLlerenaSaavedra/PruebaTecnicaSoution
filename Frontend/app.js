const API_URL = "http://localhost:5211/api/Usuario/all"

// obtener usuarios de la API
async function obtenerUsuarios() {
    try {
        let response = await fetch(API_URL);
        if (!response.ok) throw new Error("Error al obtener los usuarios");

        let usuarios = await response.json();
        mostrarUsuarios(usuarios);
    } catch (error) {
        console.error("Error:", error);
    }
}

// funcion mostrar los usuarios en la tabla
function mostrarUsuarios(usuarios) {
    let tabla = document.getElementById("tablaUsuarios");
    tabla.innerHTML = "";

    console.log("pase por aca")

    usuarios.forEach(usuario => {
        let fila = document.createElement("tr");
        fila.innerHTML = `
            <td>${usuario.id}</td>
            <td>${usuario.usuario1}</td>
            <td>${usuario.clave}</td>
        `;
        tabla.appendChild(fila);
    });
}

// botón de cargar usuarios
document.getElementById("cargarUsuarios").addEventListener("click", obtenerUsuarios);
