using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Works.BlogProject.Entities.Concrete;

namespace Works.BlogProject.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class CategoryBlogMap : IEntityTypeConfiguration<CategoryBlog>
    {
        public void Configure(EntityTypeBuilder<CategoryBlog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasIndex(x => new { x.BlogId, x.CategoryId }).IsUnique();

            builder.HasOne(x => x.Blog).WithMany(x => x.CategoryBlogs).HasForeignKey(x => x.BlogId);
            builder.HasOne(x => x.Category).WithMany(x => x.CategoryBlogs).HasForeignKey(x => x.CategoryId);
        }
    }
}
