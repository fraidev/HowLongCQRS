using System;
using System.Collections.Generic;
using System.Linq;
using HowLong.Helper;

namespace HowLong.Models.Read.Persistance
{
    public class SerieReadRepository : ISerieReadRepository
    {

        public SerieRead Get(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            return session.QueryOver<SerieRead>()
                .Where(c => c.Id == id)
                .SingleOrDefault();
        }

        public IEnumerable<SerieRead> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
                return session.Query<SerieRead>().ToList();
        }
        
    }
}