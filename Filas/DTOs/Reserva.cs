using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filas.DTOs
{
    public class Reserva
    {
        [Key]
        public int ID_RESERVA { get; set; }
        public DateTime HORA_RESERVA { get; set; }
        [BindProperty]
        public string NOME_RESERVA { get; set; }

        public int ID_MESA { get; set; }
        [BindProperty]
        public int QTD_PESSOAS { get; set; }
        public bool ENTROU { get; set; }

        public Reserva()
        {
            NOME_RESERVA = "";
            HORA_RESERVA = DateTime.Now;
            ENTROU = false;
        }

        [ForeignKey("ID_MESA")]
        public Mesa Mesa { get; set; }
    }
}
