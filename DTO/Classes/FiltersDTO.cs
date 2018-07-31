using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApplication.DTO.Classes
{
    public class FiltersDTO
    {
        [DisplayName("Data Inicial")]
        public DateTime? StartDate { get; set; }

        [DisplayName("Data Final")]
        public DateTime? EndDate { get; set; }
    }
}
