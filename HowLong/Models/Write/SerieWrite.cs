using System.Collections.Generic;

namespace HowLong.Models.Write
{
    public class SerieWrite
    {
        //public SerieWrite(int id, string nome, decimal produtor)
        //{
        //    Id = id;
        //    Nome = nome;
        //    Produtor = produtor;
        //}

        public SerieWrite()
        {
            Voto = new List<Voto>();

        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Produtor { get; set; }
        public IList<Voto> Voto { get; set; }
    }
 }