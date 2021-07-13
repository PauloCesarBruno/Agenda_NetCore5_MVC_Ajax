using Agenda_NetCore5_MVC_Ajax.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda_NetCore5_MVC_Ajax.ViewComponents
{
    public class ListaTarefasViewComponent : ViewComponent
    {
        private readonly Contexto _contexto;

        public ListaTarefasViewComponent(Contexto contexto)
        {
            _contexto = contexto;
        }

        // Criação do método Invoke
        public async Task<IViewComponentResult> InvokeAsync(string data)
        {
            /* Foi criada manualmente na pasta "Shared" uma pasta "Components"
            e dentro da pasta "Components" uma pasta chamada "ListaTarefas", e,
            dentro dela foi criada uma View (Default -> RazorView_Empty). */
            return View(await _contexto.Tarefas
                .OrderBy(t => t.Horario).Where(t => t.Data == data).ToListAsync());
        }
    }
}
