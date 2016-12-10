using ControlCollection.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlCollection.Infra.Repository
{
    //Classe repositório que implementa a interface do domínio
    public class ContactRepository : IContactRepository
    {
        public List<Contact> GetAll()
        {
            var response = ConnElastic.EsClient().Search<Contact>(s => s.Index("basecollection").Type("contact"));

            var result = response.Hits.Select(h =>
            {
                h.Source.Id = h.Id;
                return h.Source;
            }).ToList();

            return result;
        }

        public List<Contact> GetByTerm(string q)
        {
            var Result = ConnElastic.EsClient().Search<Contact>(s => s
           .Index("basecollection")
           .Type("contact")
           .Query(query => query
           .QueryString(qs => qs.Query(q))));

            return Result.Documents.ToList();
        }

        public Contact GetById(string q)
        {   //List<Nest.IHit<Contact>>
            var result = ConnElastic.EsClient().Search<Contact>(s => s
            .Index("basecollection")
            .Type("contact")).Hits.ToList();
            // Hits.Where(p => p.Source.Id.Contains(q)).ToList(); // Select(h => { h.Source.Id = q; return h.Source; }).ToList();

            var ob = new Contact();
            
            for (int i = 0; i < result.Count; i++) { 
                if(result[i].Id == q) { 
                   ob = result[i].Source;
                    return ob;
                }

            }
            //var result = response.Hits.Select(h =>
            //{
            //    h.Source.Id = q;
            //    return h.Source;
            //}).ToList();


            return null;
        }


        public void Create(Contact ct)
        {
            try
            {
               ConnElastic.EsClient().Index(ct, i => i.Index("basecollection").Type("contact").Refresh());
            }
            catch
            {
                throw new Exception("Houve um erro ao tentar inserir esse contato");
            }
        }

        public void Edit(Contact ct)
        {
            try
            {
               ConnElastic.EsClient().Update<Contact>(ct.Id, q => q
               .Index("basecollection")
               .Type("contact")
               .Doc(new Contact
               {
                   Name = ct.Name,
                   Email = ct.Email,
                   Phone = ct.Phone

               }).Refresh());
            }
            catch
            {
                throw new Exception("Não foi possivel alterar esse contato");
            }
        }

        public void Delete(string q)
        {
            try
            {
                ConnElastic.EsClient().Delete<Contact>(q, p => p.Index("basecollection").Type("contact"));
            }
            catch
            {
                throw new Exception("Não foi possivel remover esse contato");
            }
        }


    }
}
