using MongoDB.Driver;
using mp_Domain.Entities;
using System;

namespace mp_Infrastructure
{
    public sealed class PartnerContext
    {
        private static PartnerContext instance;
        public IMongoDatabase Database { get; }
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool IsSSL { get; set; }

        private static readonly object padlock = new object();

        public static PartnerContext Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new PartnerContext();
                    }
                }
                return instance;
            }
        }

        private PartnerContext()
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));

                if (IsSSL)
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };

                var mongoClient = new MongoClient(settings);
                Database = mongoClient.GetDatabase(DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar ao banco de dados.", ex);
            }
        }

        public IMongoCollection<Partner> Partners
        {
            get { return Database.GetCollection<Partner>("Partners"); }
        }
    }
}