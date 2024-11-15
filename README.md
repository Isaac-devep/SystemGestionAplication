# SystemGestionAplication

SystemGestionAplication es una aplicación de gestión empresarial que permite llevar un control eficiente de empleados, incluyendo funcionalidades como autenticación, roles de usuario, registro de huellas digitales y generación de informes. Este proyecto está diseñado para optimizar la administración de personal y mejorar la eficiencia en el manejo de datos en entornos empresariales.

## Características

- **Autenticación y Roles de Usuario:** Soporte para diferentes roles de usuario (administrador, gerente, supervisor, empleado) con control de accesos basado en permisos.
- **Registro de Huellas Digitales:** Captura y almacenamiento de huellas digitales para la autenticación de entradas y salidas.
- **Generación de Informes:** Funcionalidad para generar informes de registro en formato Excel, incluyendo detalles del empleado y su turno asignado.
- **Base de Datos MongoDB:** Integración con MongoDB para almacenar información de empleados y registros de huellas digitales.
- **Interfaz Gráfica (Windows Forms):** Interfaz intuitiva que facilita la interacción con el sistema para diferentes roles de usuario.

## Requisitos

- .NET 6.0 SDK
- MongoDB (local o en la nube)
- Biblioteca `DPFP` para la captura de huellas digitales
- Variables de entorno para la configuración de seguridad
- SDK DigitalPersona 4500

## Instalación

1. **Clona el repositorio:**
   ```bash
   git clone https://github.com/tu-usuario/SystemGestionAplication.git
   cd SystemGestionAplication
   ```

2. **Configura la base de datos MongoDB:**
   Asegúrate de que tienes una instancia de MongoDB en ejecución. Configura la conexión en el archivo `MongoDBConnection.cs` dentro de la carpeta `backend/Database`.

3. **Configura las variables de entorno:**
   Para que la autenticación funcione correctamente, necesitas configurar una variable de entorno para la clave secreta JWT.

   En Windows:
   1. Abre el Panel de Control > Sistema > Configuración avanzada del sistema > Variables de entorno.
   2. Agrega una nueva variable de entorno con el nombre `JWT_SECRET_KEY` y el valor de tu clave secreta.

   En Linux/Mac:
   ```bash
   export JWT_SECRET_KEY="tu-token-secreto-aqui"
   ```

4. **Ejecuta el proyecto:**
   Abre el proyecto en Visual Studio y ejecuta la solución para iniciar la aplicación.

## Uso

1. **Inicio de Sesión:**
   Ingresa con el usuario y contraseña según el rol deseado. Los usuarios predeterminados y contraseñas se encuentran en `AuthController.cs`.

2. **Registro de Huellas Digitales:**
   Ve a la sección de administración de empleados y selecciona la opción de registrar huellas digitales. Sigue las instrucciones en pantalla para capturar y almacenar la huella.

3. **Generación de Informes:**
   Dirígete a la opción de informes para generar y exportar registros en formato Excel.

4. **Gestión de Permisos y Roles:**
   La aplicación permite diferentes niveles de acceso según el rol del usuario (admin, gerente, supervisor, empleado).

## Configuración de Variables de Entorno

Para que la autenticación funcione correctamente, necesitas configurar la clave secreta utilizada para firmar los tokens JWT. Define una variable de entorno en tu sistema llamada `JWT_SECRET_KEY` con un valor adecuado para producción.

### Ejemplo:

En Windows:
1. Abre el Panel de Control > Sistema > Configuración avanzada del sistema > Variables de entorno.
2. Agrega una nueva variable de entorno con el nombre `JWT_SECRET_KEY` y el valor de tu clave secreta.

En Linux/Mac:
```bash
export JWT_SECRET_KEY="tu-token-secreto-aqui"
```

## Contacto

- **Teléfono:** +(57) 300 390 9547
- **Correo electrónico:** [isaacfelipefloresmorales@gmail.com](mailto:isaacfelipefloresmorales@gmail.com)
- **Página web o portafolio:** [isaacflorezdev.netlify.app](https://isaacflorezdev.netlify.app)

© 2024 Isaac Florez. Todos los derechos reservados.  
**Documento confidencial - Prohibida su distribución sin autorización.**  
*Impulsando la innovación y la eficiencia en la gestión empresarial.*
```
