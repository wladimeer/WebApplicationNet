namespace Principal.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Tool
    {
        public Tool()
        {
            Assignments = new HashSet<Assignment>();
        }

        public int id { get; set; }

        [Required(ErrorMessage = "Ingresa un Nombre Valido.")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "El Nombre Debe Estar en un Rango de 3 a 10 Caracteres.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Ingresa una Descripción Valida.")]
        [StringLength(90, MinimumLength = 5, ErrorMessage = "La Descripción Debe Estar en un Rango de 5 a 90 Caracteres.")]
        public string description { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
