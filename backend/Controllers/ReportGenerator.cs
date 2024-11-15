using ClosedXML.Excel;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemGestionAplication.backend.Database;

namespace SystemGestionAplication.backend.Controllers
{
    public class Empleado
    {
        public ObjectId Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Cargo { get; set; }
        public decimal Salario { get; set; }
        public string FechaIngreso { get; set; }
        public List<RegistroTiempo> RegistrosTiempos { get; set; }
    }

    public class RegistroTiempo
    {
        public string Tipo { get; set; }
        public string Timestamp { get; set; }
        public string Duracion { get; set; }
        public double HorasNormales { get; set; }
        public double HorasNocturnas { get; set; }
        public double RecargoNocturno { get; set; }
        public double HorasDescontadas { get; set; }
    }

    public static class ReportGenerator
    {
        public static string GenerateEmployeeHoursReport(DateTime startDate, DateTime endDate, string outputPath)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Reporte de Horas");

                    // Configurar estilos del encabezado
                    var headerStyle = worksheet.Style;
                    headerStyle.Font.Bold = true;
                    headerStyle.Fill.BackgroundColor = XLColor.LightGray;
                    headerStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Agregar encabezados
                    worksheet.Cell(1, 1).Value = "Cédula";
                    worksheet.Cell(1, 2).Value = "Nombre";
                    worksheet.Cell(1, 3).Value = "Apellido";
                    worksheet.Cell(1, 4).Value = "Cargo";
                    worksheet.Cell(1, 5).Value = "Fecha";
                    worksheet.Cell(1, 6).Value = "Turno";
                    worksheet.Cell(1, 7).Value = "Hora Entrada";
                    worksheet.Cell(1, 8).Value = "Hora Salida";
                    worksheet.Cell(1, 9).Value = "Horas Normales";
                    worksheet.Cell(1, 10).Value = "Horas Nocturnas";
                    worksheet.Cell(1, 11).Value = "Recargo Nocturno";
                    worksheet.Cell(1, 12).Value = "Horas Descontadas";
                    worksheet.Cell(1, 13).Value = "Duración";

                    // Aplicar estilo a los encabezados
                    worksheet.Range(1, 1, 1, 12).Style = headerStyle;

                    // Obtener todos los empleados
                    var filter = Builders<BsonDocument>.Filter.Empty;
                    var employees = MongoDBConnection.EmpleadosCollection.Find(filter).ToList();
                    int currentRow = 2;

                    foreach (var employee in employees)
                    {
                        // Verificar si existe el campo registros_tiempos
                        if (!employee.Contains("registros_tiempos"))
                            continue;

                        var registrosTiempos = employee["registros_tiempos"].AsBsonArray;

                        // Procesar los registros de tiempo dentro del rango de fechas
                        var registrosFiltrados = ProcesarRegistrosTiempo(registrosTiempos, startDate, endDate);

                        foreach (var registro in registrosFiltrados)
                        {
                            // Agregar datos a las celdas
                            worksheet.Cell(currentRow, 1).Value = employee["cedula"].AsString;
                            worksheet.Cell(currentRow, 2).Value = employee["nombre"].AsString;
                            worksheet.Cell(currentRow, 3).Value = employee["apellido"].AsString;
                            worksheet.Cell(currentRow, 4).Value = employee["cargo"].AsString;
                            worksheet.Cell(currentRow, 5).Value = registro.Fecha.ToShortDateString();
                            worksheet.Cell(currentRow, 6).Value = employee["turno"].AsString; // Incluir el turno
                            worksheet.Cell(currentRow, 7).Value = registro.HoraEntrada.ToString("HH:mm:ss");
                            worksheet.Cell(currentRow, 8).Value = registro.HoraSalida.ToString("HH:mm:ss");
                            worksheet.Cell(currentRow, 9).Value = registro.HorasNormales;
                            worksheet.Cell(currentRow, 10).Value = registro.HorasNocturnas;
                            worksheet.Cell(currentRow, 11).Value = registro.RecargoNocturno;
                            worksheet.Cell(currentRow, 12).Value = registro.HorasDescontadas;
                            worksheet.Cell(currentRow, 13).Value = registro.Duracion;

                            currentRow++;
                        }
                    }

