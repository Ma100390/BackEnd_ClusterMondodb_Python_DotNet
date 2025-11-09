using MongoDB.Bson;
using MongoDB.Driver;
using System;

class Program
{
    static void Main()
    {
        // Connection string con timeout
        var connectionString = "mongodb://mongo1:27017,mongo2:27018,mongo3:27019/" +
                               "?replicaSet=rs0" +
                               "&serverSelectionTimeoutMS=10000" +
                               "&connectTimeoutMS=10000";

        // USA la connectionString che hai definito! ✅
        var client = new MongoClient(connectionString);

        var database = client.GetDatabase("scuola");
        var collection = database.GetCollection<BsonDocument>("studenti");

        var doc = new BsonDocument
        {
            { "nome", "Giulia" },
            { "corso", "Cloud Computing" },
            { "voto", 27 }
        };

        collection.InsertOne(doc);
        Console.WriteLine("Documento inserito!");

        var studenti = collection.Find(new BsonDocument()).ToList();
        foreach (var studente in studenti)
            Console.WriteLine(studente);

        var filter = Builders<BsonDocument>.Filter.Eq("nome", "Giulia");
        var update = Builders<BsonDocument>.Update.Set("voto", 29);
        collection.UpdateOne(filter, update);
        //collection.DeleteOne(filter);

        Console.WriteLine("Operazioni completate!");
    }
}