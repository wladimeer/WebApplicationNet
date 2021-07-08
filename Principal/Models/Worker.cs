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

        [Required(ErrorMessage = "Ingresa un Nombre.")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Verifica el Nombre.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Ingresa unos Apellidos.")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Verifica los Apellidos.")]
        public string lastnames { get; set; }

        [Required(ErrorMessage = "Ingresa un Correo.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Verifica el Correo.")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Verifica el Formato.")]
        public string email { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
