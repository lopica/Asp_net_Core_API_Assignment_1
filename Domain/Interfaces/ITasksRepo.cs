namespace Asp_net_Core_API_Assignment_1.Domain.Interfaces
{
    public interface ITasksRepo
    {
        Entities.Task CreateNewTask(Entities.Task task);
        //List<Entities.Task> CreateNewTasks(List<Entities.Task> tasks);
        List<Entities.Task> GetAllTasks();
        Entities.Task? GetTaskById(Guid taskId);
        Entities.Task? GetTaskByTitle(string title);
        Entities.Task? UpdateTaskById(Guid taskId, Entities.Task newTask);
        Entities.Task? DeleteTask(Guid taskId);
        //List<Entities.Task> DeleteTasks(List<Guid> taskIds);
    }
}
