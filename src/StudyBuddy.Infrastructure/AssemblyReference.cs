﻿using System.Reflection;

namespace StudyBuddy.Infrastructure;

public static class AssemblyReference
{
    public static readonly Assembly Assembly =
        typeof(AssemblyReference).Assembly;
}
