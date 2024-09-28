using kazakov_kirill_kt_31_21.Data.Helpers;
using kazakov_kirill_kt_31_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kazakov_kirill_kt_31_21.Data.Configurations
{
    public class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
    {
        private const string TableName = "cd_professor";
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable(TableName);

            builder
                .HasKey(t => t.Id)//id
                .HasName($"pk_{TableName}_professor_id");//является ключом

            builder
                .Property(t => t.Id)//для Id
                .ValueGeneratedOnAdd()//значение автогенерируется
                .HasColumnType(ColumnType.Long)//тип
                .HasColumnName("id")//название
                .HasComment("Идентификатор преподавателя");//комментарий

            builder
                .Property(t => t.Name)//у Name
                .IsRequired()//всегда требуется
                .HasColumnName("name")//название
                .HasColumnType(ColumnType.String).HasMaxLength(64)//тип
                .HasComment("Название кафедры");//комментарий

            builder//todo
                .Property(t => t.FacultyId)//у FacultyId
                .HasColumnName("faculty_id")//название
                .HasColumnType(ColumnType.Long)//тип
                .HasComment("Идентификатор кафедры, в которой находится преподаватель");//комментарий

            builder//todo
                .Property(t => t.RankId)//у RankId
                .HasColumnName("rank_id")//название
                .HasColumnType(ColumnType.Long)//тип
                .HasComment("Идентификатор ученой степени преподавателя");//комментарий

            builder
                .Property(t => t.PostId)//у PostId
                .HasColumnName("post_id")//название
                .HasColumnType(ColumnType.Long)//тип
                .HasComment("Идентификатор должности преподавателя");//комментарий

            builder
                .ToTable(TableName)
                .HasOne(t=>t.Faculty)
                .WithMany(t=>t.Professors)
                .HasForeignKey(t => t.FacultyId)
                .HasConstraintName("fk_k_faculty_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .ToTable(TableName)
                .HasOne(t => t.Rank)
                .WithMany(t => t.Professors)
                .HasForeignKey(t => t.RankId)
                .HasConstraintName("fk_k_rank_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .ToTable(TableName)
                .HasOne(t => t.Post)
                .WithMany(t => t.Professors)
                .HasForeignKey(t => t.PostId)
                .HasConstraintName("fk_k_post_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .ToTable(TableName)
                .HasMany(t => t.Subjects)
                .WithMany(t => t.Professors);

        }
    }
}
