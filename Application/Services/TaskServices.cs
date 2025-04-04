using Asp_net_Core_API_Assignment_1.Domain.Interfaces;
using Asp_net_Core_API_Assignment_1.Application.Interfaces;
using Asp_net_Core_API_Assignment_1.Application.DTOs;

namespace Asp_net_Core_API_Assignment_1.Application.Services
{
    public class TaskServices(ITasksRepo tasksRepo) : ITaskServices
    {
        private readonly ITasksRepo _tasksRepo = tasksRepo;

        public TaskDTO CreateNewTask(TaskDTO task)
        {
            Domain.Entities.Task newTask = _tasksRepo.CreateNewTask(new Domain.Entities.Task(task.Title, task.IsCompleted));
            return new TaskDTO(newTask.Title, newTask.IsCompleted);
        }

        public List<TaskDTO> CreateNewTasks(List<TaskDTO> newTasks)
        {
            foreach (TaskDTO task in newTasks)
            {
                _tasksRepo.CreateNewTask(new Domain.Entities.Task(task.Title, task.IsCompleted));
            }
            return newTasks;
        }

        public TaskDTO? DeleteTask(string title)
        {
            Domain.Entities.Task? existTask = _tasksRepo.GetTaskByTitle(title);
            if (existTask == null)
            {
                throw new Exception($"This title {title} is not exist");
            }
            Domain.Entities.Task? deletedTask = _tasksRepo.DeleteTask(existTask.Id);
            if (deletedTask == null)
            {
                return null;
            }
            return new TaskDTO(deletedTask.Title, deletedTask.IsCompleted);
        }

        public List<TaskDTO> DeleteTasks(List<string> titles)
        {
            List<TaskDTO> deletedTasks = [];
            foreach (string title in titles)
            {
                TaskDTO? task = DeleteTask(title);
                if (task != null) { deletedTasks.Add(task); }

            }
            return deletedTasks;
        }

        public List<TaskDTO> GetAllTasks() => _tasksRepo.GetAllTasks().Select(t => new TaskDTO(t.Title, t.IsCompleted)).ToList();

        public TaskDTO? GetTaskById(Guid taskId)
        {
            Domain.Entities.Task? findTask = _tasksRepo.GetTaskById(taskId);
            if (findTask != null)
            {
                return new TaskDTO(findTask.Title, findTask.IsCompleted);
            }
            return null;
        }

        public TaskDTO? UpdateTaskById(string title, TaskDTO newTask)
        {
            Domain.Entities.Task? existTask = _tasksRepo.GetTaskByTitle(title);
            if (existTask == null)
            {
                throw new Exception($"This title {title} is not exist");
            }
            Domain.Entities.Task? updatedTask = _tasksRepo.UpdateTaskById(existTask.Id, new Domain.Entities.Task(newTask.Title, newTask.IsCompleted));
            if (updatedTask == null)
            {
                throw new Exception($"This id {existTask.Id} is not exist");
            }
            return new TaskDTO(newTask.Title, newTask.IsCompleted);
        }
    }
}
