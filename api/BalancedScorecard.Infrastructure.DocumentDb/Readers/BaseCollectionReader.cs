using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Options;
using System;

namespace BalancedScorecard.Infrastructure.DocumentDb.Readers
{
    public class BaseCollectionReader
    {
        protected readonly IDocumentClient _documentClient;
        protected readonly DocumentDbSettings _dbSettings;

        public BaseCollectionReader(IOptions<DocumentDbSettings> options)
        {
            if (options.Value == null) throw new ArgumentNullException("Document db settings can't be null");

            _dbSettings = options.Value;
            _documentClient = new DocumentClient(new Uri(_dbSettings.EndpointUrl), _dbSettings.PrimaryKey);
        }
    }
}
