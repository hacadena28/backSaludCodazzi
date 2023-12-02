using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Ports;


namespace Domain.Services;

[DomainService]
public class UserService
{
    private readonly IGenericRepository<User> _userRepository;
    private readonly IGenericRepository<Doctor> _doctorRepository;
    private readonly IGenericRepository<Patient> _patientRepository;
    private readonly IGenericRepository<Admin> _adminRepository;

    public UserService(IGenericRepository<User> userRepository, IGenericRepository<Doctor> doctorRepository,
        IGenericRepository<Patient> patientRepository, IGenericRepository<Admin> adminRepository)
    {
        _userRepository = userRepository;
        _doctorRepository = doctorRepository;
        _patientRepository = patientRepository;
        _adminRepository = adminRepository;
    }

    public async Task CreateUser(User user)
    {
        await _userRepository.AddAsync(user);
    }

    public async Task<User> GetById(Guid userId)
    {
        return await _userRepository.GetByIdAsync(userId);
    }

    public async Task<IEnumerable<User>> GetUsersByRole(Role role)
    {
        return await _userRepository.GetAsync(
            filter: u => u.Role == role,
            orderBy: null,
            includeStringProperties: "Person",
            isTracking: false
        );
    }

    public async Task<User> GetUsersDoctorByDocumentNumber(string documentNumber)
    {
        var searchedDoctor = await _doctorRepository.GetPagedFilterAsync(page: 1, pageSize: 20,
            filter: d => d.DocumentNumber == documentNumber,
            orderBy: null,
            includeStringProperties: "",
            isTracking: false);

        if (searchedDoctor is null)
        {
            throw new UserNotExist(Messages.UserNotExist);
        }
        var searchedUser = await _userRepository.GetAsync(
            filter: u => u.PersonId == searchedDoctor.Records.FirstOrDefault().Id,
            orderBy: null,
            includeStringProperties: "Person",
            isTracking: false
        );

        return searchedUser.FirstOrDefault();
    }

    public async Task<User> GetUsersAdminByDocumentNumber(string documentNumber)
    {
        return (await _userRepository.GetAsync(x => x.Person.DocumentNumber == documentNumber,
                includeStringProperties: "Person"))
            .FirstOrDefault();
    }

    public async Task<User> GetUsersPatientByDocumentNumber(string documentNumber)
    {
        var searchedPatient = await _patientRepository.GetPagedFilterAsync(page: 1, pageSize: 20,
            filter: p => p.DocumentNumber == documentNumber,
            orderBy: null,
            includeStringProperties: "",
            isTracking: false);
        if (searchedPatient is null)
        {
            throw new UserNotExist(Messages.UserNotExist);
        }
        var searchedUser = await _userRepository.GetAsync(
            filter: u => u.PersonId == searchedPatient.Records.FirstOrDefault().Id,
            orderBy: null,
            includeStringProperties: "Person",
            isTracking: false
        );

        return searchedUser.FirstOrDefault();
    }

    public async Task<PagedResult<User>> GetUsersPaginationByRole(int page, int pageSize, Role role)
    {
        return await _userRepository.GetPagedFilterAsync(
            page,
            pageSize,
            filter: u => u.Role == role,
            orderBy: null,
            includeStringProperties: "Person",
            isTracking: false
        );
    }


    public async Task UpdateUser(Guid userId, string newPassword)
    {
        var userSearched = await _userRepository.GetByIdAsync(userId);
        _ = userSearched ?? throw new CoreBusinessException(Messages.AlredyExistException);
        if (newPassword != userSearched.Password)
        {
            userSearched.ChangePassword(newPassword);
        }
        else
        {
            throw new ThePasswordHasToBeDifferent(Messages.ThePasswordHasToBeDifferent);
        }

        await _userRepository.UpdateAsync(userSearched);
    }

    public async Task DeleteUser(User user)
    {
        await _userRepository.DeleteAsync(user);
    }
}