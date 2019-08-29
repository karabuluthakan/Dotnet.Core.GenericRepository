/*using System;
using Dotnet.Core.Common.Contracts;
using Nest;

namespace Dotnet.Core.DataAccess.Abstract.EntityFramework
{
    public static class ElasticSearch
    {
        private static readonly ConnectionSettings ConnSettings =
            new ConnectionSettings(new Uri("http://localhost:9200/"))
                .DefaultIndex("change_history") 
                .MapDefaultTypeIndices(m => m
                    .Add(typeof(ChangeLog), "change_history"));

        private static readonly ElasticClient ElasticClient = new ElasticClient(ConnSettings);

        public static void CheckExistsAndInsert(ChangeLog log)
        {
            //elasticClient.DeleteIndex("change_log");         
            if (!ElasticClient.IndexExists("change_log").Exists)
            {
                var indexSettings = new IndexSettings();
                indexSettings.NumberOfReplicas = 1;
                indexSettings.NumberOfShards = 3;


                var createIndexDescriptor = new CreateIndexDescriptor("change_history")
                    .Mappings(ms => ms
                        .Map<ChangeLog>(m => m.AutoMap())
                    )
                    .InitializeUsing(new IndexState() {Settings = indexSettings})
                    .Aliases(a => a.Alias("change_log"));

                var response = ElasticClient.CreateIndex(createIndexDescriptor);
            }

            ElasticClient.Index<ChangeLog>(log, idx => idx.Index("change_history"));
        }
    }
}*/