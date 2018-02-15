using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HowLong.Models;
using HowLong.Models.Read;
using HowLong.Models.Read.Persistance;
using HowLong.Models.Write.CommandHandlers;
using HowLong.Models.Write.Commands;
using HowLong.Models.Write.Persistance;

namespace HowLong.Controllers
{
    [RoutePrefix("api/Series")]
    public class SeriesController : ApiController
    {
        private SerieCommandHandler _serieCommandHandler;

        public SeriesController()
        {
            var writeRepository = new SerieWriteRepository();
            _serieCommandHandler = new SerieCommandHandler(writeRepository);
        }

        #region Escrita

        [AllowAnonymous]
        [Route("Cadastrar")]
        [HttpPost]
        public IHttpActionResult Cadastrar(CadastrarSerie cmd)
        {
            _serieCommandHandler.Handle(cmd);
            return Ok();
        }

        #endregion

        #region Leitura

        [AllowAnonymous]
        [Route("Top")]
        [HttpGet]
        public IHttpActionResult Top(int total)
        {
            // TODO obter os top n do modelo de leitura.
            return Ok();
        }
        #endregion

    }
}
