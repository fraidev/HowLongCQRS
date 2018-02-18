using System.Collections.Generic;
using HowLong.Models.Write;

namespace HowLong.Models.Read.Repository
{
    public interface ISerieReadRepository
    {
        SerieRead Get(int id);
        IEnumerable<SerieRead> GetAll();
      
    }
}