                    // Ajustar el ancho de las columnas
                    worksheet.Columns().AdjustToContents();

                    // Agregar totales
                    var rangoHorasNormales = worksheet.Range(2, 8, currentRow - 1, 8);
                    var rangoHorasNocturnas = worksheet.Range(2, 9, currentRow - 1, 9);
                    var rangoHorasDescontadas = worksheet.Range(2, 11, currentRow - 1, 11);

                    worksheet.Cell(currentRow, 7).Value = "TOTALES:";
                    worksheet.Cell(currentRow, 9).FormulaA1 = $"=SUM({rangoHorasNormales.RangeAddress})";
                    worksheet.Cell(currentRow, 10).FormulaA1 = $"=SUM({rangoHorasNocturnas.RangeAddress})";
                    worksheet.Cell(currentRow, 12).FormulaA1 = $"=SUM({rangoHorasDescontadas.RangeAddress})";

                    // Estilo para la fila de totales
                    var totalRow = worksheet.Range(currentRow, 7, currentRow, 11);
                    totalRow.Style.Font.Bold = true;
                    totalRow.Style.Fill.BackgroundColor = XLColor.LightGray;

                    // Guardar el archivo
                    workbook.SaveAs(outputPath);
                    return $"Reporte generado exitosamente en: {outputPath}";
                }
            }
            catch (Exception ex)
            {
                return $"Error al generar el reporte: {ex.Message}";
            }
        }

        private static List<DatosRegistro> ProcesarRegistrosTiempo(BsonArray registros, DateTime startDate, DateTime endDate)
        {
            var registrosProcesados = new List<DatosRegistro>();

            for (int i = 0; i < registros.Count - 1; i++)
            {
                if (registros[i]["tipo"].AsString == "entrada" &&
                    i + 1 < registros.Count &&
                    registros[i + 1]["tipo"].AsString == "salida")
                {
                    var entrada = DateTime.Parse(registros[i]["timestamp"].AsString);
                    var salida = DateTime.Parse(registros[i + 1]["timestamp"].AsString);

                    if (entrada.Date >= startDate.Date && entrada.Date <= endDate.Date)
                    {
                        var registroSalida = registros[i + 1].AsBsonDocument;

                        registrosProcesados.Add(new DatosRegistro
                        {
                            Fecha = entrada.Date,
                            HoraEntrada = entrada,
                            HoraSalida = salida,
                            HorasNormales = registroSalida.GetValue("horas_normales", 0).AsDouble,
                            HorasNocturnas = registroSalida.GetValue("horas_nocturnas", 0).AsDouble,
                            RecargoNocturno = registroSalida.GetValue("recargo_nocturno", 0).AsDouble,
                            HorasDescontadas = registroSalida.GetValue("horas_descontadas", 0).AsDouble,
                            Duracion = registroSalida.GetValue("duracion", "").AsString
                        });
                    }
                }
            }

            return registrosProcesados;
        }

        public static string GenerateIndividualReport(string cedula, DateTime startDate, DateTime endDate, string outputPath)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    // Obtener el empleado específico
                    var filter = Builders<BsonDocument>.Filter.Eq("cedula", cedula);
                    var employee = MongoDBConnection.EmpleadosCollection.Find(filter).FirstOrDefault();

                    if (employee == null)
                    {
                        return "No se encontró el empleado con la cédula especificada.";
                    }

                    var worksheet = workbook.Worksheets.Add("Reporte Individual");

                    // Sección de información del empleado
                    var headerStyle = worksheet.Style;
                    headerStyle.Font.Bold = true;
                    headerStyle.Fill.BackgroundColor = XLColor.LightGray;
                    headerStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Información del empleado
                    worksheet.Cell(1, 1).Value = "INFORMACIÓN DEL EMPLEADO";
                    worksheet.Range(1, 1, 1, 4).Merge().Style = headerStyle;

                    worksheet.Cell(2, 1).Value = "Cédula:";
                    worksheet.Cell(2, 2).Value = employee["cedula"].AsString;
                    worksheet.Cell(3, 1).Value = "Nombre:";
                    worksheet.Cell(3, 2).Value = $"{employee["nombre"].AsString} {employee["apellido"].AsString}";
                    worksheet.Cell(4, 1).Value = "Cargo:";
                    worksheet.Cell(4, 2).Value = employee["cargo"].AsString;
                    worksheet.Cell(5, 1).Value = "Fecha Ingreso:";
                    worksheet.Cell(5, 2).Value = employee["fecha_ingreso"].AsString;
                    worksheet.Cell(6, 1).Value = "Salario Base:";
                    worksheet.Cell(6, 2).Value = employee["salario"].AsDouble.ToString("C");

                    // Estilo para etiquetas
                    var labelRange = worksheet.Range(2, 1, 6, 1);
                    labelRange.Style.Font.Bold = true;

                    // Espacio entre secciones
                    worksheet.Cell(8, 1).Value = "DETALLE DE REGISTROS";
                    worksheet.Range(8, 1, 8, 11).Merge().Style = headerStyle;

                    // Encabezados de la tabla de registros
                    var currentRow = 9;
                    worksheet.Cell(currentRow, 1).Value = "Fecha";
                    worksheet.Cell(currentRow, 2).Value = "Entrada";
                    worksheet.Cell(currentRow, 3).Value = "Salida";
                    worksheet.Cell(currentRow, 4).Value = "Duración";
                    worksheet.Cell(currentRow, 5).Value = "Horas Normales";
                    worksheet.Cell(currentRow, 6).Value = "Horas Nocturnas";
                    worksheet.Cell(currentRow, 7).Value = "Recargo Nocturno";
                    worksheet.Cell(currentRow, 8).Value = "Horas Descontadas";
                    worksheet.Range(currentRow, 1, currentRow, 8).Style = headerStyle;

                    currentRow++;

                    // Verificar si el campo registros_tiempos existe
                    if (employee.Contains("registros_tiempos"))
                    {
                        var registrosTiempos = employee["registros_tiempos"].AsBsonArray;
                        var registrosFiltrados = ProcesarRegistrosTiempo(registrosTiempos, startDate, endDate);

                        double totalHorasNormales = 0;
                        double totalHorasNocturnas = 0;
                        double totalRecargoNocturno = 0;
                        double totalHorasDescontadas = 0;

                        foreach (var registro in registrosFiltrados)
                        {
                            worksheet.Cell(currentRow, 1).Value = registro.Fecha.ToShortDateString();
                            worksheet.Cell(currentRow, 2).Value = registro.HoraEntrada.ToString("HH:mm:ss");
                            worksheet.Cell(currentRow, 3).Value = registro.HoraSalida.ToString("HH:mm:ss");
                            worksheet.Cell(currentRow, 4).Value = registro.Duracion;
                            worksheet.Cell(currentRow, 5).Value = registro.HorasNormales;
                            worksheet.Cell(currentRow, 6).Value = registro.HorasNocturnas;
                            worksheet.Cell(currentRow, 7).Value = registro.RecargoNocturno;
                            worksheet.Cell(currentRow, 8).Value = registro.HorasDescontadas;

                            totalHorasNormales += registro.HorasNormales;
                            totalHorasNocturnas += registro.HorasNocturnas;
                            totalRecargoNocturno += registro.RecargoNocturno;
                            totalHorasDescontadas += registro.HorasDescontadas;

                            currentRow++;
                        }

                        // Agregar totales
                        currentRow++;
                        worksheet.Cell(currentRow, 4).Value = "TOTALES:";
                        worksheet.Cell(currentRow, 5).Value = totalHorasNormales;
                        worksheet.Cell(currentRow, 6).Value = totalHorasNocturnas;
                        worksheet.Cell(currentRow, 7).Value = totalRecargoNocturno;
                        worksheet.Cell(currentRow, 8).Value = totalHorasDescontadas;
                        var totalRow = worksheet.Range(currentRow, 4, currentRow, 8);
                        totalRow.Style.Font.Bold = true;
                        totalRow.Style.Fill.BackgroundColor = XLColor.LightGray;
                    }
                    else
                    {
                        // Si no hay registros de tiempo, muestra un mensaje
                        worksheet.Cell(currentRow, 1).Value = "No hay registros de tiempo disponibles para este empleado.";
                    }

                    // Ajustar el ancho de las columnas y guardar el archivo
                    worksheet.Columns().AdjustToContents();
                    workbook.SaveAs(outputPath);
                    return $"Reporte individual generado exitosamente en: {outputPath}";
                }
            }
            catch (Exception ex)
            {
                return $"Error al generar el reporte individual: {ex.Message}";
            }
        }
        public static string GenerateJustifiedPermitsReport(DateTime startDate, DateTime endDate, string outputPath)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Permisos Justificados");

                    // Configurar estilos del encabezado
                    var headerStyle = worksheet.Style;
                    headerStyle.Font.Bold = true;
                    headerStyle.Fill.BackgroundColor = XLColor.LightGray;
                    headerStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Agregar encabezados
                    worksheet.Cell(1, 1).Value = "Cédula";
                    worksheet.Cell(1, 2).Value = "Nombre";
                    worksheet.Cell(1, 3).Value = "Apellido";
                    worksheet.Cell(1, 4).Value = "Motivo del Permiso";
                    worksheet.Cell(1, 5).Value = "Inicio del Permiso";
                    worksheet.Cell(1, 6).Value = "Fin del Permiso";
                    worksheet.Cell(1, 7).Value = "Horas de Permiso";

                    worksheet.Range(1, 1, 1, 7).Style = headerStyle;

                    // Obtener empleados
                    var filter = Builders<BsonDocument>.Filter.Empty;
                    var employees = MongoDBConnection.EmpleadosCollection.Find(filter).ToList();
                    int currentRow = 2;

                    foreach (var employee in employees)
                    {
                        if (!employee.Contains("permisos"))
                            continue;

                        var permisos = employee["permisos"].AsBsonArray;

                        foreach (var permiso in permisos)
                        {
                            if (permiso["justificado"].AsBoolean &&
                                DateTime.Parse(permiso["inicioPermiso"].AsString) >= startDate &&
                                DateTime.Parse(permiso["finPermiso"].AsString) <= endDate)
                            {
                                worksheet.Cell(currentRow, 1).Value = employee["cedula"].AsString;
                                worksheet.Cell(currentRow, 2).Value = employee["nombre"].AsString;
                                worksheet.Cell(currentRow, 3).Value = employee["apellido"].AsString;
                                worksheet.Cell(currentRow, 4).Value = permiso["motivo"].AsString;
                                worksheet.Cell(currentRow, 5).Value = DateTime.Parse(permiso["inicioPermiso"].AsString).ToString("yyyy-MM-dd HH:mm:ss");
                                worksheet.Cell(currentRow, 6).Value = DateTime.Parse(permiso["finPermiso"].AsString).ToString("yyyy-MM-dd HH:mm:ss");

                                // Calcular horas de permiso
                                TimeSpan duracionPermiso = DateTime.Parse(permiso["finPermiso"].AsString) - DateTime.Parse(permiso["inicioPermiso"].AsString);
                                worksheet.Cell(currentRow, 7).Value = duracionPermiso.TotalHours;

                                currentRow++;
                            }
                        }
                    }

                    // Ajustar el ancho de las columnas
                    worksheet.Columns().AdjustToContents();

                    // Guardar el archivo
                    workbook.SaveAs(outputPath);
                    return $"Reporte de permisos justificados generado exitosamente en: {outputPath}";
                }
            }
            catch (Exception ex)
            {
                return $"Error al generar el reporte de permisos justificados: {ex.Message}";
            }
        }



        private class DatosRegistro
        {
            public DateTime Fecha { get; set; }
            public DateTime HoraEntrada { get; set; }
            public DateTime HoraSalida { get; set; }
            public double HorasNormales { get; set; }
            public double HorasNocturnas { get; set; }
            public double RecargoNocturno { get; set; }
            public double HorasDescontadas { get; set; }
            public string Duracion { get; set; }
        }
    }
}
