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
                    DateTime.UtcNow
                );

                var defaultUser = new User
                (
                    "adminDefault",
                    Role.Admin,
                    defaultAdmin
                );
                _context.Users.Add(defaultUser);
                _context.SaveChanges();
            }
        }
    }
}