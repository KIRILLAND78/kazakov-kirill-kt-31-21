using kazakov_kirill_kt_31_21.Data.Helpers;
using kazakov_kirill_kt_31_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kazakov_kirill_kt_31_21.Data.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        private const string TableName = "cd_subject";
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder
                .HasKey(t => t.Id)//id
                .HasName($"pk_{TableName}_subject_id");//является ключом

            builder
                .Property(t => t.Id)//для Id
                .ValueGeneratedOnAdd()//значение автогенерируется
                .HasColumnType(ColumnType.Long)//тип
                .HasColumnName("id")//название
                .HasComment("Идентификатор учебного предмета");//комментарий

            builder
                .Property(t => t.Name)//у Name
                .IsRequired()//всегда требуется
                .HasColumnName("name")//название
                .HasColumnType(ColumnType.String).HasMaxLength(64)//тип
                .HasComment("Название учебного предмета");//комментарий

            builder
                .Property(t => t.WorkloadId)//у Name
                .HasColumnName("workload_id")//название
                .HasColumnType(ColumnType.Long)//тип
                .HasComment("Идентификатор учебной нагрузки");//комментарий

            builder
                .ToTable(TableName)
                .HasOne(t => t.Workload)
                .WithMany(t => t.Subjects)
                .HasForeignKey(t=>t.WorkloadId)
                .HasConstraintName("fk_k_workload_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .ToTable(TableName)
                .HasMany(t => t.Professors)
                .WithMany(t => t.Subjects);
        }
    }
}
