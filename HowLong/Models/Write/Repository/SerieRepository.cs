using System;
using System.Collections.Generic;
using System.Linq;
using HowLong.Helper;
using HowLong.Models.Read;
using HowLong.Models.Write.Commands;

namespace HowLong.Models.Write.Repository
{
    public class SerieRepository : ISerieRepository
    {
        // GET PARA O DELETE FUNCIONAR
        public SerieWrite Get(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
                return session.QueryOver<SerieWrite>()
                    .Where(c => c.Id == id)
                    .SingleOrDefault();
        }

        public SerieWrite AddSerie(SerieWrite serie, SerieRead read )
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(serie);
                    session.Save(read);
                    transaction.Commit();
                }
                return serie;
            }
        }
        
        public Voto AddVoto(Voto voto)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(voto);
                    transaction.Commit();
                }
                return voto;
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