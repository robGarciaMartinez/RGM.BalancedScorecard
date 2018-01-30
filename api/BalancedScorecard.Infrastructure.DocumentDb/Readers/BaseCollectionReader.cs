using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace BalancedScorecard.Infrastructure.DocumentDb.Readers
{
    public class BaseCollectionReader
    {
        protected readonly IDocumentClient _documentClient;
        protected readonly DocumentDbSettings _dbSettings;

        public BaseCollectionReader(/*IOptions<DocumentDbSettings> options*/)
        {
            //if (options.Value == null) throw new ArgumentNullException("Document db settings can't be null");

            //_dbSettings = options.Value;

            _dbSettings = new DocumentDbSettings
            {
                EndpointUrl = "https://robertogarcia.documents.azure.com:443",
                PrimaryKey = "Ai2UKiYMWnsomMZLhkJHmyLTrzr17bP3SkbLOGNKeQ5oKo42mMgRXGcODZnQNHwZ10t8J8U5nQ1BuNhLtoq52A==",
                DatabaseName = "BalancedScorecard"
            };

            _documentClient = new DocumentClient(
                new Uri(_dbSettings.EndpointUrl),
                _dbSettings.PrimaryKey,
                new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }
    }
}
