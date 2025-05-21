// Models/ContactViewModel.cs
using System.ComponentModel.DataAnnotations;

namespace MiProyectoPortable.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [Phone(ErrorMessage = "Introduce un número válido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Introduce un correo válido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El mensaje no puede estar vacío")]
        public string Mensaje { get; set; }
    }
}
