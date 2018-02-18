using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HowLong.Helper;
using HowLong.Models;
using HowLong.Models.Read;
using HowLong.Models.Read.Repository;
using HowLong.Models.Write;
using HowLong.Models.Write.CommandHandlers;
using HowLong.Models.Write.Commands;
using HowLong.Models.Write.Repository;

namespace HowLong.Controllers
{
    [RoutePrefix("api/Series")]
    public class SeriesController : ApiController
    {
        private SerieCommandHandler _serieCommandHandler;

        public SeriesController()
        {
            var writeRepository = new SerieRepository();
            var readRepository = new SerieReadRepository();
            _serieCommandHandler = new SerieCommandHandler(writeRepository);
        }

        #region Escrita

        [AllowAnonymous]
        [Route("Cadastrar")]
        [HttpPost]
        public IHttpActionResult Cadastrar(CadastrarSerie cmd)
        {
            _serieCommandHandler.HandleCadastrar(cmd);
            return Ok();
        }

        [AllowAnonymous]
        [Route("Votar")]
        [HttpPost]
        public IHttpActionResult Votar(Votar cmd)
        {
            _serieCommandHandler.HandleVotar(cmd);
            return Ok();
        }

        #endregion

        #region Leitura
        
          [AllowAnonymous]
          [Route("Get")]
          [HttpGet]
          public SerieWrite Get(int id)
          {    
              using (var session = NHibernateHelper.OpenSession())
                 return session.Get<SerieWrite>(id);
          }
        
        
          [AllowAnonymous]
          [Route("GetAll")]
          [HttpGet]
           public IEnumerable<SerieWrite> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
                return session.Query<SerieWrite>().ToList();
        }
        
        
       [AllowAnonymous]
       [Route("Top")]
       [HttpGet]
       public IHttpActionResult Top(int total)
        {
            // TODO obter os top n do modelo de leitura.
            //_serieReadCommandHandler.HandleTop(cmd);
 
            return Ok();
        }

        #endregion

    }
}
