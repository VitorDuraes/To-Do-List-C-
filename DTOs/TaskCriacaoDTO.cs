using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace To_Do_List.DTOs
{
    public class TaskCriacaoDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } = "Pending"; // Define o status fixo
    }
}