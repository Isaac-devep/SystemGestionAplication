using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SystemGestionAplication.backend.Database
{
    public static class MongoDBConnection
    {
        private static readonly string connectionString = "mongodb://localhost:27017/";
        private static readonly string databaseName = "personal_gestion";

        // Configuración de cliente con opciones
        private static readonly MongoClientSettings settings = MongoClientSettings.FromConnectionString(connectionString);

        // Configuración de tiempo de espera para evitar bloqueos
        static MongoDBConnection()
        {
            settings.ServerSelectionTimeout = TimeSpan.FromSeconds(5); // Tiempo de espera de 5 segundos
            client = new MongoClient(settings);
            database = client.GetDatabase(databaseName);
        }

        private static readonly MongoClient client;
        private static readonly IMongoDatabase database;

        public static IMongoCollection<BsonDocument> EmpleadosCollection
        {
            get { return database.GetCollection<BsonDocument>("empleados"); }
        }

        // Método para inicializar la base de datos y crear índices
        public static void InitializeDatabase()
        {
            try
            {
                var collection = EmpleadosCollection;

                // Crear índice único en _id si no existe
                var indexKeysDefinition = Builders<BsonDocument>.IndexKeys.Ascending("_id");
                var indexOptions = new CreateIndexOptions { Unique = true };
                var indexModel = new CreateIndexModel<BsonDocument>(indexKeysDefinition, indexOptions);

                collection.Indexes.CreateOne(indexModel);

                Console.WriteLine("Índice creado exitosamente.");
            }
            catch (MongoCommandException ex) when (ex.CodeName == "IndexAlreadyExists")
            {
                // El índice ya existe, lo cual está bien
                Console.WriteLine("El índice ya existe.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el índice: {ex.Message}");
            }
        }

        public static string TestConnection()
        {
            try
            {
                // Primero inicializamos la base de datos
                InitializeDatabase();

                var document = EmpleadosCollection.Find(new BsonDocument()).FirstOrDefault();
                return document != null ? "Conexión exitosa a MongoDB." : "Conexión exitosa, pero no hay documentos en la colección.";
            }
            catch (MongoCommandException ex)
            {
                Console.WriteLine($"MongoDB Command Error: {ex.Message} - Code: {ex.CodeName}");
                return $"Error al conectar con MongoDB: {ex.Message}";
            }

            catch (Exception ex)
            {
                return $"Error al conectar con MongoDB: {ex.Message}";
            }
        }
    }
}

