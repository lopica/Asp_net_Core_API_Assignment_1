namespace Asp_net_Core_API_Assignment_1.Application.DTOs
{
    public record TaskDTO(string Title, bool IsCompleted = false);
}