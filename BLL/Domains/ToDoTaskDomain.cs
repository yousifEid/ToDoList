using DAL.Models;
using DAL.Repository;

namespace BLL.Domains
{
    public class ToDoTaskDomain
    {
        private readonly ToDoTaskRepository _toDoTaskRepository;

        public ToDoTaskDomain(ToDoTaskRepository toDoTaskRepository)
        {
            _toDoTaskRepository = toDoTaskRepository;
        }

        public TodoTask Insert(TodoTask todoTask)
        {
            return _toDoTaskRepository.Insert(todoTask);
        }

        public TodoTask Update(TodoTask todoTask)
        {
            return _toDoTaskRepository.Update(todoTask);
        }

        public TodoTask Delete(int id)
        {
            return _toDoTaskRepository.Delete(id);
        }

        public List<TodoTask> GetAll()
        {
            return _toDoTaskRepository.GetAll();
        }
    }
}