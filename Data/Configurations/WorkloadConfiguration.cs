using kazakov_kirill_kt_31_21.Data.Helpers;
using kazakov_kirill_kt_31_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kazakov_kirill_kt_31_21.Data.Configurations
{
    public class WorkloadConfiguration : IEntityTypeConfiguration<Workload>
    {
        private const string TableName = "cd_workload";
        public void Configure(EntityTypeBuilder<Workload> builder)
        {
            builder
                .HasKey(t => t.Id)//id
                .HasName($"pk_{TableName}_workload_id");//является ключом

            builder
                .Property(t => t.Id)//для Id
                .ValueGeneratedOnAdd()//значение автогенерируется
                .HasColumnType(ColumnType.Long)//тип
                .HasColumnName("id")//название
                .HasComment("Идентификатор учебной нагрузки");//комментарий

            builder
                .Property(t => t.Name)//у Name
                .IsRequired()//всегда требуется
                .HasColumnName("name")//название
                .HasColumnType(ColumnType.String).HasMaxLength(64)//тип
                .HasComment("Название учебной нагрузки");//комментарий

            builder
                .Property(t => t.Hours)//у Name
                .IsRequired()//всегда требуется
                .HasColumnName("hours")//название
                .HasColumnType(ColumnType.Int)//тип
                .HasComment("Часы учебной нагрузки");//комментарий
        }
    }
}
