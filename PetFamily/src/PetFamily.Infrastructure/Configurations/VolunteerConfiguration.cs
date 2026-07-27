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

        builder.ComplexProperty(x => x.VolunteerInfo, tb =>
        {
            tb.Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("first_name");
            
            tb.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("last_name");
            
            tb.Property(x => x.MiddleName)
                .IsRequired(false)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("middle_name");
            
            tb.Property(x => x.Biography)
                .IsRequired(false)
                .HasMaxLength(Constants.MAX_HIGHT_TEXT_LENGTH)
                .HasColumnName("biography");
            
            tb.Property(x => x.ExperienceYears)
                .IsRequired(false)
                .HasColumnName("experience_years");
        });

        builder.Property(x => x.PhoneNumber)
            .HasConversion(
                phone => phone.Value,
                value => PhoneNumber.Create(value).Value
            )
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("phone");
        

        builder.Property(x => x.EmailAddress)
            .HasConversion(
                email => email.Value,
                value => Email.Create(value).Value
            )
            .IsRequired()
            .HasMaxLength(256)
            .HasColumnName("email");

        builder.OwnsMany(x => x.SocialNetworks, tb =>
        {
            tb.ToJson("social_networks");
            
            tb.Property(s => s.Name)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .IsRequired();

            tb.Property(s => s.Url)
                .HasMaxLength(Constants.MAX_MEDIUML_TEXT_LENGTH)
                .IsRequired();
        });

        builder.OwnsMany(x => x.DonationDetails, tb =>
        {
            // 1. Указываем JSON-формат хранения и имя колонки в snake_case
            tb.ToJson("donation_details");

            tb.Property(p => p.Name)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH) 
                .IsRequired();

            tb.Property(p => p.Description)
                .HasMaxLength(Constants.MAX_MEDIUML_TEXT_LENGTH) 
                .IsRequired();
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