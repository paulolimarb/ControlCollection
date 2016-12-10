using Elasticsearch.Net;
using Nest;
using System;


namespace ControlCollection.Infra
{
    public class ConnElastic
    {
        //Método estático que cria a conexão com o elasticsearch
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

            //var response = EsClient().Map<object>(d => d
            //.Index("basecollection")
            //.Type("contact")
            //.Properties(props => props
            //    .String(s => s
            //    .Name("name"))
            //    .Completion(c => c
            //        .Name("suggest")                    
            //        .SearchAnalyzer("simple")
            //        .Payloads())));
            ////.IndexAnalyzer("simple")

            

            return elasticClient;
        }
    }
}
