using System;
using System.Collections.Generic;
using System.Linq;
using HowLong.Helper;

namespace HowLong.Models.Read.Repository
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

        public IEnumerable<SerieRead> GetTop(int quantidade)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<SerieRead>()
                    .OrderByDescending(x => x.Media)
                    .ThenBy(x => x.Nome)
                    .Take(quantidade)
                    .ToList();
            }
        }
    }
}