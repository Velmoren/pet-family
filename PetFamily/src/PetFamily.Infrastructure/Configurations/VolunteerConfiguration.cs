using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers;

namespace PetFamily.Infrastructure.Configurations;

public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("Volunteers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => VolunteerId.Create(value)
            );

        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

        builder.Property(x => x.MiddleName)
            .IsRequired(false)
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

        builder.Property(x => x.Biography)
            .IsRequired(false)
            .HasMaxLength(Constants.MAX_HIGHT_TEXT_LENGTH);

        builder.Property(x => x.PhoneNumber)
            .IsRequired(false);
        

        builder.Property(x => x.EmailAddress)
            .IsRequired(false);

        builder.Property(x => x.ExperienceYears)
            .IsRequired(false);

        builder.OwnsMany(x => x.SocialNetworks, navigationBuilder =>
        {
            navigationBuilder.ToJson();
        });

        builder.OwnsMany(x => x.DonationDetails, navigationBuilder =>
        {
            navigationBuilder.ToJson();
        });

        builder.HasMany(x => x.OwnedPets)
            .WithOne()
            .HasForeignKey("volunteer_id")
            .IsRequired(false);
    }
}