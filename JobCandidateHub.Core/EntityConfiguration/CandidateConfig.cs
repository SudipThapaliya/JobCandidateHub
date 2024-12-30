using JobCandidateHub.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateHub.Core.EntityConfiguration
{
    public class CandidateConfig : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.FirstName).IsRequired();
            builder.Property(e => e.LastName).IsRequired();
            builder.Property(e => e.PhoneNumber);
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.TimeIntervalStart);
            builder.Property(e => e.TimeIntervalEnd);
            builder.Property(e => e.LinkedIn);
            builder.Property(e => e.GitHub);
            builder.Property(e => e.Comment).HasMaxLength(10000).IsRequired();

            builder.Property(e => e.CreatedBy).IsRequired();
            builder.Property(e => e.CreatedDate).IsRequired();
            builder.Property(e => e.UpdatedDate).IsRequired();
            builder.Property(e => e.UpdatedBy).IsRequired();
        }
    }
}
