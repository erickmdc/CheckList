using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskList.Models;

namespace TaskList.Business
{
    public class TaskBusiness
    {

        private mydbEntities myDB = new mydbEntities();

        
        //Buscar todas as tarefas
        public List<task> GetAllTasks()
        {
            return myDB.task.Select(e => e).ToList();
        }

        //uscar tarefa por Id
        public task GetTaskById(int TaskId)
        {
            return myDB.task.Where(e => e.TaskId == TaskId).Select(e => e).FirstOrDefault();
        }

        //Salvar nova tarefa
        public task SaveTask(string Description)
        {
            task task = new task();

            task.Description = Description;
            task.Status = true;

            try
            {
                myDB.task.Add(task);
                myDB.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return task;

        }

        //Mudar Status da tarefa
        public task ChangeStatus(int TaskId)
        {
            task task = GetTaskById(TaskId);

            if(task.Status == true)
            {
                task.Status = false;
            }
            else
            {
                task.Status = true;
            }

            try
            {
                myDB.task.Attach(task);
                myDB.Entry(task).Property(e => e.Status).IsModified = true;
                myDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return task;
        }

        
    }
}