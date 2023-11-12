// using Domain.Entities;
// using Domain.Enums;
//
// namespace Domain.Tests;
//
// public class UserTest
// {
//     private User _user;
//     private string _identification = "1007824012";
//     private string _password = "1007824012";
//     private Role _rol = Role.Patient;
//     private Role _rol2 = Role.Doctor;
//
//     [Fact]
//     public void ChangePassword()
//     {
//         _user = new UserBuilder()
//             .WithPassword(_password)
//             .WithRole(_rol)
//             .Build();
//         _user.ChangePassword();
//         Assert.Equal("1007824011",_user.Password);
//     } 
//     [Fact]
//     public void RecoveryPassword()
//     {
//         _user = new UserBuilder()
//             .WithPassword(_password)
//             .WithRole(_rol)
//             .Build();
//         var pass = _user.RecoveryPassword();
//         Assert.Equal("1007824012",pass);
//     }
// }
//
