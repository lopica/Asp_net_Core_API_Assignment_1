using System;

namespace Asp_net_Core_API_Assignment_1.Infrastructure.ExternalServices
{
    public static class Ultilities
    {
        private static readonly Random _random = new();

        private static readonly string[] Verbs =
        {
            "Run", "Jump", "Code", "Debug", "Test", "Deploy", "Fix", "Create", "Build", "Design"
        };

        private static readonly string[] Nouns =
        {
            "Fox", "Dog", "Cat", "Developer", "Robot", "Manager", "Task", "Bug", "Feature", "Sprint"
        };

        public static string GenerateRandomTitle()
        {
            string verb = Verbs[_random.Next(Verbs.Length)];
            string noun = Nouns[_random.Next(Nouns.Length)];

            return $"{verb} {noun}";
        }

        public static bool GetMockTrueFalse() => _random.Next(0, 2) == 1;
    }
}
