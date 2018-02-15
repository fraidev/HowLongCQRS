using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace HowLong.Models.Write
{
    public class VotoMap : ClassMap<Voto>
    {
        public VotoMap()
        {
            Table("Votos");
            Id(x => x.SerieId);
            Map(x => x.Nota);
            Map(x => x.Data);
            // TODO Testar o codigo a baixo:
            References<SerieWrite>(x => x.SerieId) 
                .Column("SerieId");
        }
    }
}