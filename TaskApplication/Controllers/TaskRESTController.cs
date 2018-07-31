using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskApplication.DTO.Classes;

namespace TaskApplication.Controllers
{
    public class TaskRESTController : ApiController
    {
        TaskApplication.BLL.Classes.TaskBLL objTaskBLL = new TaskApplication.BLL.Classes.TaskBLL();

        // GET: api/TaskREST
        //[AcceptVerbs("GET")]
        public IEnumerable<TaskDTO> Get()
        {
            return objTaskBLL.Search(new TaskDTO() {});
        }

        // GET: api/TaskREST/5
        //[AcceptVerbs("GET")]
        public TaskDTO Get(int id)
        {
            return objTaskBLL.Get(id);
        }

        // POST: api/TaskREST
        //[AcceptVerbs("POST")]
        public void Post(TaskDTO pTask)
        {
            objTaskBLL.Save(pTask);
        }

        // PUT: api/TaskREST/5
        //[AcceptVerbs("PUT")]
        public void Put(TaskDTO pTask)
        {
            //Também poderia utilizar o Save
            objTaskBLL.Update(pTask);
        }

        // DELETE: api/TaskREST/5
        //[AcceptVerbs("DELETE")]
        public void Delete(int id)
        {
            objTaskBLL.Delete(id);
        }
    }
}
