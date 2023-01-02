using BLL.Domains;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoTaskController : Controller
    {
        public readonly ToDoTaskDomain _toDoTaskDomain;
        public ToDoTaskController(ToDoTaskDomain toDoTaskDomain)
        {
            _toDoTaskDomain = toDoTaskDomain;
        }

        [HttpGet]
        public IActionResult MyTasks()
        {
            var toDoTasks = _toDoTaskDomain.GetAll();

            var indexViewModel = new IndexViewModel()
            {
                CreateModel = new TodoTask()
                {
                    TaskDateTime = DateTime.Now
                },
                ListModel = toDoTasks
            };

            //TodoTask todoTask = new TodoTask();
            //todoTask.TaskDateTime = DateTime.Now;
            //ViewBag.TaskDate = todoTask.TaskDateTime;

            return View(indexViewModel);
        }

        [HttpPost]
        public IActionResult MyTasks(TodoTask todoTask)
        {
            if (ModelState.IsValid)
            {
                _toDoTaskDomain.Insert(todoTask);
                ViewBag.TaskDate = todoTask.TaskDateTime;
                return RedirectToAction("MyTasks", "ToDoTask"); 
            }

            return View(todoTask);
        }

    }
}
