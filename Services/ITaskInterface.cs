using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using To_Do_List.DTOs;
using To_Do_List.Models;

namespace To_Do_List.Services
{
    public interface ITaskInterface
    {
        Task<ResponseModel<List<Tarefa>>> CriarTask(TaskCriacaoDTO taskCriacaoDTO);
        Task<ResponseModel<List<Tarefa>>> AtualizarTask(TaskEdicaoDTO taskEdicaoDTO);
        Task<ResponseModel<List<Tarefa>>> AlterarStatus(int id, StatusDTO statusDTO);
        Task<ResponseModel<List<Tarefa>>> DeletarTask(int idTask);
        Task<ResponseModel<List<Tarefa>>> ListarTasks();
        Task<ResponseModel<Tarefa>> ListarTaskPorId(int idTask);

    }
}