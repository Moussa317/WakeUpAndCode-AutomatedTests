using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingLog.Data.Entities;

namespace ReadingLog.Data.Configurations
{
    internal class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews", "Book");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Book).WithMany(Book => Book.Reviews).HasForeignKey(x=>x.BookId);
        }
    }
}
