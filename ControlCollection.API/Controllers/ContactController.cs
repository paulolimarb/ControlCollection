using ControlCollection.Domain;
using System.Net;
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
        public IHttpActionResult GetAllI()
        {
            var result = _ct.GetAll();

            return Content(HttpStatusCode.OK, result);
        }

        //Método de consulta por palavra-chave.
        [HttpGet]
        [Route("contacts/term/{q}")]
        public IHttpActionResult GetByTerm(string q)
        {
            var result = _ct.GetByTerm(q);

            return Content(HttpStatusCode.OK, result);
        }

        //Método para cadastro de um contato.
        [HttpPost]
        [Route("contacts")]
        public IHttpActionResult Create(Contact contact)
        {
            if (contact == null)
                return Content(HttpStatusCode.BadRequest, "O contato que você quer inserir está vazio.");
            try
            {
                _ct.Create(contact);
                return Content(HttpStatusCode.OK, "O contato foi inserido corretamente.");
            }
            catch
            {
                return Content(HttpStatusCode.InternalServerError, "Falha ao incluir contato.");
            }
        }

        //Método para edição de um contato.
        [HttpPut]
        [Route("contacts")]
        public IHttpActionResult Edit(Contact contact)
        {
            if (contact == null)
                return Content(HttpStatusCode.BadRequest, "O contato que você quer editar está vazio.");
            try
            {
                _ct.Edit(contact);
                return Content(HttpStatusCode.OK, "O contato foi editado corretamente.");
            }
            catch
            {
                return Content(HttpStatusCode.InternalServerError, "Falha ao editar contato.");
            }
        }

        //Método para apagar um contato.
        [HttpDelete]
        [Route("contacts/{id}")]
        public IHttpActionResult Delete(string id)
        {
            if (id == null)
                return Content(HttpStatusCode.BadRequest, "O contato que você quer apagar não foi informado.");
            try
            {
                _ct.Delete(id);
                return Content(HttpStatusCode.OK, "O contato foi deletado.");
            }
            catch
            {
                return Content(HttpStatusCode.InternalServerError, "Falha ao deletar contato.");
            }
        }

    }
}
