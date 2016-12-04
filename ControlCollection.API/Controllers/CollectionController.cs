using ControlCollection.Domain;
using ControlCollection.Domain.Interfaces;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ControlCollection.API.Controllers
{
    //Habilitando Cors e Personalização de rotas
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api")]
    public class CollectionController : ApiController
    {
        private readonly IItemCollectionRepository _ic;

        //Implementação da injeção de dependência
        public CollectionController(IItemCollectionRepository ic)
        {
            this._ic = ic;
        }

        //Método de consulta a todos os dados.
        [HttpGet]
        [Route("items")]
        public IHttpActionResult GetAll()
        {
            var result = _ic.GetAll();
            
            return Content(HttpStatusCode.OK, result);
        }

        //Método de consulta por palavra-chave.
        [HttpGet]
        [Route("items/term/{q}")]
        public IHttpActionResult GetByTerm(string q)
        {
            var result = _ic.GetByTerm(q);

            return Content(HttpStatusCode.OK, result);
        }

        //Método para cadastro de um item.
        [HttpPost]
        [Route("items")]
        public IHttpActionResult Create(ItemCollection item)
        {
            if (item == null)
                return Content(HttpStatusCode.BadRequest, "O item que você quer inserir está vazio.");
            try
            {
                _ic.Create(item);
                return Content(HttpStatusCode.OK,"O item foi inserido corretamente.");
            }
            catch(Exception)
            {
                return Content(HttpStatusCode.InternalServerError, "Falha ao incluir o item.");
            }
        }

        //Método para edição de um item.
        [HttpPut]
        [Route("items")]
        public IHttpActionResult Edit(ItemCollection item)
        {
            if (item == null)
                return Content(HttpStatusCode.BadRequest, "O item que você quer editar está vazio.");
            try
            {
                _ic.Edit(item);
                return Content(HttpStatusCode.OK, "O item foi editado corretamente.");
            }
            catch
            {
                return Content(HttpStatusCode.InternalServerError, "Falha ao editar item.");
            }
        }

        //Método para apagar um item.
        [HttpDelete]
        [Route("items/{id}")]
        public IHttpActionResult Delete(string id)
        {
            if (id == null)
                return Content(HttpStatusCode.BadRequest,"O item que você quer apagar não foi informado.");
            try
            {
                _ic.Delete(id);
                return Content(HttpStatusCode.OK, "O item foi deletado.");
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError, "Falha ao deletar o item.");
            }
        }

    }
}
