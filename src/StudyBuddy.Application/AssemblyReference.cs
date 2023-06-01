using System.Reflection;

namespace StudyBuddy.Application;

public static class AssemblyReference
{
    public static readonly Assembly Assembly =
        typeof(AssemblyReference).Assembly;
}
