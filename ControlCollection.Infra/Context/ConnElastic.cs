using Elasticsearch.Net;
using Nest;
using System;


namespace ControlCollection.Infra
{
    public class ConnElastic
    {
        public static ElasticClient EsClient()
        {
            ConnectionSettings ConnSettings;
            ElasticClient elasticClient;
            StaticConnectionPool ConnPool;

            var nodes = new Uri[]
            {
                new Uri("http://localhost:9200"),
            };


            ConnPool = new StaticConnectionPool(nodes);
            ConnSettings = new ConnectionSettings(ConnPool);
            elasticClient = new ElasticClient(ConnSettings);


            return elasticClient;
        }
    }
}
