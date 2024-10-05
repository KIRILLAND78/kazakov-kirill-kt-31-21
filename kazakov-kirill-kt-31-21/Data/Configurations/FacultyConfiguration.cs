using kazakov_kirill_kt_31_21.Data.Helpers;
using kazakov_kirill_kt_31_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kazakov_kirill_kt_31_21.Data.Configurations
{
    public class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
    {
        private const string TableName = "cd_faculty";
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {
            builder
                .HasKey(t => t.Id)//id
                .HasName($"pk_{TableName}_faculty_id");//является ключом

            builder
                .Property(t => t.Id)//для Id
                .ValueGeneratedOnAdd()//значение автогенерируется
                .HasColumnType(ColumnType.Long)//тип long
                .HasColumnName("id")//имеет название "id"
                .HasComment("Идентификатор кафедры");//комментарий

            builder
                .Property(t => t.Name)//у Name
                .IsRequired()//всегда требуется
                .HasColumnName("name")//имеет название "name"
                .HasColumnType(ColumnType.String).HasMaxLength(64)//тип строка с длиной 64
                .HasComment("Название кафедры");//комментарий

            builder
                .Property(t => t.LeadProfessorId)//у LeadProfessorId
                .HasColumnName("lead_professor_id")//название
                .HasColumnType(ColumnType.Long)//тип
                .HasComment("Идентификатор заведующего кафедрой, может быть null");//комментарий

            builder
                .ToTable(TableName)
                .HasOne(t => t.LeadProfessor)
                .WithOne(t=>t.FacultyLead)
                .HasForeignKey<Faculty>(t=>t.LeadProfessorId)
                .HasConstraintName("fk_k_lead_professor_id")
                .OnDelete(DeleteBehavior.SetNull);


        }
    }
}
