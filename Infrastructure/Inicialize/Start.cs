using Domain.Entities;
using Domain.Enums;
using Infrastructure.Context;

namespace Infrastructure.Inicialize
{
    public class Start
    {
        private readonly PersistenceContext _context;

        public Start(PersistenceContext context)
        {
            _context = context;
        }

        public void Inicializar()
        {
            if (!_context.Users.Any(u => u.Role == Role.Admin))
            {
                var defaultAdmin = new Admin
                (
                    "User",
                    "Admin",
                    "User",
                    "Admin",
                    TypeDocument.IdentificationCard,
                    "123456789",
                    "adminDefault@mail.com",
                    "123456789",
                    "Address",
                    DateTime.Now.AddYears(-18)
                );

                var defaultUser = new User
                (
                    "adminDefault",
                    Role.Admin,
                    defaultAdmin
                );
                _context.Users.Add(defaultUser);
            }

            if (!_context.Users.Any(u => u.Role == Role.Doctor))
            {
                var defaultDoctor = new Doctor
                (
                    "María",
                    "Isabel",
                    "González",
                    "López",
                    TypeDocument.IdentificationCard,
                    "123456789",
                    "mariagonzalez@example.com",
                    "987654321",
                    "Calle 123, Ciudad",
                    new DateTime(1980, 5, 15),
                    "Odontología general"
                );

                var defaultUser = new User
                (
                    "mariagonzalez",
                    Role.Doctor,
                    defaultDoctor
                );

                _context.Users.Add(defaultUser);
            }

            if (!_context.Users.Any(u => u.Role == Role.Patient))
            {
                var defaultPatient = new Patient
                (
                    "Carlos",
                    "Andrés",
                    "Martínez",
                    "Gómez",
                    TypeDocument.IdentificationCard,
                    "1007824248",
                    "carlosmartinez@example.com",
                    "555-123-456",
                    "Avenida Principal, Ciudad",
                    new DateTime(1992, 10, 8),
                    Guid.Parse("08eefb10-7759-4896-86cd-08dbf27f60b6")
                );

                var defaultUser = new User
                (
                    "carlosmartinez",
                    Role.Patient,
                    defaultPatient
                );

                _context.Users.Add(defaultUser);
            }


            if (!_context.Eps.Any(u => u.State == EpsState.Active))
            {
                Eps[] defaultEpsArray = new Eps[]
                {
                    new Eps("Salud Total"),
                    new Eps("Nueva EPS"),
                    new Eps("EPS Sura"),
                    new Eps("Sanitas EPS"),
                    new Eps("Coomeva EPS"),
                    new Eps("Aliansalud EPS"),
                    new Eps("Cajacopi EPS"),
                    new Eps("Compensar EPS"),
                    new Eps("SOS EPS"),
                    new Eps("Cruz Blanca EPS")
                };

                foreach (var eps in defaultEpsArray)
                {
                    _context.Eps.Add(eps);
                }
            }


            _context.SaveChanges();
        }
    }
}