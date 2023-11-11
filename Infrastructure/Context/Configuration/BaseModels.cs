using Domain.Entities;
using Domain.Tests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Configuration;

public class VoterConfig : IEntityTypeConfiguration<Voter>
{
    public void Configure(EntityTypeBuilder<Voter> builder)
    {
        builder
            .ToTable("Voter", SchemaNames.Base);

        builder
            .Property(x => x.Origin)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(x => x.Nid)
            .HasMaxLength(50);
    }
}

public class EpsConfig : IEntityTypeConfiguration<Eps>
{
    public void Configure(EntityTypeBuilder<Eps> builder)
    {
        builder
            .ToTable("Eps", SchemaNames.Base);

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(x => x.State)
            .IsRequired()
            .HasMaxLength(10);
    }
}

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("User", SchemaNames.Base);

        builder
            .Property(x => x.Identification)
            .IsRequired()
            .HasMaxLength(10);

        builder
            .Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(50);
        builder
            .Property(x => x.Role)
            .IsRequired()
            .HasMaxLength(10);
        builder
            .HasOne(x => x.Person)
            .WithOne()
            .HasForeignKey<User>(u => u.PersonId)
            .IsRequired();
    }
}

public class PatientConfig : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder
            .ToTable("Patient", SchemaNames.Base);

        builder
            .Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(40);

        builder
            .Property(x => x.SecondName)
            .IsRequired()
            .HasMaxLength(40);

        builder
            .Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(40);

        builder
            .Property(x => x.SecondLastName)
            .IsRequired()
            .HasMaxLength(40);

        builder
            .Property(x => x.DocumentType)
            .IsRequired()
            .HasMaxLength(20);
        builder
            .Property(x => x.DocumentNumber)
            .IsRequired()
            .HasMaxLength(20);

        builder
            .Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(40);
        builder
            .Property(x => x.Phone)
            .IsRequired()
            .HasMaxLength(20);
        builder
            .Property(x => x.Address)
            .IsRequired()
            .HasMaxLength(40);
        builder
            .Property(x => x.Birthdate)
            .IsRequired()
            .HasMaxLength(20);
    }
}