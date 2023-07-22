using Application.Services.Abstraction.UsersServices;

namespace Application.Services.Implementation.UsersServices
{
    public class UserService : IUserSerivice
    {
        public int CalcularEdad(DateTime fechaNacimiento)
        {
            DateTime fechaActual = DateTime.Today;
            int edad = fechaActual.Year - fechaNacimiento.Year;
            if (fechaActual.Month < fechaNacimiento.Month || (fechaActual.Month == fechaNacimiento.Month && fechaActual.Day < fechaNacimiento.Day))
            {
                edad--;
            }
            return edad;
        }
    }
}
