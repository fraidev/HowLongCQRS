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
        private ISerieReadRepository _serieReadRepository;

        public SeriesController()
        {
            var writeRepository = new SerieRepository();
            _serieReadRepository = new SerieReadRepository();
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
          public IHttpActionResult Get(int id)
          {    
              using (var session = NHibernateHelper.OpenSession())
                 return Ok(session.Get<SerieRead>(id));
          }
        
        
          [AllowAnonymous]
          [Route("GetAll")]
          [HttpGet]
           public IHttpActionResult GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
                return Ok(session.Query<SerieRead>().ToList());
        }


        
        
       [AllowAnonymous]
       [Route("Top")]
       [HttpGet]
       public IHttpActionResult Top(int total)
        {
            if (total < 1)
            {
                return BadRequest("Valor tem que ser igual ou maior que um.");
            }
            
            // TODO obter os top n do modelo de leitura.
            var retval = _serieReadRepository.GetTop(total);
 
            return Ok(retval);
        }

        #endregion

    }
}
