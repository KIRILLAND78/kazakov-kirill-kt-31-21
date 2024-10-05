using kazakov_kirill_kt_31_21.Data.Helpers;
using kazakov_kirill_kt_31_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kazakov_kirill_kt_31_21.Data.Configurations
{
    public class RankConfiguration : IEntityTypeConfiguration<Rank>
    {
        private const string TableName = "cd_rank";
        public void Configure(EntityTypeBuilder<Rank> builder)
        {
            builder.ToTable(TableName);

            builder
                .HasKey(t => t.Id)//id
                .HasName($"pk_{TableName}_rank_id");//является ключом

            builder
                .Property(t => t.Id)//для Id
                .ValueGeneratedOnAdd()//значение автогенерируется
                .HasColumnType(ColumnType.Long)//тип
                .HasColumnName("id")//название
                .HasComment("Идентификатор ученой степени");//комментарий

            builder
                .Property(t => t.Name)//у Name
                .IsRequired()//всегда требуется
                .HasColumnName("name")//название
                .HasColumnType(ColumnType.String).HasMaxLength(64)//тип
                .HasComment("Название ученой степени");//комментарий

        }
    }
}
