namespace Asp_net_Core_API_Assignment_1.Application.Interfaces
{
    public interface ICacheService
    {
        List<Domain.Entities.Task> GetTasks();
        void SetTasks(List<Domain.Entities.Task> tasks);
    }
}
