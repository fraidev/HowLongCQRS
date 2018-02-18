using FluentNHibernate.Mapping;

namespace HowLong.Models.Read
{
    public class SerieReadMap : ClassMap<SerieRead>
    {
        public SerieReadMap()
        {
            ReadOnly();

            Table("SerieView");

            Id(x => x.Id, "Id");

            Map(x => x.Nome);
            Map(x => x.Produtora);
            Map(x => x.Media);
        }
    }
}