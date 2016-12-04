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
            var Result = ConnElastic.EsClient().Search<Contact>(s => s.Index("basecollection").Type("contact"));

            return Result.Documents.ToList();
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

        public void Create(Contact ct)
        {
            try
            {
               ConnElastic.EsClient().Index(ct, i => i.Index("basecollection").Type("contact").Id(ct.Id).Refresh());
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
