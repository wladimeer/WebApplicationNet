namespace Principal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Assign")]
    public partial class Assign
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Selecciona una Herramienta.")]
        public int tool { get; set; }

        [Required(ErrorMessage = "Selecciona un Trabajador.")]
        public int worker { get; set; }

        [Required(ErrorMessage = "Selecciona Fecha de Entrega.")]
        [DataType(DataType.Date, ErrorMessage = "Verifica la Fecha de Entrega.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime delivery { get; set; }

        [Required(ErrorMessage = "Selecciona Fecha de Retiro.")]
        [DataType(DataType.Date, ErrorMessage = "Verifica la Fecha de Retiro.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime retirement { get; set; }

        [Required(ErrorMessage = "Ingresa una Descripción.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Verifica la Descripción.")]
        public string description { get; set; }
    }
}
