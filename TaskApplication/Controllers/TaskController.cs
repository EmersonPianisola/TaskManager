using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskApplication.DTO.Classes;

namespace TaskApplication.Controllers
{
    public class TaskController : Controller
    {
        TaskApplication.BLL.Classes.TaskBLL objTaskBLL = new TaskApplication.BLL.Classes.TaskBLL();

        // GET: Task
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(TaskDTO pTask)
        {
            var objReturn = objTaskBLL.Search(pTask);

            return PartialView("PartialTaskTable", objReturn);
        }

        public ActionResult Update(TaskDTO pTask)
        {
            if (objTaskBLL.Update(pTask))
            {
                //Sucesso em atualizar a Task, retornar para a tela de inicio
                return View("Index");
            }
            else
            {
                // Erro ao atualizar a Task, direcionar para a página de erro
                return View("Erro");
            }
        }

        public ActionResult Delete(int pTaskID)
        {
            if (objTaskBLL.Delete(pTaskID))
            {
                //Sucesso em deletar a Task, retornar para a tela de inicio
                return View("Index");
            }
            else
            {
                // Erro ao atualizar a Task, direcionar para a página de erro
                return View("Erro");
            }
        }

        public ActionResult Save(TaskDTO pTask)
        {
            if (objTaskBLL.Save(pTask))
            {
                //Sucesso em salvar a Task, retornar para a tela de inicio
                return View("Index");
            }
            else
            {
                // Erro ao atualizar a Task, direcionar para a página de erro
                return View("Erro");
            }
        }

    }
}