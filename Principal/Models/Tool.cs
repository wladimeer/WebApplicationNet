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

        [Required(ErrorMessage = "Ingresa un Nombre.")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Verifica el Nombre.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Ingresa una Descripción.")]
        [StringLength(90, MinimumLength = 5, ErrorMessage = "Verifica la Descripción.")]
        public string description { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
