using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetFamily.Domain.Shared;
using PetFamily.Domain.ValueObjects;
using PetFamily.Domain.VolunteerContext;

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
            )
            .HasColumnName("id");

        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
            .HasColumnName("first_name");

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
            .HasColumnName("last_name");

        builder.Property(x => x.MiddleName)
            .IsRequired(false)
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
            .HasColumnName("middle_name");

        builder.Property(x => x.Biography)
            .IsRequired(false)
            .HasMaxLength(Constants.MAX_HIGHT_TEXT_LENGTH)
            .HasColumnName("biography");

        builder.Property(x => x.PhoneNumber)
            .HasConversion(
                phone => phone.Value,
                value => new PhoneNumber(value)
            )
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("phone");
        

        builder.Property(x => x.EmailAddress)
            .HasConversion(
                email => email.Value,
                value => new Email(value)
            )
            .IsRequired()
            .HasMaxLength(256)
            .HasColumnName("email");

        builder.Property(x => x.ExperienceYears)
            .IsRequired()
            .HasColumnName("experience_years");

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
            .HasForeignKey(x => x.VolunteerId)
            .IsRequired(false);
        
        builder.Metadata
            .FindNavigation(nameof(Volunteer.OwnedPets))?
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}