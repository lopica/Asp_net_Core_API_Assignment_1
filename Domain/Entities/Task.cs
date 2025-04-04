using Asp_net_Core_API_Assignment_1.Infrastructure.ExternalServices;
using System.Diagnostics.CodeAnalysis;

namespace Asp_net_Core_API_Assignment_1.Domain.Entities
{
    public class Task
    {
        public Guid Id { get; set; }
        public required string Title { get; init; }
        public bool IsCompleted { get; set; }

        [SetsRequiredMembers]
       public Task(string title, bool isCompleted = false)
        {
            Id = Guid.NewGuid();
            Title = title;
            IsCompleted = isCompleted;
        }

        public static Task CreateRandomTask() => new(Ultilities.GenerateRandomTitle(), Ultilities.GetMockTrueFalse());
    }
}
