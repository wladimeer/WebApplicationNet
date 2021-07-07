namespace Principal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tool
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Ingresa un Nombre.")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Verifica el Nombre.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Ingresa una Descripción.")]
        [StringLength(90, MinimumLength = 5, ErrorMessage = "Verifica la Descripción.")]
        public string description { get; set; }
    }
}
