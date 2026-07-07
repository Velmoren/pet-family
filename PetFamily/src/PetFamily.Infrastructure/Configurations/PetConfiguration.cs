using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetFamily.Domain.Shared;
using PetFamily.Domain.SpeciesContext;
using PetFamily.Domain.ValueObjects;
using PetFamily.Domain.VolunteerContext;

namespace PetFamily.Infrastructure.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("Pets");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => PetId.Create(value)
            )
            .HasColumnName("id");

        builder.Property(x => x.VolunteerId)
            .HasConversion(
                id => id.Value,
                value => VolunteerId.Create(value)
            )
            .HasColumnName("volunteer_id")
            .IsRequired();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
            .HasColumnName("name");


        builder.Property(x => x.Description)
            .IsRequired(false)
            .HasMaxLength(Constants.MAX_HIGHT_TEXT_LENGTH)
            .HasColumnName("description");

        builder.ComplexProperty(x => x.LocationAddress, db =>
        {
            db.Property(a => a.Country)
                .HasMaxLength(100)
                .HasColumnName("address_country");

            db.Property(a => a.City)
                .HasMaxLength(100)
                .HasColumnName("address_city");

            db.Property(a => a.Street)
                .HasMaxLength(150)
                .HasColumnName("address_street");

            db.Property(a => a.House)
                .HasMaxLength(20)
                .HasColumnName("address_house");

            db.Property(a => a.Apartment)
                .HasMaxLength(20)
                .IsRequired(false)
                .HasColumnName("address_apartment");

            db.Property(a => a.PostalCode)
                .HasMaxLength(20)
                .IsRequired(false)
                .HasColumnName("address_postal_code");
        });

        builder.Property(x => x.ContactPhone)
            .HasConversion(
                phone => phone.Value,
                value => new PhoneNumber(value)
            )
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("contact_phone");

        builder.Property(x => x.SpeciesId)
            .HasConversion(
                id => id.Value,
                value => SpeciesId.Create(value)
            )
            .IsRequired()
            .HasColumnName("species_id");

        builder.Property(x => x.BreedId)
            .HasConversion(
                id => id.Value,
                value => BreedId.Create(value)
            )
            .IsRequired()
            .HasColumnName("breed_id");

        builder.Property(x => x.HealthInfo)
            .HasMaxLength(2000)
            .IsRequired(false)
            .HasColumnName("health_info");

        builder.Property(x => x.HelpStatus)
            .HasConversion<string>()
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("help_status");

        builder.Property(x => x.BirthDate)
            .IsRequired()
            .HasColumnName("birth_date");

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(x => x.Weight)
            .IsRequired()
            .HasColumnType("decimal(5,2)")
            .HasColumnName("weight");


        builder.Property(x => x.Height)
            .IsRequired()
            .HasColumnType("decimal(5,2)")
            .HasColumnName("height");


        builder.Property(x => x.IsNeutered)
            .IsRequired()
            .HasColumnName("is_neutered");

        builder.Property(x => x.IsVaccinated)
            .IsRequired()
            .HasColumnName("is_vaccinated");

        builder.OwnsMany(x => x.DonationDetails, navigationBuilder => { navigationBuilder.ToJson(); });

        builder.OwnsMany(x => x.PetPhotos, photoBuilder =>
        {
            photoBuilder.ToJson("pet_photos");

            photoBuilder.Property(p => p.IsMain)
                .HasJsonPropertyName("is_main");

            photoBuilder.OwnsOne(p => p.File, fileBuilder =>
            {
                fileBuilder.Property(f => f.StoragePath)
                    .HasJsonPropertyName("storage_path");
            });
        });

        builder.Metadata
            .FindNavigation(nameof(Pet.PetPhotos))?
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}