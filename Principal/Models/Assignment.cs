namespace Principal.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Assignment
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Selecciona una Herramienta.")]
        public int tool_id { get; set; }

        [Required(ErrorMessage = "Selecciona un Trabajador.")]
        public int worker_id { get; set; }

        [Required(ErrorMessage = "Selecciona Fecha de Entrega.")]
        [DataType(DataType.Date, ErrorMessage = "Verifica el Formato de Fecha.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime delivery { get; set; }

        [Required(ErrorMessage = "Selecciona Fecha de Retiro.")]
        [DataType(DataType.Date, ErrorMessage = "Verifica el Formato de Fecha.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime retirement { get; set; }

        [Required(ErrorMessage = "Ingresa una Descripción.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Verifica la Descripción.")]
        public string description { get; set; }

        public virtual Tool Tool { get; set; }

        public virtual Worker Worker { get; set; }
    }
}
