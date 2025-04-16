using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using To_Do_List.Models;
using To_Do_List.Context;
using To_Do_List.DTOs;
using To_Do_List.Services;

namespace To_Do_List.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {

        private readonly ITaskInterface _taskInterface;
        public TaskController(ITaskInterface taskInterface)
        {
            _taskInterface = taskInterface;
        }

        [HttpPost("CriarTarefas")]
        public async Task<ActionResult<ResponseModel<List<Tarefa>>>> CriarTask(TaskCriacaoDTO taskCriacaoDTO)
        {
            var tarefas = await _taskInterface.CriarTask(taskCriacaoDTO);
            return Ok(tarefas);
        }

        [HttpGet("ListarTarefas")]
        public async Task<ActionResult<ResponseModel<List<Tarefa>>>> ListarTasks()
        {
            var tarefas = await _taskInterface.ListarTasks();
            return Ok(tarefas);
        }

        [HttpGet("ListarTarefas/{idtask}")]
        public async Task<ActionResult<ResponseModel<Tarefa>>> ListarTaskPorId(int idtask)
        {
            var tarefa = await _taskInterface.ListarTaskPorId(idtask);
            return Ok(tarefa);
        }

        [HttpPut("AtualizarTarefa/{idtask}")]
        public async Task<ActionResult<ResponseModel<List<Tarefa>>>> AtualizarTask(int idtask, TaskEdicaoDTO taskEdicaoDTO)
        {
            var tarefas = await _taskInterface.AtualizarTask(taskEdicaoDTO);
            return Ok(tarefas);
        }


        [HttpDelete("DeletarTarefa/{idtask}")]
        public async Task<ActionResult<ResponseModel<List<Tarefa>>>> DeletarTask(int idtask)
        {
            var tarefas = await _taskInterface.DeletarTask(idtask);
            return Ok(tarefas);
        }

    }
}