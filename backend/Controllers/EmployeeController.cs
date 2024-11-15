using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using SystemGestionAplication.backend.Database;
using System.Globalization;

namespace SystemGestionAplication.backend.Controllers
{
    public static class EmployeeController
    {
        // Definir las horas de los turnos y recargos
        private static readonly TimeSpan TURNO_DIURNO_INICIO = TimeSpan.Parse("08:00");
        private static readonly TimeSpan TURNO_DIURNO_FIN = TimeSpan.Parse("18:00");
        private static readonly TimeSpan TURNO_NOCTURNO_INICIO = TimeSpan.Parse("18:00");
        private static readonly TimeSpan TURNO_NOCTURNO_FIN = TimeSpan.Parse("08:00");

        // Horas de recargo nocturno
        private static readonly TimeSpan RECARGO_NOCTURNO_INICIO = TimeSpan.Parse("21:00");
        private static readonly TimeSpan RECARGO_NOCTURNO_FIN = TimeSpan.Parse("06:00");

        // Horas de almuerzo (Diurno y Nocturno)
        private static readonly TimeSpan ALMUERZO_DIURNO_INICIO = TimeSpan.Parse("12:00");
        private static readonly TimeSpan ALMUERZO_DIURNO_FIN = TimeSpan.Parse("13:00");
        private static readonly TimeSpan ALMUERZO_NOCTURNO_INICIO = TimeSpan.Parse("00:00");
        private static readonly TimeSpan ALMUERZO_NOCTURNO_FIN = TimeSpan.Parse("03:00");

        // Tolerancia para retrasos (en minutos)
        private const int TOLERANCIA_MINUTOS = 15;

        // Recargos
        private const double RECARGO_NOCTURNO = 0.35;   // 35% adicional
        private const double RECARGO_DOMINICAL = 0.75;  // 75% adicional
        private const double RECARGO_EXTRA_DIURNA = 0.25;  // 25% adicional
        private const double RECARGO_EXTRA_NOCTURNA = 0.75; // 75% adicional

        // Empleado especial para excepción (puede estar en base de datos)
        private const string EXCEPCION_EMPLEADO = "mantenimiento";
        // Horarios del turno de mantenimiento
private static readonly TimeSpan TURNO_MANTENIMIENTO_INICIO = TimeSpan.Parse("08:00"); // Cambia este valor si el inicio es diferente
private static readonly TimeSpan TURNO_MANTENIMIENTO_FIN = TimeSpan.Parse("13:00"); // Fin del turno de mantenimiento



