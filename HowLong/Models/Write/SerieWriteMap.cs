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
            Map(x => x.Produtor);
            HasMany<Voto>(x => x.Voto)
                .Inverse()
                .KeyColumn("Id");
        }
    }
}