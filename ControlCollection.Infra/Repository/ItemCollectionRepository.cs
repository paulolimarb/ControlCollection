﻿using ControlCollection.Domain;
using ControlCollection.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ControlCollection.Infra.Repository
{
    public class ItemCollectionRepository : IItemCollectionRepository
    {
        //Classe repositório que implementa a interface do domínio
        public List<ItemCollection> GetAll()
        {
            var response = ConnElastic.EsClient().Search<ItemCollection>(s => s.Index("basecollection").Type("itemcollection"));

            var result = response.Hits.Select(h =>
            {
                h.Source.Id = h.Id ;
                return h.Source;
            }).ToList();

            return result;
        }

        public List<ItemCollection> GetByTerm(string q)
        {
            var result = ConnElastic.EsClient().Search<ItemCollection>(s => s
           .Index("basecollection")
           .Type("itemcollection")
           .Query(query => query
           .QueryString(qs => qs.Query(q))));            

            return result.Documents.ToList();
        }


        public ItemCollection Create(ItemCollection item)
        {
            try
            {
                var result = ConnElastic.EsClient().Index(item, i => i.Index("basecollection").Type("itemcollection").Refresh());
                
                if(result.Created)
                {
                    item.Id = result.Id;
                    return item;
                }
                
            }
            catch(Exception e)
            {
                e.GetBaseException();
            }

            return null;
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
                    Name = item.Name,
                    Type = item.Type,
                    Author = item.Author,
                    Location = item.Location,
                    Status = item.Status,
                    IdContact = item.IdContact
                    

                }).Refresh());
            }
            catch(Exception e)
            {
                e.GetBaseException();
            }
        }
        
        public void Delete(string q)
        {
            try
            {
                ConnElastic.EsClient().Delete<ItemCollection>(q, p => p.Index("basecollection").Type("itemcollection"));
            }
            catch(Exception e)
            {
                e.GetBaseException();
            }
        }

    }
}
