using DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApplication.DAL.Classes;
using TaskApplication.DTO.Classes;
using TaskApplication.DTO.Enum;

namespace TaskApplication.BLL.Classes
{
    public class TaskBLL
    {
        TaskDAL objTaskDAL = new TaskDAL();

        /// <summary>
        /// Cria uma nova Task
        /// </summary>
        /// <param name="pTask"></param>
        public bool Save(TaskDTO pTask)
        {
            try
            {
                if (pTask.TaskID == 0)
                {
                    //Cria uma nova Task
                    TASK objTask = new TASK()
                    {
                        DATE_CREATION = DateTime.Now,
                        DESCRIPTION = pTask.Description,
                        NAME = pTask.Name,
                        STATUS = (int)pTask.Status
                        //STATUS = (int)TaskEnum.Operation.Create
                    };

                    //Adiciona o Histórico
                    objTask.TASK_HISTORY.Add(CreateHistory(TaskEnum.Operation.Create));

                    //Salva no Banco
                    objTaskDAL.Save(objTask);

                    return true;
                }
                else
                {
                    return Update(pTask);
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Atualiza uma Task
        /// </summary>
        /// <param name = "pTask" ></ param >
        public bool Update(TaskDTO pTask)
        {
            try
            {
                TASK objTask = objTaskDAL.Single(pTask.TaskID);

                if (objTask != null)
                {
                    //Atribui os novos valores a Task
                    objTask.DESCRIPTION = pTask.Description;
                    objTask.NAME = pTask.Name;
                    objTask.STATUS = (int)pTask.Status;

                    //Adiciona o histórico
                    objTask.TASK_HISTORY.Add(CreateHistory(TaskEnum.Operation.Update));

                    //Salva no Banco
                    objTaskDAL.Save(objTask);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Atribuí o status de Excluído para a Task
        /// </summary>
        /// <param name="pTaskID"></param>
        /// <returns></returns>
        public bool Delete(int pTaskID)
        {
            try
            {
                TASK objTask = objTaskDAL.Single(pTaskID);
                if (objTask != null)
                {
                    //Cria o histórico da Task
                    objTask.TASK_HISTORY.Add(CreateHistory(TaskEnum.Operation.Delete));

                    //Seta a task para Excluído
                    objTask.STATUS = (int)TaskEnum.Status.Excluido;

                    //Salva no banco
                    objTaskDAL.Save(objTask);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Cria o histórico da operação
        /// </summary>
        /// <param name="pStatus"></param>
        /// <returns></returns>
        public TASK_HISTORY CreateHistory(TaskEnum.Operation pStatus)
        {
            TASK_HISTORY objTaskHistory = new TASK_HISTORY()
            {
                DATE_EVENT = DateTime.Now,
                OPERATION = (int)pStatus
            };

            return objTaskHistory;
        }


        public List<TaskDTO> Search(TaskDTO pTask)
        {
            return objTaskDAL.GetTaskList(pTask);
        }
    }
}
