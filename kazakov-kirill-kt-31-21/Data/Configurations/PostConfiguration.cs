using kazakov_kirill_kt_31_21.Data.Helpers;
using kazakov_kirill_kt_31_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kazakov_kirill_kt_31_21.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        private const string TableName = "cd_post";
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable(TableName);
            builder
                .HasKey(t => t.Id)//id
                .HasName($"pk_{TableName}_post_id");//является ключом

            builder
                .Property(t => t.Id)//для Id
                .ValueGeneratedOnAdd()//значение автогенерируется
                .HasColumnType(ColumnType.Long)//тип
                .HasColumnName("id")//название
                .HasComment("Идентификатор должности");//комментарий

            builder
                .Property(t => t.Name)//у Name
                .IsRequired()//всегда требуется
                .HasColumnName("name")//название
                .HasColumnType(ColumnType.String).HasMaxLength(64)//тип
                .HasComment("Название должности");//комментарий

        }
    }
}
