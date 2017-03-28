using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskList.Business;

namespace TaskList.Controllers
{
    public class HomeController : Controller
    {
        TaskBusiness taskBusiness = new TaskBusiness();

        public ActionResult Index()
        {
            var tasks = taskBusiness.GetAllTasks();
            return View(tasks);
        }

        [HttpPost]
        public ActionResult SaveForm(FormCollection frm)
        {
            try
            {
                string description = frm["Description"].ToString();
                var task = taskBusiness.SaveTask(description);

                return Json(task, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(400, ex.Message);
            }
        }
        
        [HttpPost]
        public ActionResult ChangeStatus(string TaskId)
        {
            try
            {
                int taskId = int.Parse(TaskId);
                var task = taskBusiness.ChangeStatus(taskId);

                return Json(task, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(400, ex.Message);
            }
        }

    }
}