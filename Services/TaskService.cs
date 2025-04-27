using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using To_Do_List.Context;
using To_Do_List.DTOs;
using To_Do_List.Models;

namespace To_Do_List.Services
{
    public class TaskService : ITaskInterface
    {

        private readonly AgendaContext _context;

        public TaskService(AgendaContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<Tarefa>>> AtualizarTask(TaskEdicaoDTO taskEdicaoDTO)
        {
            ResponseModel<List<Tarefa>> response = new ResponseModel<List<Tarefa>>();
            try
            {
                var tarefa = _context.Tarefas.FirstOrDefault(tarefaBanco => tarefaBanco.Id == taskEdicaoDTO.Id);
                if (tarefa == null)
                {
                    response.Mensagem = "Tarefa não encontrada.";
                    return response;
                }

                if (taskEdicaoDTO.Status.ToLower() != "pending" && taskEdicaoDTO.Status.ToLower() != "completed")
                {
                    response.Status = false;
                    response.Mensagem = "Status inválido. Permitido apenas 'Pending' ou 'Completed'.";
                    return response;
                }
                tarefa.Status = taskEdicaoDTO.Status;

                _context.Update(tarefa);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Tarefas.ToListAsync();
                response.Mensagem = "Tarefa atualizada com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<List<Tarefa>>> CriarTask(TaskCriacaoDTO taskCriacaoDTO)
        {
            ResponseModel<List<Tarefa>> response = new ResponseModel<List<Tarefa>>();
            try
            {
                var tarefa = new Tarefa()
                {
                    Title = taskCriacaoDTO.Title,
                    Description = taskCriacaoDTO.Description,
                    Status = "Pending",
                    CreateAt = DateTime.Now 
                };

                _context.Add(tarefa);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Tarefas.ToListAsync();
                response.Mensagem = "Tarefa adicionada com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<List<Tarefa>>> DeletarTask(int idTask)
        {
            ResponseModel<List<Tarefa>> response = new ResponseModel<List<Tarefa>>();
            try
            {
                var tarefa = _context.Tarefas.FirstOrDefault(tarefaBanco => tarefaBanco.Id == idTask);
                if (tarefa == null)
                {
                    response.Mensagem = "Tarefa não encontrada.";
                    return response;
                }
                _context.Remove(tarefa);
                await _context.SaveChangesAsync();
                response.Dados = await _context.Tarefas.ToListAsync();
                response.Mensagem = "Tarefa deletada com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<Tarefa>> ListarTaskPorId(int idTask)
        {
            ResponseModel<Tarefa> response = new ResponseModel<Tarefa>();
            try
            {
                var tarefa = await _context.Tarefas.FindAsync(idTask);
                if (tarefa == null)
                {
                    response.Status = false;
                    response.Mensagem = "Tarefa não encontrada.";
                    return response;
                }
                response.Dados = tarefa;
                response.Mensagem = "Tarefa encontrada com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<List<Tarefa>>> ListarTasks()
        {
            ResponseModel<List<Tarefa>> response = new ResponseModel<List<Tarefa>>();
            try
            {
                var tarefas = await _context.Tarefas.ToListAsync();
                response.Dados = tarefas;
                response.Mensagem = "Tarefas listados com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }


        }

    }
}
