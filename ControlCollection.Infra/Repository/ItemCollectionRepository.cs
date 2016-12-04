using ControlCollection.Domain;
using ControlCollection.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlCollection.Infra.Repository
{
    public class ItemCollectionRepository : IItemCollectionRepository
    {
        public List<ItemCollection> GetAll()
        {
            var Result = ConnElastic.EsClient().Search<ItemCollection>(s => s.Index("basecollection").Type("itemcollection"));

            return Result.Documents.ToList();
        }

        public List<ItemCollection> GetByTerm(string q)
        {
            var Result = ConnElastic.EsClient().Search<ItemCollection>(s => s
           .Index("basecollection")
           .Type("itemcollection")
           .Query(query => query
           .QueryString(qs => qs.Query(q))));

            return Result.Documents.ToList();
        }

        public void Create(ItemCollection item)
        {
            try
            {
                ConnElastic.EsClient().Index(item, i => i.Index("basecollection").Type("itemcollection").Id(item.Id).Refresh());
            }
            catch
            {
                throw new Exception("Houve um erro ao tentar inserir esse item");
            }
        }

        public void Edit(ItemCollection item)
        {
            try
            {
                ConnElastic.EsClient().Update<ItemCollection>(item.Id, q => q
                .Index("basecollection")
                .Type("itemcollection")
                .Doc(new ItemCollection
                {
                    Id = item.Id,
                    Name = item.Name,
                    Type = item.Type,
                    Author = item.Author,
                    Location = item.Location,
                    Status = item.Status

                }).Refresh());
            }
            catch
            {
                throw new Exception("Não foi possivel alterar esse item");
            }
        }

        public void Delete(string q)
        {
            try
            {
                ConnElastic.EsClient().Delete<ItemCollection>(q, p => p.Index("basecollection").Type("itemcollection"));
            }
            catch
            {
                throw new Exception("Não foi possivel remover esse item");
            }
        }

    }
}
