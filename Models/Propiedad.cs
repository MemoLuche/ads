// Models/Propiedad.cs
using System; // Necesario para DateTime
using System.ComponentModel.DataAnnotations; // Necesario para [Key] y otros atributos

namespace MiProyectoPortable.Models // <--- ESTA LÍNEA ES LA QUE FALTABA ENVOLVIENDO LA CLASE
{
    public class Propiedad
    {
        [Key] // Indica que Id es la clave primaria
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(100, ErrorMessage = "El título no puede exceder los 100 caracteres.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [DataType(DataType.Currency)]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El tipo de operación es obligatorio (Venta/Renta).")]
        public string TipoOperacion { get; set; } // "Venta", "Renta"

        [Required(ErrorMessage = "El tipo de propiedad es obligatorio.")]
        public string TipoPropiedad { get; set; } // "Casa", "Departamento", "Terreno", "Local Comercial", etc.

        [Required(ErrorMessage = "La ubicación es obligatoria.")]
        public string Ubicacion { get; set; } // Podría ser más detallado (Ciudad, Barrio, etc.)

        public int? Habitaciones { get; set; } // Nullable por si no aplica (ej. Terreno)
        public int? Banos { get; set; }        // Nullable. Si necesitas "2.5 baños", este tipo debería ser double? o decimal? y la columna en BD REAL.
        public int? MetrosCuadrados { get; set; } // Nullable
        public int? Cocheras { get; set; }        // Nullable

        public string RutaImagenPrincipal { get; set; } // Ejemplo: "/images/propiedades/casa-juriquilla.jpg"
        // Podrías tener una lista de rutas de imágenes si son varias

        // Cuidado con inicializadores dinámicos si usas HasData creando nuevas instancias de Propiedad sin setear esta fecha.
        // Para el uso actual (donde HasData sí la setea), está bien.
        public DateTime FechaPublicacion { get; set; } = DateTime.UtcNow;

        public bool EsDestacada { get; set; } = false; // Para marcar propiedades como destacadas
    }
} // <--- Y ESTA LLAVE DE CIERRE PARA EL NAMESPACE