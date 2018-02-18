using FluentNHibernate.Mapping;

namespace HowLong.Models.Write
{
    public class SerieWriteMap : ClassMap<SerieWrite>
    {
        public SerieWriteMap()
        {
            Table("Series");

            Id(x => x.Id, "Id").GeneratedBy.Identity().UnsavedValue(0);
            Map(x => x.Nome);
            Map(x => x.Produtora);
        }
    }
    
    public class VotoMap : ClassMap<Voto>
    {
        public VotoMap()
        {
            Table("Votos");
            Id(x => x.Id);
            References(x => x.SerieId);
            Map(x => x.Nota);
            Map(x => x.Data);
        }
    }
}