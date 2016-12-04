using ControlCollection.Domain;
using ControlCollection.Domain.Interfaces;
using ControlCollection.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ControlCollection.API.Controllers
{
    //Habilitando Cors e Personalização de rotas
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api")]
    public class ContactController : ApiController
    {
        private readonly IContactRepository _ct;

        //Implementação da injeção de dependência
        public ContactController(IContactRepository ct)
        {
            this._ct = ct;
        }

        //Método de consulta a todos os dados.
        [HttpGet]
        [Route("contacts")]
        public HttpResponseMessage GetAllI()
        {
            var result = _ct.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        //Método de consulta por palavra-chave.
        [HttpGet]
        [Route("contacts/term/{q}")]
        public HttpResponseMessage GetByTerm(string q)
        {
            var result = _ct.GetByTerm(q);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        //Método para cadastro de um contato.
        [HttpPost]
        [Route("contacts")]
        public HttpResponseMessage Create(Contact contact)
        {
            if (contact == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "O contato que você quer inserir está vazio.");
            try
            {
                _ct.Create(contact);
                return Request.CreateResponse(HttpStatusCode.OK, "O contato foi inserido corretamente.");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir contato.");
            }
        }

        //Método para edição de um contato.
        [HttpPut]
        [Route("contacts")]
        public HttpResponseMessage Edit(Contact contact)
        {
            if (contact == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "O contato que você quer editar está vazio.");
            try
            {
                _ct.Edit(contact);
                return Request.CreateResponse(HttpStatusCode.OK, "O contato foi editado corretamente.");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao editar contato.");
            }
        }

        //Método para apagar um contato.
        [HttpDelete]
        [Route("contacts/{id}")]
        public HttpResponseMessage Delete(string id)
        {
            if (id == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "O contato que você quer apagar não foi informado.");
            try
            {
                _ct.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "O contato foi deletado.");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao deletar contato.");
            }
        }

    }
}
