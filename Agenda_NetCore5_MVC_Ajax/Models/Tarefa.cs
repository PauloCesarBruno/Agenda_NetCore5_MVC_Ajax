using System.ComponentModel.DataAnnotations;

namespace Agenda_NetCore5_MVC_Ajax.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }

        [Required (ErrorMessage ="{0} é Obrigatório !")]
        [StringLength(50, ErrorMessage ="Campo até 50 caracteres !")]
        [Display(Name ="Nome")]
        public string Nome { get; set; }

        [Display(Name = "Data")]
        public string Data { get; set; }

        [Required(ErrorMessage = "{0} é Obrigatório !")]
        [Display(Name = "Horário")]
        [DataType(DataType.Time)]   // Vou usar Hora no DataPicker...
        public string Horario { get; set; }
    }
}
