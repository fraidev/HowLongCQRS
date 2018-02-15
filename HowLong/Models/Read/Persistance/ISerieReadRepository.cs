using System.Collections.Generic;

namespace HowLong.Models.Read.Persistance
{
    public interface ISerieReadRepository
    {
        SerieRead Get(int id);
        IEnumerable<SerieRead> GetAll();
      
    }
}