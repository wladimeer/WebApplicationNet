namespace Principal.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Worker
    {
        public Worker()
        {
            Assignments = new HashSet<Assignment>();
        }

        public int id { get; set; }

        [Required(ErrorMessage = "Ingresa un Nombre Valido.")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "El Nombre Debe Estar en un Rango de 3 a 10 Caracteres.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Ingresa Apellidos Validos.")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Los Apellidos Deben Estar en un Rango de 5 a 15 Caracteres.")]
        public string lastnames { get; set; }

        [Required(ErrorMessage = "Ingresa un Correo Valido.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El Correo Debe Estar en un Rango de 3 a 30 Caracteres.")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Verifica el Formato del Correo.")]
        public string email { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
