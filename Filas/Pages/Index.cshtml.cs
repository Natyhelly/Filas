using Filas.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Filas.Pages
{
    public class IndexModel : PageModel
    {
        /*Abre o model da Index com o database e a lista de reserva "preenchidas"*/
        public IndexModel()
        {
            FilasDb = new FilasDbContext();
            ReservaList = new List<Reserva>();
        }
        public FilasDbContext FilasDb { get; set; }
        public List<Reserva> ReservaList { get; set; } //variavel publica, q da pra inserir (set) e consultar (get)

        public PageResult OnGet()
        {
            ReservaList = FilasDb.Reservas.Where(x => x.ENTROU == false).ToList();
            ViewData["ListItemsMesa"] = new SelectList(ListItemsMesa(), "Value", "Text");

            return Page();
        }

        public ActionResult OnPost(Reserva reserva)
        {
            var dsMesa = getMesa(reserva.QTD_PESSOAS);
            var mesaReserva = FilasDb.Mesas.FirstOrDefault(x => x.DS_MESA == dsMesa);

            if (mesaReserva == null)
            {
                var novaMesa = new Mesa();
                novaMesa.DS_MESA = dsMesa;

                FilasDb.Add(novaMesa);
                FilasDb.SaveChanges();

                mesaReserva = novaMesa;
            }

            reserva.ID_MESA = mesaReserva.ID_MESA;

            //Adiciona na instância Reservas do banco de dados o que vem do parâmetro do OnPost (reserva)
            FilasDb.Reservas.Add(reserva);
            //Salva as mudanças
            FilasDb.SaveChanges();
            //Retorna a Index com as mudanças feitas
            return RedirectToPage("Index");
        }

        public string getMesa(int QTD_PESSOAS)
        {
            switch (QTD_PESSOAS)
            {
                case 1: return "Um";
                case 2: return "Dois";
                case 3: return "Três";
                case 4: return "Quatro";
                case 5: return "Cinco";
                case 6: return "Seis";
                case 7: return "Sete";
                case 8: return "Oito";
                case 9: return "Nove";
                case 10: return "Dez";

                default: return "10+";
            }
        }

        public ActionResult OnPostEntrar(int ID_RESERVA)
        {
            var reserva = FilasDb.Reservas.Find(ID_RESERVA);
            if (reserva != null)
            {
                reserva.ENTROU = true;
                FilasDb.SaveChanges();
            }
            return RedirectToPage("Index");
        }

        public IEnumerable<SelectListItem> ListItemsMesa()
        {
            var mesas = FilasDb.Mesas.ToList();

            IList<SelectListItem> items = new List<SelectListItem>();
            
            foreach (var item in mesas)
            {
                items.Add(new SelectListItem { Value = item.ID_MESA.ToString(), Text = item.DS_MESA });
            }
            return items;
        }

    }

}