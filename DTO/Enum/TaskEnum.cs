using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApplication.DTO.Enum
{
    public class TaskEnum
    {
        public enum Status
        {
            Ativo = 1,
            Concluido = 2,
            Excluido = 3,
        }

        public enum Operation
        {
            Create = 1,
            Update = 2,
            Delete = 3
        }

    }
}
