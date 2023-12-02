using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Admins.Commands.AdminUpdate
{
    public class AdminUpdateCommandHandler : IRequestHandler<AdminUpdateCommand,Unit>
    {
        private readonly AdminService _adminService;
        private readonly IGenericRepository<Admin> _adminRepository;

        public AdminUpdateCommandHandler(AdminService adminService,
            IGenericRepository<Admin> adminRepository)
        {
            _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
            _adminRepository = adminRepository ?? throw new ArgumentNullException(nameof(adminRepository));
        }

        public async Task<Unit> Handle(AdminUpdateCommand request, CancellationToken cancellationToken)
        {
            await _adminService.UpdateAdmin(request.Id,
                request.FirstName?.Trim(),
                request.SecondName?.Trim(),
                request.LastName?.Trim(),
                request.SecondLastName?.Trim(),
                request.Email?.Trim(),
                request.Phone?.Trim(),
                request.Address?.Trim()
            );

            return Unit.Value;
        }
    }
}