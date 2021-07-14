using Agenda_NetCore5_MVC_Ajax.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agenda_NetCore5_MVC_Ajax.Controllers
{
    public class TarefasController : Controller
    {
        private readonly Contexto _contexto;

        public TarefasController(Contexto contexto)
        {
            _contexto = contexto;
        }
        public IActionResult Index()
        {
            return View(PegarDatas());
        }

        // Função dentro do Index -> "Para Pegar as Datas".
        private List<DatasViewModel> PegarDatas()
        {
            DateTime dataAtual = DateTime.Now;
            // Abaixo dada limite estipulada em 10 dias:
            DateTime dataLimite = DateTime.Now.AddDays(10);
            // Abaixo o contador:
            int qtdDias = 0;
            DatasViewModel data;
            List<DatasViewModel> listaDatas = new List<DatasViewModel>();

            while (dataAtual < dataLimite)
            {
                data = new DatasViewModel();
                data.Datas = dataAtual.ToShortDateString(); // Para pegar apenas a Data.
                data.Identificadores = "collapse" + dataAtual.ToShortDateString().Replace("/", ""); // Replace para substituir a barra por nada.
                listaDatas.Add(data);
                qtdDias = qtdDias + 1;
                dataAtual = DateTime.Now.AddDays(qtdDias);
            }
            return listaDatas;
        }

        [HttpGet]
        public IActionResult CriarTarefa(string dataTarefa)
        {
            Tarefa tarefa = new Tarefa
            {
               Data = dataTarefa
            };
            return View(tarefa);             
        }
        [HttpPost]
        public async Task<IActionResult> CriarTarefa (Tarefa tarefa)
        {
            if(ModelState.IsValid)
            {
                _contexto.Tarefas.Add(tarefa);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        [HttpGet]
        public async Task<IActionResult> AtualizarTarefa(int tarefaId)
        {
            Tarefa tarefa = await _contexto.Tarefas.FindAsync(tarefaId);

            if (tarefa == null)
                return NotFound();

            return View(tarefa);
        }

        [HttpPost] 
        public async Task<IActionResult> AtualizarTarefa(Tarefa tarefa)
        {
            if(ModelState.IsValid)
            {
                _contexto.Update(tarefa);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        // O Delete sera feito em Ajax
        [HttpPost]
        public async Task<JsonResult> ExcluirTarefa(int tarefaId)
        {
            Tarefa tarefa = await _contexto.Tarefas.FindAsync(tarefaId);
            _contexto.Tarefas.Remove(tarefa);
            await _contexto.SaveChangesAsync();
            return Json(true);
        }
    }      
} 