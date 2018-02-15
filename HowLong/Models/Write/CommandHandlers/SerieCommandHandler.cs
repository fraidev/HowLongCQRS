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
        public void Handle(CadastrarSerie cmd)
        {
            if (string.IsNullOrEmpty(cmd.Nome))
            {
                throw new Exception("Nome deve ser informado.");
            }

            var serieWrite = new SerieWrite
            {
                Id = cmd.Id,
                Nome = cmd.Nome
            };

            _serieWriteRepository.Add(serieWrite);
        }

        // TODO handle para comando Votar
    }
}