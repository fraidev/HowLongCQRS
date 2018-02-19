using System.Collections.Generic;
using HowLong.Models.Read.Repository;

namespace HowLong.Models.Read.Repository
{
    public interface ISerieReadRepository
    {
        SerieRead Get(int id);
        IEnumerable<SerieRead> GetAll();
        IEnumerable<SerieRead> GetTop(int quantidade);

    }
}