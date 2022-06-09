using System;
using System.IO;
using System.Linq;


namespace R5T.S0042
{
    class Program
    {
        static void Main()
        {
            /// Inputs.
            var projectFilePath = @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.F0024\source\R5T.F0024.Construction\R5T.F0024.Construction.csproj";
            var instanceTypeInfo = InstanceTypeInfo.Demonstrations;
            var instanceNameStems = new[]
            {
                "SolutionFileGeneratorDemonstrations",
            };

            var namespaceNameOverride =
                "Not Overridden"
                //"R5T.F0023"
                ;

            /// Run.
            var functionalityMarkerAttributeNamespacedTypeName = instanceTypeInfo.MarkerAttributeNamespacedTypeName;
            var functionalityMarkerInterfaceNamespacedTypeName = instanceTypeInfo.MarkerInterfaceNamespacedTypeName;
            var interfacesProjectDirectoryRelativeDirectoryPath = instanceTypeInfo.InterfacesProjectDirectoryRelativeDirectoryPath;
            var classesProjectDirectoryRelativeDirectoryPath = Instances.ProjectDirectoryRelativePath.InstanceClassesDirectory;

            var projectFileName = projectFilePath.Split('\\').Last();
            var projectDirectoryPath = String.Join('\\', projectFilePath.Split('\\').SkipLast(1)) + '\\';

            var projectName = String.Join('.', projectFileName.Split('.').SkipLast(1));

            var namespaceNameIsNotOverridden = namespaceNameOverride == "Not Overridden";
            var namespaceName = namespaceNameIsNotOverridden
                ? projectName
                : namespaceNameOverride
                ;

            var functionalityMarkerAttributeTypeName = functionalityMarkerAttributeNamespacedTypeName.Split('.').Last().Replace("Attribute", "");
            var functionalityMarkerAttributeNamespaceName = String.Join('.',
                functionalityMarkerAttributeNamespacedTypeName.Split('.').SkipLast(1));

            var functionalityMarkerInterfaceTypeName = functionalityMarkerInterfaceNamespacedTypeName.Split('.').Last();
            var functionalityMarkerInterfaceNamespaceName = String.Join('.',
                functionalityMarkerInterfaceNamespacedTypeName.Split('.').SkipLast(1));

            var functionalityInterfacesDirectoryPath = projectDirectoryPath +
                interfacesProjectDirectoryRelativeDirectoryPath + '\\';

            var functionalityClassesDirectoryPath = projectDirectoryPath +
                classesProjectDirectoryRelativeDirectoryPath + '\\';

            var usingNamespaceDirectives = new[]
            {
                functionalityMarkerAttributeNamespaceName,
                functionalityMarkerInterfaceNamespaceName,
            }
            .Distinct()
            .Select(x => $"using {x};{Environment.NewLine}")
            .ToArray();

            var usingNamespaceDirectivesText = usingNamespaceDirectives.Aggregate((x, y) => $"{x}{y}");

            foreach (var functionalityNameStem in instanceNameStems)
            {
                var interfaceTypeName = $"I{functionalityNameStem}";

                var interfaceText =
$@"
using System;

{usingNamespaceDirectivesText}

namespace {namespaceName}
{{
	[{functionalityMarkerAttributeTypeName}]
	public partial interface {interfaceTypeName} : {functionalityMarkerInterfaceTypeName}
	{{
	}}
}}
".Trim();

                var interfaceFilePath = functionalityInterfacesDirectoryPath + $"{interfaceTypeName}.cs";

                Directory.CreateDirectory(functionalityInterfacesDirectoryPath);

                if(File.Exists(interfaceFilePath))
                {
                    Console.WriteLine($"File already exists:\n{interfaceFilePath}\n");
                }
                else
                {
                    File.WriteAllText(
                        interfaceFilePath,
                        interfaceText);
                }

                var classTypeName = functionalityNameStem;

                var classText =
$@"
using System;


namespace {namespaceName}
{{
	public class {classTypeName} : {interfaceTypeName}
	{{
		#region Infrastructure

	    public static {classTypeName} Instance {{ get; }} = new();

	    private {classTypeName}()
	    {{
        }}

	    #endregion
	}}
}}
".Trim();

                var classFilePath = functionalityClassesDirectoryPath + $"{classTypeName}.cs";

                Directory.CreateDirectory(functionalityClassesDirectoryPath);

                if (File.Exists(classFilePath))
                {
                    Console.WriteLine($"File already exists:\n{classFilePath}\n");
                }
                else
                {
                    File.WriteAllText(
                        classFilePath,
                        classText);
                }
            }
        }
    }
}
