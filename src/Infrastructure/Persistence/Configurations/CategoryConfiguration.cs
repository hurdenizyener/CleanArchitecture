using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations;

public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder
            .ToTable("Categories")
            .HasKey(c => c.Id);

        builder
            .Property(c => c.Id)
            .HasColumnName("Id")
            .IsRequired();

        builder
            .Property(c => c.CategoryName)
            .HasColumnName("CategoryName")
            .HasMaxLength(250)
            .IsRequired();

        builder
           .Property(p => p.CreatedDate)
           .HasColumnName("CreatedDate")
           .IsRequired();

        builder
            .Property(p => p.CreatedBy)
            .HasColumnName("CreatedBy")
            .IsRequired();

        builder
            .Property(p => p.LastModified)
            .HasColumnName("LastModified")
            .IsRequired();

        builder
            .Property(p => p.LastModifiedBy)
            .HasColumnName("LastModifiedBy")
            .IsRequired();

        builder
            .HasIndex(indexExpression: c => c.CategoryName, name: "UK_Categories_Name")
            .IsUnique();

        builder
            .HasMany(p => p.Products);

    }
}

