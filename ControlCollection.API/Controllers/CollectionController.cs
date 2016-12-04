using ControlCollection.Domain;
using ControlCollection.Domain.Interfaces;
using ControlCollection.Infra.Repository;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ControlCollection.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api")]
    public class CollectionController : ApiController
    {
        private readonly IItemCollectionRepository _ic;
        
        public CollectionController(IItemCollectionRepository ic)
        {
            this._ic = ic;
        }        

        [Route("items")]
        public HttpResponseMessage GetAllItems()
        {
            var result = _ic.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("items/term/{q}")]
        public HttpResponseMessage GetByTerm(string q)
        {
            var result = _ic.GetByTerm(q);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("items")]
        public HttpResponseMessage Create(ItemCollection item)
        {
            if (item == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "O item que você quer inserir está vazio.");
            try
            {
                _ic.Create(item);
                return Request.CreateResponse(HttpStatusCode.OK,"O item foi inserido corretamente.");
            }
            catch(Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir o item.");
            }
        }

        [HttpPut]
        [Route("items")]
        public HttpResponseMessage Edit(ItemCollection item)
        {
            if (item == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "O item que você quer editar está vazio.");
            try
            {
                _ic.Edit(item);
                return Request.CreateResponse(HttpStatusCode.OK, "O item foi editado corretamente.");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao editar item.");
            }
        }

        [HttpDelete]
        [Route("items/{id}")]
        public HttpResponseMessage Delete(string id)
        {
            if (id == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "O item que você quer apagar não foi informado.");
            try
            {
                _ic.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "O item foi deletado.");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao deletar o item.");
            }
        }

    }
}
