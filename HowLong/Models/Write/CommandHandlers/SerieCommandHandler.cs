using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HowLong.Models.Write.Commands;
using HowLong.Models.Write.Persistance;

namespace HowLong.Models.Write.CommandHandlers
{
    public class SerieCommandHandler
    {
        private readonly ISerieWriteRepository _serieWriteRepository;

        public SerieCommandHandler(ISerieWriteRepository serieWriteRepository)
        {
            _serieWriteRepository = serieWriteRepository;
        }
        public void HandleCadastrar(CadastrarSerie cmd)
        {
            if (string.IsNullOrEmpty(cmd.Nome))
            {
                throw new Exception("Nome deve ser informado.");
            }
            
            var serieWrite = new SerieWrite
            {
                Id = cmd.Id,
                Nome = cmd.Nome,
                Produtora = cmd.Produtora
            };

            //usa o NHibernate para Add NO DB
            _serieWriteRepository.AddSerie(serieWrite);
        }

        // Handle de VOTAR
        public void HandleVotar(Votar cmd)
        {
            if (cmd.Nota==null)
            {
                throw new Exception("Nota deve ser informado.");
            }

            var voto = new Voto
            {
                Id = cmd.Id,
                SerieId = cmd.SerieId,
                Nota = cmd.Nota,
                Data = DateTime.Today
            };
            
            //usa o NHibernate para Add NO DB
            _serieWriteRepository.AddVoto(voto);
        }
        
        // TOP SERIES
        public void HandleTop(Votar cmd)
        {
        }
    }
}