using System.ComponentModel.DataAnnotations;

namespace Filas.DTOs
{
    public class Mesa
    {
        [Key]
        public int ID_MESA { get; set; }
        public string DS_MESA { get; set; }

        public Mesa()
        {
            DS_MESA = "";
        }
    }
}
