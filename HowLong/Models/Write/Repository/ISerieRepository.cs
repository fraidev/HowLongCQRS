using System.Collections.Generic;
using HowLong.Models.Read;

namespace HowLong.Models.Write.Repository
{
    public interface ISerieRepository
    {
        SerieWrite Get(int id);
        SerieWrite AddSerie(SerieWrite serie, SerieRead read );
        Voto AddVoto(Voto voto);
        void Delete(int id);
        bool Update(SerieWrite serie);
    }
}