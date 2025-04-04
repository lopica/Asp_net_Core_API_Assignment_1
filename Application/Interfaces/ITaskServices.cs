using Asp_net_Core_API_Assignment_1.Application.DTOs;

namespace Asp_net_Core_API_Assignment_1.Application.Interfaces
{
    public interface ITaskServices
    {
        TaskDTO CreateNewTask(TaskDTO task);
        List<TaskDTO> CreateNewTasks(List<TaskDTO> newTasks);
        List<TaskDTO> GetAllTasks();
        TaskDTO? GetTaskById(Guid taskId);
        TaskDTO? UpdateTaskById(string title, TaskDTO newTask);
        TaskDTO? DeleteTask(string title);
        List<TaskDTO> DeleteTasks(List<string> title);

    }
}