        public static List<Dictionary<string, object>> GetEmployees()
        {
            var employeesList = new List<Dictionary<string, object>>();

            try
            {
                var employees = MongoDBConnection.EmpleadosCollection.Find(new BsonDocument()).ToList();

                foreach (var employee in employees)
                {
                    if (employee == null)
                        continue;

                    string nombreCompleto = $"{employee.GetValue("nombre", "").AsString} {employee.GetValue("apellido", "").AsString}";

                    var employeeData = new Dictionary<string, object>
                    {
                        { "_id", employee.Contains("_id") ? employee["_id"]?.ToString() ?? "N/A" : "N/A" },
                        { "nombre", employee.GetValue("nombre", "").AsString },
                        { "apellido", employee.GetValue("apellido", "").AsString },
                        { "cedula", employee.GetValue("cedula", "").AsString },
                        { "nombre_completo", nombreCompleto },
                        { "cargo", employee.GetValue("cargo", "").AsString },
                        { "salario", employee.GetValue("salario", 0.0).ToDouble() },
                        { "fecha_ingreso", employee.GetValue("fecha_ingreso", new BsonString("N/A"))?.ToString() ?? "N/A" },
                        { "registros_tiempos", employee.GetValue("registros_tiempos", new BsonArray()).AsBsonArray }
                    };

                    employeesList.Add(employeeData);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener empleados: {ex.Message}");
            }

            return employeesList;
        }


        public static List<Dictionary<string, object>> GetAllEmployees()
        {
            var employeesList = new List<Dictionary<string, object>>();

            try
            {
                var employees = MongoDBConnection.EmpleadosCollection.Find(new BsonDocument()).ToList();

                foreach (var employee in employees)
                {
                    var employeeData = new Dictionary<string, object>
                    {
                        { "_id", employee.GetValue("_id", new BsonString("N/A"))?.ToString()?? "N/A" },
                        { "nombre", employee.GetValue("nombre", "").AsString },
                        { "apellido", employee.GetValue("apellido", "").AsString },
                        { "cedula", employee.GetValue("cedula", "").AsString }
                    };
                    employeesList.Add(employeeData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener todos los empleados: {ex.Message}");
            }

            return employeesList;
        }
        public static string RegisterEmployee(string nombre, string apellido, string cedula, string cargo, double salario, string fechaIngreso, string turno)
        {
            try
            {
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(cargo))
                {
                    return " Datos del empleado inválidos";
                }

                var existingEmployee = MongoDBConnection.EmpleadosCollection.Find(new BsonDocument { { "cedula", cedula } }).FirstOrDefault();
                if (existingEmployee != null)
                {
                    return "El empleado con esta cédula ya existe";
                }

                var newEmployee = new BsonDocument
                {
                    { "nombre", nombre},
                    { "apellido", apellido},
                    { "cedula", cedula},
                    { "cargo", cargo},
                    { "salario", salario},
                    { "fecha_ingreso", fechaIngreso },
                    { "turno",turno }
                };

                MongoDBConnection.EmpleadosCollection.InsertOne(newEmployee);
                return "Empleado registrado correctamente";
            }
            catch (Exception ex)
            {
                return $"Error al registrar empleado: {ex.Message}";
            }
        }

        public static string UpdateEmployee(string nombre, string apellido, string cedula, double nuevoSalario)
        {
            try
            {
                // Crear el filtro con condiciones OR para buscar por cédula o por nombre completo
                var filter = string.IsNullOrWhiteSpace(cedula)
                    ? Builders<BsonDocument>.Filter.And(
                        Builders<BsonDocument>.Filter.Eq("nombre", nombre),
                        Builders<BsonDocument>.Filter.Eq("apellido", apellido))
                    : Builders<BsonDocument>.Filter.Eq("cedula", cedula);

                // Configurar la actualización del salario
                var update = Builders<BsonDocument>.Update.Set("salario", nuevoSalario);

                // Ejecutar la actualización en la base de datos
                var result = MongoDBConnection.EmpleadosCollection.UpdateOne(filter, update);

                return result.ModifiedCount > 0 ? "Empleado actualizado correctamente" : "No se encontró el empleado";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar empleado: {ex.Message}");
                return "Error al actualizar el empleado";
            }
        }

        public static string DeleteEmployee(string nombre, string apellido, string cedula)
        {
            try
            {
                // Creamos el filtro para buscar por nombre completo o por cedula.
                var filter = Builders<BsonDocument>.Filter.Or(
                    Builders<BsonDocument>.Filter.And(
                        Builders<BsonDocument>.Filter.Eq("nombre", nombre),
                        Builders<BsonDocument>.Filter.Eq("apellido", apellido)
                    ),
                    Builders<BsonDocument>.Filter.Eq("cedula", cedula)
                );

                var result = MongoDBConnection.EmpleadosCollection.DeleteOne(filter);

                return result.DeletedCount > 0 ? "Empleado eliminado correctamente" : "No se encontró el empleado";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar empleado: {ex.Message}");
                return "Error al eliminar el empleado";
            }
        }

        public static Dictionary<string, object>? GetEmployeeById(string nombre, string apellido, string cedula)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Or(
                    Builders<BsonDocument>.Filter.And(
                        Builders<BsonDocument>.Filter.Eq("nombre", nombre),
                        Builders<BsonDocument>.Filter.Eq("apellido", apellido)
                    ),
                    Builders<BsonDocument>.Filter.Eq("cedula", cedula)
                );

                var employee = MongoDBConnection.EmpleadosCollection.Find(filter).FirstOrDefault();

                if (employee == null) return null;

                var registrosTiempos = employee.Contains("registros_tiempos") && employee["registros_tiempos"].IsBsonArray
                    ? employee["registros_tiempos"].AsBsonArray
                    : new BsonArray();

                return new Dictionary<string, object>
                {
                    { "_id", employee.Contains("_id") ? employee["_id"]?.ToString() ?? "N/A" : "N/A" },
                    { "nombre", employee.GetValue("nombre", "").AsString },
                    { "apellido", employee.GetValue("apellido", "").AsString },
                    { "cedula", employee.GetValue("cedula", "").AsString },
                    { "cargo", employee.GetValue("cargo", "").AsString },
                    { "salario", employee.GetValue("salario", 0.0).ToDouble() },
                    { "fecha_ingreso", employee.GetValue("fecha_ingreso", "N/A")?.ToString()?? "N/A" },
                    { "registros_tiempos", registrosTiempos }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener empleado: {ex.Message}");
                return null;
            }
        }

        public static List<Dictionary<string, object>> GetEmployeesWithFilters(string? nombre = null, string? apellido = null, string? cedula = null)
        {
            var employeesList = new List<Dictionary<string, object>>();

            try
            {
                // Crear un filtro inicial que coincida con todos los empleados
                var filter = Builders<BsonDocument>.Filter.Empty;

                // Agregar filtros según los parámetros proporcionados
                if (!string.IsNullOrEmpty(nombre))
                {
                    filter &= Builders<BsonDocument>.Filter.Eq("nombre", nombre);
                }
                if (!string.IsNullOrEmpty(apellido))
                {
                    filter &= Builders<BsonDocument>.Filter.Eq("apellido", apellido);
                }
                if (!string.IsNullOrEmpty(cedula))
                {
                    filter &= Builders<BsonDocument>.Filter.Eq("cedula", cedula);
                }

                // Buscar empleados en la base de datos según los filtros aplicados
                var employees = MongoDBConnection.EmpleadosCollection.Find(filter).ToList();

                // Procesar cada empleado y agregarlo a la lista de resultados
                foreach (var employee in employees)
                {
                    var employeeData = new Dictionary<string, object>
                    {
                        { "_id", employee.Contains("_id") ? employee["_id"]?.ToString() ?? "N/A" : "N/A" },
                        { "nombre", employee.GetValue("nombre", "").AsString },
                        { "apellido", employee.GetValue("apellido", "").AsString },
                        { "cedula", employee.GetValue("cedula", "").AsString },
                        { "cargo", employee.GetValue("cargo", "").AsString },
                        { "salario", employee.GetValue("salario", 0.0).ToDouble() },
                        {"fecha_ingreso", employee.GetValue("fecha_ingreso", new BsonString("N/A"))?.ToString()?? "N/A" },
                    };
                    employeesList.Add(employeeData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener empleados con filtros: {ex.Message}");
            }

            return employeesList;
        }

        // Método para buscar empleado por nombre completo o cédula
        public static Dictionary<string, object>? GetEmployeeByNameOrCedula(string nombre, string apellido, string? cedula)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Or(
                    Builders<BsonDocument>.Filter.And(
                        Builders<BsonDocument>.Filter.Eq("nombre", nombre),
                        Builders<BsonDocument>.Filter.Eq("apellido", apellido)
                    ),
                    Builders<BsonDocument>.Filter.Eq("cedula", cedula)
                );

                var employee = MongoDBConnection.EmpleadosCollection.Find(filter).FirstOrDefault();

                if (employee == null) return null;

                return new Dictionary<string, object>
                {
                    { "cedula", employee.GetValue("cedula", "").AsString },
                    { "nombre", employee.GetValue("nombre", "").AsString },
                    { "apellido", employee.GetValue("apellido", "").AsString }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener empleado: {ex.Message}");
                return null;
            }
        }

        // Método para registrar entrada o salida
        public static string RegistrarEntradaOSalida(string accion, string cedula)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("cedula", cedula);

                // Obtener el registro actual del empleado
                var employee = MongoDBConnection.EmpleadosCollection.Find(filter).FirstOrDefault();
                if (employee == null) return "Empleado no encontrado.";

                // Capturar la fecha y hora local
                var localDateTime = DateTime.Now;
                var formattedLocalTime = localDateTime.ToString("yyyy-MM-dd HH:mm:ss");

                // Obtener el turno del empleado (día, noche, mantenimiento)
                string turno = employee.Contains("turno") ? employee["turno"].AsString : "día";

                // Verificar si la última acción fue entrada o salida
                var registrosTiempos = employee.GetValue("registros_tiempos", new BsonArray()).AsBsonArray;
                string accionActual = "entrada"; // Cambié de "tipo" a "accionActual" para evitar conflicto

                if (registrosTiempos.Count > 0)
                {
                    var lastEntry = registrosTiempos.Last();
                    accionActual = lastEntry["tipo"] == "entrada" ? "salida" : "entrada";
                }

                // Registrar entrada o salida según la acción determinada
                if (accionActual == "entrada")
                {
                    if (turno == "día" && localDateTime.TimeOfDay > TURNO_DIURNO_INICIO && localDateTime.TimeOfDay <= TURNO_DIURNO_INICIO.Add(TimeSpan.FromMinutes(TOLERANCIA_MINUTOS)))
                    {
                        localDateTime = localDateTime.Date.Add(TURNO_DIURNO_INICIO);
                    }
                    else if (turno == "noche" && localDateTime.TimeOfDay > TURNO_NOCTURNO_INICIO && localDateTime.TimeOfDay <= TURNO_NOCTURNO_INICIO.Add(TimeSpan.FromMinutes(TOLERANCIA_MINUTOS)))
                    {
                        localDateTime = localDateTime.Date.Add(TURNO_NOCTURNO_INICIO);
                    }
                    else if (turno == "mantenimiento" && localDateTime.TimeOfDay > TURNO_MANTENIMIENTO_INICIO && localDateTime.TimeOfDay <= TURNO_MANTENIMIENTO_INICIO.Add(TimeSpan.FromMinutes(TOLERANCIA_MINUTOS)))
                    {
                        localDateTime = localDateTime.Date.Add(TURNO_MANTENIMIENTO_INICIO);
                    }

                    var updateEntrada = Builders<BsonDocument>.Update.Push("registros_tiempos", new BsonDocument
                    {
                        { "tipo", accionActual },
                        { "timestamp", formattedLocalTime }
                    });
                    MongoDBConnection.EmpleadosCollection.UpdateOne(filter, updateEntrada);
                    return "Entrada registrada correctamente.";
                }
                else if (accionActual == "salida")
                {
                    var lastEntry = registrosTiempos.LastOrDefault(e => e["tipo"] == "entrada");

                    if (lastEntry != null)
                    {
                        DateTime entradaHora = DateTime.Parse(lastEntry["timestamp"].AsString);
                        TimeSpan duracion = localDateTime - entradaHora;

                        var (horasNormales, horasNocturnas, recargoNocturno, horasDescontadas) = CalcularHorasYRecargos(entradaHora, localDateTime, employee, turno);

                        var updateSalida = Builders<BsonDocument>.Update.Push("registros_tiempos", new BsonDocument
                        {
                            { "tipo", accionActual },
                            { "timestamp", formattedLocalTime },
                            { "duracion", duracion.ToString() },
                            { "horas_normales", horasNormales },
                            { "horas_nocturnas", horasNocturnas },
                            { "recargo_nocturno", recargoNocturno },
                            { "horas_descontadas", horasDescontadas }
                        });

                        MongoDBConnection.EmpleadosCollection.UpdateOne(filter, updateSalida);
                        return "Salida registrada correctamente.";
                    }
                    else
                    {
                        return "No se encontró una entrada previa para calcular las horas trabajadas.";
                    }
                }
                return "Tipo de registro desconocido.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar {accion}: {ex.Message}");
                return $"Error al registrar {accion}.";
            }
        }
        private static (double horasNormales, double horasNocturnas, double recargoNocturno, double horasDescontadas) CalcularHorasYRecargos(DateTime entrada, DateTime salida, BsonDocument empleado, string turno)
        {
            double horasNormales = 0;
            double horasNocturnas = 0;
            double recargoNocturno = 0;
            double horasDescontadas = 0;

            // Manejar casos donde el turno cruza la medianoche
            TimeSpan duracionTotal;
            if (salida < entrada)
            {
                duracionTotal = (salida.AddDays(1) - entrada);
            }
            else
            {
                duracionTotal = salida - entrada;
            }

            // Verificar si es empleado de mantenimiento en sábado
            bool esEmpleadoExcepcion = empleado["cargo"].AsString.ToLower() == EXCEPCION_EMPLEADO &&
                                      entrada.DayOfWeek == DayOfWeek.Saturday;

            if (esEmpleadoExcepcion)
            {
                TimeSpan turnoFinEspecial = TimeSpan.Parse("13:00");
                if (salida.TimeOfDay > turnoFinEspecial)
                {
                    salida = entrada.Date.Add(turnoFinEspecial);
                }
            }

            // Calcular horas por intervalos de una hora
            DateTime tiempoActual = entrada;
            while (tiempoActual < salida || (salida < entrada && tiempoActual < salida.AddDays(1)))
            {
                TimeSpan horaActual = tiempoActual.TimeOfDay;
                DateTime siguienteHora = tiempoActual.AddHours(1);

                // Verificar si la hora actual está en el período de descanso nocturno (00:00 - 03:00)
                if (horaActual >= TimeSpan.FromHours(0) && horaActual < TimeSpan.FromHours(3))
                {
                    tiempoActual = siguienteHora;
                    continue; // Saltar las horas de descanso nocturno
                }

                // Determinar si la hora actual está en período nocturno (18:00 - 06:00)
                bool esHoraNocturna = horaActual >= TimeSpan.FromHours(18) || horaActual < TimeSpan.FromHours(6);

                if (esHoraNocturna)
                {
                    horasNocturnas += 1;
                    // Verificar si aplica recargo nocturno (21:00 - 06:00)
                    if (horaActual >= TimeSpan.FromHours(21) || horaActual < TimeSpan.FromHours(6))
                    {
                        recargoNocturno += RECARGO_NOCTURNO;
                    }
                }
                else
                {
                    horasNormales += 1;
                }

                tiempoActual = siguienteHora;
            }

            // Procesar permisos
            if (empleado.Contains("permisos"))
            {
                var permisos = empleado["permisos"].AsBsonArray;
                foreach (var permiso in permisos)
                {
                    if (!permiso["justificado"].AsBoolean)
                    {
                        DateTime inicioPermiso = DateTime.Parse(permiso["inicioPermiso"].AsString);
                        DateTime finPermiso = DateTime.Parse(permiso["finPermiso"].AsString);

                        // Ajustar para permisos que cruzan la medianoche
                        if (entrada > salida && finPermiso < inicioPermiso)
                        {
                            finPermiso = finPermiso.AddDays(1);
                        }

                        if ((inicioPermiso <= salida && finPermiso >= entrada) ||
                            (entrada > salida && (inicioPermiso <= salida.AddDays(1) || finPermiso >= entrada)))
                        {
                            DateTime inicioEfectivo = inicioPermiso > entrada ? inicioPermiso : entrada;
                            DateTime finEfectivo = finPermiso < salida ? finPermiso : salida;

                            if (entrada > salida && finEfectivo < inicioEfectivo)
                            {
                                finEfectivo = finEfectivo.AddDays(1);
                            }

                            // Calcular horas a descontar, excluyendo el período de descanso
                            DateTime tiempoPermiso = inicioEfectivo;
                            while (tiempoPermiso < finEfectivo)
                            {
                                TimeSpan horaPermiso = tiempoPermiso.TimeOfDay;

                                // No descontar durante el período de descanso nocturno
                                if (!(horaPermiso >= TimeSpan.FromHours(0) && horaPermiso < TimeSpan.FromHours(3)))
                                {
                                    horasDescontadas += 1;

                                    bool esHoraNocturna = horaPermiso >= TimeSpan.FromHours(18) || horaPermiso < TimeSpan.FromHours(6);
                                    if (esHoraNocturna && horasNocturnas > 0)
                                    {
                                        horasNocturnas -= 1;
                                        if (horaPermiso >= TimeSpan.FromHours(21) || horaPermiso < TimeSpan.FromHours(6))
                                        {
                                            recargoNocturno -= RECARGO_NOCTURNO;
                                        }
                                    }
                                    else if (!esHoraNocturna && horasNormales > 0)
                                    {
                                        horasNormales -= 1;
                                    }
                                }
                                tiempoPermiso = tiempoPermiso.AddHours(1);
                            }
                        }
                    }
                }
            }

            // Asegurar que no haya valores negativos
            horasNormales = Math.Max(0, horasNormales);
            horasNocturnas = Math.Max(0, horasNocturnas);
            recargoNocturno = Math.Max(0, recargoNocturno);
            horasDescontadas = Math.Max(0, horasDescontadas);

            return (horasNormales, horasNocturnas, recargoNocturno, horasDescontadas);
        }

