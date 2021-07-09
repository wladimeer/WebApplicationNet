namespace Principal.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Assignment
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Selecciona una Herramienta Valida.")]
        public int tool_id { get; set; }

        [Required(ErrorMessage = "Selecciona un Trabajador Valido.")]
        public int worker_id { get; set; }

        [Required(ErrorMessage = "Ingresa una Fecha de Entrega Valida.")]
        [DataType(DataType.Date, ErrorMessage = "Verifica el Formato de Fecha.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime delivery { get; set; }

        [Required(ErrorMessage = "Ingresa una Fecha de Retiro Valida.")]
        [DataType(DataType.Date, ErrorMessage = "Verifica el Formato de Fecha.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime retirement { get; set; }

        [Required(ErrorMessage = "Ingresa una Descripción.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "La Descripción Debe Estar en un Rango de 5 a 100 Caracteres.")]
        public string description { get; set; }

        public virtual Tool Tool { get; set; }

        public virtual Worker Worker { get; set; }
    }
}
