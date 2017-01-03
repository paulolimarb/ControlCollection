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

        //Lista os dados que foram buscados por um termo.
        public List<Contact> GetByTerm(string q)
        {
            var Result = ConnElastic.EsClient().Search<Contact>(s => s
           .Index("basecollection")
           .Type("contact")
           .Query(query => query
           .QueryString(qs => qs.Query(q))));

            return Result.Documents.ToList();
        }

        //Recupera o contato com pelo id.
        public Contact GetById(string q)
        {
            var result = ConnElastic.EsClient().Get<Contact>(new Nest.DocumentPath<Contact>(q)
                .Index("basecollection")
                .Type("contact")).Source;

            result.Id = q;
            
            return result;
        }


        public Contact Create(Contact ct)
        {
            try
            {
                var result = ConnElastic.EsClient().Index(ct, i => i.Index("basecollection").Type("contact").Refresh());

                if (result.Created)
                {
                    ct.Id = result.Id;
                    return ct;
                }                
            }
            catch
            {
                throw new Exception("Houve um erro ao tentar inserir esse contato");
            }
            return null;
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
