using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace To_Do_List.DTOs
{
    public class TaskEdicaoDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public string Status { get; set; }

    }
}