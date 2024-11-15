# Sistema de Gestión de Personal

Este proyecto es una aplicación de gestión de personal que permite el registro de empleados, seguimiento de entradas y salidas mediante huella dactilar, gestión de permisos y generación de informes.

## Características

- **Inicio de Sesión** con diferentes roles de usuario (admin, gerente).
- **Registro de Empleados** con detalles como nombre, apellido, cédula, cargo, salario, y turno.
- **Registro de Entradas y Salidas** utilizando autenticación por huella dactilar.
- **Gestión de Permisos y Vacaciones** con diferentes motivos.
- **Generación de Informes** en formato Excel.

## Manual de Usuario

### 1. Inicio de Sesión

1. Presiona el botón **Login** en la esquina superior derecha.
2. Ingresa tus credenciales y haz clic en **Iniciar Sesión**.
3. Solo los usuarios con roles `admin` o `gerente` tienen acceso a ciertas secciones.

### 2. Registro de Empleados

1. Haz clic en el botón **Administración**.
2. Completa los campos: **Nombre**, **Apellido**, **Cédula**, **Cargo**, **Fecha de Ingreso**, **Salario**, y **Turno**.
3. Haz clic en **Registrar Empleado**.

### 3. Registro de Entradas y Salidas por Huella Dactilar

1. Selecciona al empleado en el menú **Empleados con Huella**.
2. Haz clic en **Entrada/Salida**.
3. Coloca el dedo en el lector de huellas para registrar la entrada o salida.

### 4. Generación de Informes

- **Informe General de Horas**:
  1. Haz clic en **Generar Informe General** en la sección Administración.
  2. Selecciona el rango de fechas y guarda el informe en formato Excel.
  
- **Informe Individual de Empleado**:
  1. Haz clic en **Generar Informe Individual** e ingresa la cédula del empleado.
  2. Selecciona el rango de fechas y guarda el archivo.

### 5. Permisos y Vacaciones

1. Ingresa a **Registro de Permisos** en la sección Administración.
2. Completa los campos necesarios y selecciona el motivo.
3. Haz clic en **Registrar Permiso** para guardar.

### 6. Cerrar Sesión

1. Haz clic en **Cerrar Sesión** en la esquina superior derecha.
2. Si hay una sesión activa, se cerrará y recibirás una confirmación.

## Documentación del Código

### Clase `MainForm`

- `MainForm()`: Inicializa la ventana principal y configura los eventos de carga y redimensionamiento.
- `CargarEmpleadosConHuella()`: Carga los empleados con huella en el ComboBox.
- `btnCloseLogin_Click()`: Maneja el evento de cierre de sesión.

### Clase `AdminForm`

- `ConfigurarAutocompletado()`: Configura el autocompletado en varios TextBox del formulario.
- `btnRegistrarEmpleado_Click()`: Registra un nuevo empleado con los datos ingresados.
- `btnGenerarInformeIndividual_Click()`: Genera el informe individual en Excel.

## Requisitos Técnicos

- **.NET Framework**: Versión compatible para ejecutar la aplicación.
- **MongoDB**: Base de datos utilizada para almacenar los datos de los empleados y registros de entradas/salidas.
- **Dispositivo de Huella Digital**: Requiere un lector de huellas compatible.

## Solución de Problemas

- **No se puede iniciar sesión**: Verifica que las credenciales sean correctas.
- **Problemas con el lector de huellas**: Asegúrate de que esté conectado correctamente.

## Contacto

- **Teléfono:** +(57) 300 390 9547
- **Correo electrónico:** [isaacfelipefloresmorales@gmail.com](mailto:isaacfelipefloresmorales@gmail.com)
- **Página web o portafolio:** [isaacflorezdev.netlify.app](https://isaacflorezdev.netlify.app)

© 2024 Isaac Florez. Todos los derechos reservados.  
**Documento confidencial - Prohibida su distribución sin autorización.**  
*Impulsando la innovación y la eficiencia en la gestión empresarial.*
