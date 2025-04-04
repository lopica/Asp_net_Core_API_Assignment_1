using Asp_net_Core_API_Assignment_1.Application.Interfaces;
using Asp_net_Core_API_Assignment_1.Domain.Interfaces;
namespace Asp_net_Core_API_Assignment_1.Infrastructure.Repositories
{
    public class TasksRepo(ICacheService cacheService) : ITasksRepo
    {
        private readonly ICacheService _cacheService = cacheService;
        public Domain.Entities.Task CreateNewTask(Domain.Entities.Task newTask)
        {
            List<Domain.Entities.Task> tasks = _cacheService.GetTasks();
            Domain.Entities.Task? existTask = GetTaskByTitle(newTask.Title);
            if (existTask != null) throw new Exception($"This title {existTask.Title} is exist");
            tasks.Add(newTask);
            _cacheService.SetTasks(tasks);
            return newTask;
        }

        public List<Domain.Entities.Task> CreateNewTasks(List<Domain.Entities.Task> newTasks)
        {
            List<Domain.Entities.Task> tasks = _cacheService.GetTasks();
            foreach(Domain.Entities.Task newTask in newTasks)
            {
                tasks.Add(newTask);

            }
            _cacheService.SetTasks(tasks);
            return newTasks;
        }

        public Domain.Entities.Task? DeleteTask(Guid taskId)
        {
            Domain.Entities.Task? task = GetTaskById(taskId);
            if (task != null) 
            { 
                List<Domain.Entities.Task> tasks = _cacheService.GetTasks();
                tasks.Remove(task);
                _cacheService.SetTasks(tasks);
                return task;
            }
            return null;
        }

        public List<Domain.Entities.Task> DeleteTasks(List<Guid> taskIds)
        {
            List<Domain.Entities.Task> deleteTasks = GetTasksByIds(taskIds);
            if (deleteTasks.Count != 0)
            {
                List<Domain.Entities.Task> tasks = _cacheService.GetTasks();
                foreach (var task in deleteTasks) 
                {
                    tasks.Remove(task);
                }
                _cacheService.SetTasks(tasks);
                return deleteTasks;
            }
            return deleteTasks;
        }

        public List<Domain.Entities.Task> GetAllTasks() => _cacheService.GetTasks();

        public Domain.Entities.Task? GetTaskById(Guid taskId) => _cacheService.GetTasks().FirstOrDefault(t => t.Id == taskId);
        public Domain.Entities.Task? GetTaskByTitle(string title) => _cacheService.GetTasks().FirstOrDefault(t => t.Title == title);
        public List<Domain.Entities.Task> GetTasksByIds(List<Guid> taskIds)
        {
            List<Domain.Entities.Task> tasks = [];
            foreach(Guid taskid in taskIds)
            {
                Domain.Entities.Task? task = GetTaskById(taskid) ?? throw new Exception($"{taskid} is not exist");
                tasks.Add(task);
            }
            return tasks;
        }

        public Domain.Entities.Task? UpdateTaskById(Guid taskId, Domain.Entities.Task newTask)
        {
            Domain.Entities.Task? task = GetTaskById(taskId);
            if (task != null) 
            {
                List<Domain.Entities.Task> tasks = _cacheService.GetTasks();
                tasks.Remove(task);
                tasks.Add(newTask);
                _cacheService.SetTasks(tasks);
                return task;
            }
            return null;
        }
    }
}
