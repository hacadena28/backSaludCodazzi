using Domain.Entities;
using Domain.Tests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Configuration;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("User", SchemaNames.Base);
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
            .IsRequired();
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
        builder
            .HasOne(x => x.Eps)
            .WithOne()
            .IsRequired();
    }
}

public class MedicalHistoryConfig : IEntityTypeConfiguration<MedicalHistory>
{
    public void Configure(EntityTypeBuilder<MedicalHistory> builder)
    {
        builder
            .ToTable("MedicalHistory", SchemaNames.Base);
        builder
            .Property(x => x.Date)
            .IsRequired()
            .HasMaxLength(20);
        builder
            .Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(255);
        builder
            .Property(x => x.Diagnosis)
            .IsRequired()
            .HasMaxLength(255);
        builder
            .Property(x => x.Treatment)
            .IsRequired()
            .HasMaxLength(255);
        builder
            .Property(x => x.Date)
            .IsRequired()
            .HasMaxLength(20);
        builder
            .HasOne(x => x.Doctor)
            .WithOne()
            .IsRequired();
        builder
            .HasOne(x => x.Patient)
            .WithOne()
            .IsRequired();
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

public class DoctortConfig : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder
            .ToTable("Doctor", SchemaNames.Base);
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
            .IsRequired();
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
        builder
            .Property(x => x.Specialization)
            .IsRequired()
            .HasMaxLength(40);
    }
}

public class AppointmentConfig : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder
            .ToTable("Appointment", SchemaNames.Base);

        builder
            .Property(x => x.Date)
            .IsRequired()
            .HasMaxLength(20);
        builder
            .Property(x => x.State)
            .IsRequired()
            .HasMaxLength(20);
        builder
            .Property(x => x.Type)
            .IsRequired()
            .HasMaxLength(20);
        builder
            .Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(255);
        builder
            .HasOne(x => x.Doctor)
            .WithOne()
            .IsRequired();
        builder
            .HasOne(x => x.Patient)
            .WithOne()
            .IsRequired();
    }
}