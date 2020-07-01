using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Works.BlogProject.Entities.Concrete;

namespace Works.BlogProject.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.AuthorName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.AuthorEmail).HasMaxLength(70).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(400).IsRequired();

            builder.HasOne(x => x.Blog).WithMany(x => x.Comments).HasForeignKey(x => x.BlogId);
            builder.HasOne(x => x.ParentComment).WithMany(x => x.SubComments).HasForeignKey(X => X.ParentCommentId);
        }
    }
}
