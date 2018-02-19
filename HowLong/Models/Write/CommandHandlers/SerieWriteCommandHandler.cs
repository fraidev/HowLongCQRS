using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HowLong.Helper;
using HowLong.Models.Read;
using HowLong.Models.Write.Commands;
using HowLong.Models.Write.Repository;

namespace HowLong.Models.Write.CommandHandlers
{
    public class SerieCommandHandler
    {
        private readonly ISerieRepository _serieRepository;

        public SerieCommandHandler(ISerieRepository serieRepository)
        {
            _serieRepository = serieRepository;
        }
        
        //public List<Voto> GetVotos()
        //{
        //    using (var session = NHibernateHelper.OpenSession())
        //        return session.Query<Voto>().ToList();
        //}

        
        public void HandleCadastrar(CadastrarSerie cmd)
        {
            if (string.IsNullOrEmpty(cmd.Nome))
            {
                throw new Exception("Nome deve ser informado.");
            }
            
            
            //dynamic obj = GetVotos();

            //decimal media = obj;
            
            var serieWrite = new SerieWrite
            {
                //Id = cmd.Id,
                Nome = cmd.Nome,
                Produtora = cmd.Produtora
            };
         
            //usa o NHibernate para Add NO DB
            _serieRepository.AddSerie(serieWrite);
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
                //Id = cmd.Id,
                SerieId = cmd.SerieId,
                Nota = cmd.Nota,
                Data = DateTime.Today
            };
            
            //usa o NHibernate para Add NO DB
            _serieRepository.AddVoto(voto);
        }
        
        
    }
}