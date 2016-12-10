using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCollection.Domain.Interfaces
{
    //Interface com a declaração dos métodos para o repositório
    public interface IItemCollectionRepository
    {
        List<ItemCollection> GetAll();
        List<ItemCollection> GetByTerm(string q);
        void Create(ItemCollection ct);
        void Edit(ItemCollection ct);
        void Loan(ItemCollection ct);
        void Delete(string q);
    }
}
