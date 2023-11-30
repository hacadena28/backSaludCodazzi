using Microsoft.AspNetCore.Identity;


namespace Infrastructure.Context.Configuration
{
    public class AplicationUser:IdentityUser

    {
        public string Nombre{ get; set; }
        public string Apellido{ get; set; }

    }

}
