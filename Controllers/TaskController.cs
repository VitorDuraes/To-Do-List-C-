using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using To_Do_List.Models;
using To_Do_List.Context;

namespace To_Do_List.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {

        private readonly AgendaContext _context;

        public TaskController(AgendaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Tarefa tarefa)
        {
            tarefa.Status = tarefa.Status ?? "Pending";

            tarefa.CreateAt = DateTime.UtcNow;

            _context.Add(tarefa);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);


        }

        [HttpGet]
        public IActionResult ObterPorId()
        {
            var tarefa = _context.Tarefas.ToList();
            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Tarefa tarefa)
        {
            var tarefaAT = _context.Tarefas.Find(id);

            if (tarefaAT == null)
                return NotFound();

            if (tarefa.Status != null && tarefa.Status == "Completed")
            {
                tarefaAT.Status = "Completed";
            }
            tarefaAT.Title = tarefa.Title ?? tarefaAT.Title;
            tarefaAT.Description = tarefa.Description ?? tarefaAT.Description;

            tarefaAT.CreateAt = tarefaAT.CreateAt;

            _context.Tarefas.Update(tarefaAT);
            _context.SaveChanges();
            return Ok(tarefaAT);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var tarefaDlt = _context.Tarefas.Find(id);
            if (tarefaDlt == null)
                return NotFound();

            _context.Tarefas.Remove(tarefaDlt);
            _context.SaveChanges();
            return NoContent();
        }
    }
}