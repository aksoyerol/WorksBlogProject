using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Works.BlogProject.Entities.Concrete;

namespace Works.BlogProject.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class BlogMap : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x => x.ShortDescription).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Description).HasColumnType("ntext").IsRequired();
            builder.Property(x => x.ImagePath).HasMaxLength(200);

            builder.HasOne(x => x.AppUser).WithMany(x => x.Blogs).HasForeignKey(x => x.AppUserId);

        }
    }
}
