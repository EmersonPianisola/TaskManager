using DAL.Context;
using DAL.Repository;
using TaskApplication.DTO.Enum;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApplication.DTO.Classes;

namespace TaskApplication.DAL.Classes
{
    public class TaskDAL : Repository<TASK>
    {
        public void Save(TASK pTask)
        {
            try
            {
                this.BeginTransaction();

                if (pTask.ID > 0)
                {
                    Update(pTask);
                }
                else
                {
                    Add(pTask);
                }

                SaveContext();
                this.Commit();
            }
            catch (Exception e)
            {
                this.Rollback();
                throw e;
            }
        }

        public List<TaskDTO> GetTaskList(TaskDTO pTaskDTO)
        {
            try
            {
                using (TasksEntities ctx = new TasksEntities())
                {
                    var objPredicate = Filters(pTaskDTO);

                    return ctx.TASK
                              .Where(objPredicate)
                              .Select(x => new TaskDTO
                              {
                                  DateCreation = x.DATE_CREATION,
                                  Description = x.DESCRIPTION,
                                  Name = x.NAME,
                                  Status = (TaskEnum.Status)x.STATUS,
                                  TaskID = x.ID
                              }).ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        private ExpressionStarter<TASK> Filters(TaskDTO pTaskDTO)
        {
            var objPredicateTask = PredicateBuilder.New<TASK>(false);

            if (pTaskDTO.StartDate.HasValue)
            {
                objPredicateTask = objPredicateTask.And(x => x.DATE_CREATION >= pTaskDTO.StartDate.Value);
            }

            if (pTaskDTO.EndDate.HasValue)
            {
                var dtFinal = pTaskDTO.EndDate.Value.AddHours(24);
                objPredicateTask = objPredicateTask.And(x => x.DATE_CREATION < dtFinal);
            }

            //Não trazer as Tasks que foram excluídas
            objPredicateTask = objPredicateTask.And(x => x.STATUS != (int)TaskEnum.Status.Excluido);

            return objPredicateTask;
        }

    }
}
