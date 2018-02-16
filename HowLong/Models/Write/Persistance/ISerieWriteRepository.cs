using System.Collections.Generic;

namespace HowLong.Models.Write.Persistance
{
    public interface ISerieWriteRepository
    {
        SerieWrite Get(int id);
        SerieWrite AddSerie(SerieWrite serie);
        Voto AddVoto(Voto voto);
        void Delete(int id);
        bool Update(SerieWrite serie);
    }
}