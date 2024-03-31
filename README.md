<h1> Api Chistes </h1>
<h2>Descripción</h2>
API web desarrollada en C# .Net Core 6 con el objetivo del aprendizaje de creación de una API, así como la conexión de ésta con la base de datos.
La API consiste en la creación, modificación y eliminación de diferentes entidades de las diferentes tablas de la base de datos, así como mostrar todos los datos referentes a éstas, así como las relaciones que tienen.
Únicamente está compuesta por dos tablas:
<ul>
  <li>
    Chiste: Contiene un Id, el texto con el contenido del chiste y el email del usuario que ha creado el chiste.
  </li>
  <li>
    Usuario: Contiene el email, el nombre de usuario, la contraseña (hasheada) y el valor de la sal añadida a la contraseña.
  </li>
</ul>

La API desarrollada contiene los siguientes endpoints:

<ul>
  <li>
    (GET) /api/Chistes: Muestra todos los chistes.
  </li>
  <li>
    (GET) /api/Chistes/{id}: Muestra únicamente el chiste indicado por el Id. Error si no existe el chiste.
  </li>
  <li>
    (POST) /api/Chistes: (Requiere autorización) Carga un chiste en la base de datos. 
  </li>
  <li>
    (PUT) /api/Chistes: (Requiere autorización) Modifica un chiste.
  </li>
  <li>
    (DELETE) /api/Chistes: (Requiere autorización) Elimina un chiste.
  </li>
  <li>
    (POST) /api/Usuario/login: Permite al usuario introducir el email y la contraseña para iniciar sesión. Devuelve token de sesión si es correcto. Devuelve error si no es correcto.
  </li>
  <li>
    (GET) /api/Usuario: Lista de todos los usuarios.
  </li>
  <li>
    (POST) /api/Usuario/signin: Permite al usuario rellenar sus datos para registrarse en el sistema.
  </li>
  <li>
    (GET) /api/Usuario/misChistes: (Requiere autorización) Permite al usuario que ya ha iniciado sesión previamente ver los chistes que ha añadido.
  </li>
  <li>
    (GET) /api/Usuario/{email}: Permite la busqueda de los chistes escritos por un usuario introduciendo el email de éste.
  </li>
</ul>

<h2>Instalación</h2>
Para que todo funcione correctamente se deben instalar varios paquetes NuGet:
<ul>
  <li>
    Microsoft.AspNetCore.AuthenticationJwtBearer (6.0.28)
  </li>
  <li>
    Microsoft.EntityFrameworkCore (6.0.28)
  </li>
  <li>
    Microsoft.EntityFrameworkCore.SqlServer (6.0.28)
  </li>
  <li>
    Microsoft.EntityFrameworkCoreTools (6.0.28)
  </li>
</ul>
<h2>Configuración</h2>
Para configurar la base de datos es necesario modificar el archivo appsettings.json. En él se deberán modificar el campo "ConnectionDB", añadiendo las credenciales de conexión de la base de datos.
También se pueden modificar en ese mismo archivo las credenciales para la creación del token de autenticación.
Finalmente, desde la consola del Administrador de paquetes es necesario ejecutar el comando Update-Database. Este comando utiliza los archivos de la carpeta Migrations para generar las tablas en la base de datos configurada.


