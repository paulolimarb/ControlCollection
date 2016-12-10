using System.Collections.Generic;


namespace ControlCollection.Domain
{
    //Interface com a declaração dos métodos para o repositório
    public interface IContactRepository
    {
        List<Contact> GetAll();
        List<Contact> GetByTerm(string q);

        Contact GetById(string q);
        //List<Nest.IHit<Contact>> GetById(string q);
        //List<Contact> GetById(string q);
        //IEnumerable<Contact> GetById(string q);


        void Create(Contact ct);
        void Edit(Contact ct);
        void Delete(string q);
    }
}
