using System;
using System.Collections.Generic;
using System.Linq;
using HowLong.Helper;

namespace HowLong.Models.Write.Persistance
{
    public class SerieWriteRepository : ISerieWriteRepository
    {
        // GET PARA O DELETE FUNCIONAR
        public SerieWrite Get(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
                return session.QueryOver<SerieWrite>()
                    .Where(c => c.Id == id)
                    .SingleOrDefault();
        }

        public SerieWrite Add(SerieWrite serie)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(serie);
                    transaction.Commit();
                }
                return serie;
            }
        }

        public void Delete(int id)
        {
            var serie = Get(id);

            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(serie);
                    transaction.Commit();
                }
            }

        }

        public bool Update(SerieWrite serie)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(serie);
                    try
                    {
                        transaction.Commit();
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
                return true;
            }
        }
    }
}