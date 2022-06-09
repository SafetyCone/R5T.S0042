using System;

using R5T.Z0006;
using R5T.Z0007;


namespace R5T.S0042
{
    public static class Instances
    {
        public static INamespacedTypeNames NamespacedTypeNames { get; } = Z0006.NamespacedTypeNames.Instance;
        public static IProjectDirectoryRelativePath ProjectDirectoryRelativePath { get; } = Z0007.ProjectDirectoryRelativePath.Instance;
    }
}
