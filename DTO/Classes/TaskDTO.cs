using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApplication.DTO.Classes;
using TaskApplication.DTO.Enum;

namespace TaskApplication.DTO.Classes
{
    public class TaskDTO : FiltersDTO
    {
        public int TaskID { get; set; }
        public DateTime DateCreation { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskEnum.Status Status { get; set; }
    }
}
