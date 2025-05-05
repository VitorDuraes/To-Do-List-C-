using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace To_Do_List.DTOs
{
    public class StatusDTO
    {
        public int Id { get; set; } // ID da tarefa a ser atualizada
        public string Status { get; set; } // "pending" ou "completed"

    }
}