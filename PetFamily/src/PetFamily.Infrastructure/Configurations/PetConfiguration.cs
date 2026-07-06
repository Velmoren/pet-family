using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers;

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
            );

        builder.Property(x => x.VolunteerId)
            .IsRequired();
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
        
        builder.Property(x => x.Description)
            .IsRequired(false)
            .HasMaxLength(Constants.MAX_HIGHT_TEXT_LENGTH);
        
        builder.Property(x => x.Species);

        builder.Property(x => x.Breed);

        builder.Property(x => x.HealthInfo);
        
        builder.Property(x => x.LocationAddress);
        
        builder.Property(x => x.ContactPhone);
        
        builder.Property(x => x.HelpStatus);
        
        builder.Property(x => x.BirthDate);
        
        builder.Property(x => x.CreatedAt);
        
        builder.Property(x => x.Weight);
        
        builder.Property(x => x.Height);
        
        builder.Property(x => x.IsNeutered);
        
        builder.Property(x => x.IsVaccinated);
    }
}