        public static (double horasNormales, double horasNocturnas, double recargoNocturno, double horasDescontadas) ObtenerHorasYRecargos(DateTime entrada, DateTime salida, BsonDocument empleado)
        {
            string turno = empleado.Contains("turno") ? empleado["turno"].AsString : "día";
            return CalcularHorasYRecargos(entrada, salida, empleado, turno);
        }

        public static string RegistrarPermiso(string nombre, string apellido, string cedula, DateTime inicioPermiso, DateTime finPermiso, string motivo, bool justificado)
        {
            try
            {
                // Crear el filtro para buscar por cédula o por nombre y apellido.
                var filter = Builders<BsonDocument>.Filter.Or(
                    Builders<BsonDocument>.Filter.Eq("cedula", cedula),
                    Builders<BsonDocument>.Filter.And(
                        Builders<BsonDocument>.Filter.Eq("nombre", nombre),
                        Builders<BsonDocument>.Filter.Eq("apellido", apellido)
                    )
                );

                var employee = MongoDBConnection.EmpleadosCollection.Find(filter).FirstOrDefault();
                if (employee == null) return "Empleado no encontrado.";

                TimeSpan duracionPermiso = finPermiso - inicioPermiso;
                double horasPermiso = duracionPermiso.TotalHours;

                // Primero, eliminar los permisos existentes
                var updateLimpiar = Builders<BsonDocument>.Update.Unset("permisos");
                MongoDBConnection.EmpleadosCollection.UpdateOne(filter, updateLimpiar);

                var permisoRegistro = new BsonDocument
                {
                    { "inicioPermiso", inicioPermiso.ToString("yyyy-MM-dd HH:mm:ss") },
                    { "finPermiso", finPermiso.ToString("yyyy-MM-dd HH:mm:ss") },
                    { "horasPermiso", horasPermiso },
                    { "motivo", motivo },
                    { "justificado", justificado }
                };

                // Luego, agregar el nuevo permiso
                var update = Builders<BsonDocument>.Update.Push("permisos", permisoRegistro);
                MongoDBConnection.EmpleadosCollection.UpdateOne(filter, update);

                return justificado ? "Permiso justificado registrado correctamente." : "Permiso no justificado registrado correctamente.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar permiso: {ex.Message}");
                return "Error al registrar permiso.";
            }
        }

        public static bool GuardarHuella(string cedula, byte[] huellaBytes)
        {
            try
            {
                if (string.IsNullOrEmpty(cedula))
                {
                    throw new ArgumentException("La cédula no puede estar vacía.");
                }

                if (huellaBytes == null || huellaBytes.Length == 0)
                {
                    throw new ArgumentException("Los datos de la huella no pueden estar vacíos.");
                }

                var collection = MongoDBConnection.EmpleadosCollection;

                // Usar el campo "cedula" en lugar de "_id" para verificar la existencia
                var filter = Builders<BsonDocument>.Filter.Eq("cedula", cedula);
                var empleadoExistente = collection.Find(filter).FirstOrDefault();

                if (empleadoExistente != null)
                {
                    // Verificar si ya existe una huella registrada para evitar duplicados
                    if (empleadoExistente.Contains("huella") && empleadoExistente["huella"] != BsonNull.Value)
                    {
                        MessageBox.Show("Este empleado ya tiene una huella registrada. No es posible registrar la misma huella nuevamente.",
                                        "Huella Duplicada",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        return false;
                    }

                    // Si no hay huella registrada, proceder a actualizarla
                    var update = Builders<BsonDocument>.Update
                        .Set("huella", BsonBinaryData.Create(huellaBytes))
                        .Set("fechaActualizacion", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    var updateResult = collection.UpdateOne(filter, update);
                    return updateResult.ModifiedCount > 0;
                }
                else
                {
                    // El empleado no existe, crear un nuevo documento
                    var documento = new BsonDocument
                    {
                        { "cedula", cedula },
                        { "huella", BsonBinaryData.Create(huellaBytes) },
                        { "fechaRegistro", DateTime.Now },
                        { "fechaActualizacion", DateTime.Now }
                    };

                    collection.InsertOne(documento);
                    return true;
                }
            }
            catch (MongoWriteException ex) when (ex.WriteError?.Category == ServerErrorCategory.DuplicateKey)
            {
                MessageBox.Show("Ya existe un empleado con esta cédula.",
                    "Error de Duplicado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool VerificarEmpleadoExiste(string empleadoID)
        {
            try
            {
                if (string.IsNullOrEmpty(empleadoID))
                    return false;

                var collection = MongoDBConnection.EmpleadosCollection;
                var filter = Builders<BsonDocument>.Filter.Eq("_id", empleadoID);

                return collection.Find(filter).Any();
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static byte[]? ObtenerHuella(string cedula)
        {
            try
            {
                if (string.IsNullOrEmpty(cedula))
                {
                    MessageBox.Show("La cédula no puede estar vacía.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return null;
                }

                var collection = MongoDBConnection.EmpleadosCollection;

                // Usar el campo "cedula" para buscar la huella
                var filter = Builders<BsonDocument>.Filter.Eq("cedula", cedula);
                var empleado = collection.Find(filter).FirstOrDefault();

                if (empleado != null && empleado.Contains("huella"))
                {
                    return empleado["huella"].AsByteArray;
                }

                MessageBox.Show("No se encontró una huella registrada para este empleado.",
                    "Verificación Fallida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener la huella: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
    }
}