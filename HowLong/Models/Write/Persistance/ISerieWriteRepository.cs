using System.Collections.Generic;

namespace HowLong.Models.Write.Persistance
{
    public interface ISerieWriteRepository
    {
        SerieWrite Get(int id);
        SerieWrite Add(SerieWrite serie);
        void Delete(int id);
        bool Update(SerieWrite serie);
    }
}