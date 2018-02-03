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
        protected readonly AzureDocumentDbSettings _dbSettings;

        public BaseCollectionReader(IOptions<AzureDocumentDbSettings> options)
        {
            if (options.Value == null) throw new ArgumentNullException("Document db settings can't be null");

            _dbSettings = options.Value;
            _documentClient = new DocumentClient(
                new Uri(_dbSettings.Endpoint),
                _dbSettings.PrimaryKey,
                new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }
    }
}
