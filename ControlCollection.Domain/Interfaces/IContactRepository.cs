﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCollection.Domain
{
    //Interface com a declaração dos métodos para o repositório
    public interface IContactRepository
    {
        List<Contact> GetAll();
        List<Contact> GetByTerm(string q);
        void Create(Contact ct);
        void Edit(Contact ct);
        void Delete(string q);
    }
}
