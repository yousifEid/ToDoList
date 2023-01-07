using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ToDoTaskRepository
    {
        private ToDoListDbContext _db;

        public ToDoTaskRepository(ToDoListDbContext db)
        {
            _db = db;
        }

        public TodoTask Insert(TodoTask todoTask)
        {
            _db.TodoTasks.Add(todoTask);
            _db.SaveChanges();
            return todoTask;
        }

        public TodoTask Update(TodoTask todoTask)
        {
            _db.Entry(todoTask).State = EntityState.Modified;
            _db.SaveChanges();
            return todoTask;
        }

        public TodoTask Delete(int id)
        {
            var todoTask = _db.TodoTasks.Where(e => e.Id == id).FirstOrDefault();
            _db.Entry(todoTask).State = EntityState.Deleted;
            _db.TodoTasks.Remove(todoTask);
            _db.SaveChanges();
            return todoTask;
        }

        public List<TodoTask> GetAll()
        {
            var todoTask = _db.TodoTasks.ToList();
            return todoTask; 
        }

        public TodoTask GetById(int id)
        {
            var todoTask = _db.TodoTasks.Where(e => e.Id == id).AsNoTracking().FirstOrDefault();
            return todoTask;
        }
    }
}
