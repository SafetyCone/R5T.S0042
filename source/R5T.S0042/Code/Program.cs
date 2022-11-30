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
            var projectFilePath = @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.F0088\source\R5T.F0088\R5T.F0088.csproj";
            var instanceTypeInfo = InstanceTypeInfo.Functionality;
            var instanceNameStems = new[]
            {
                // Note: for values, names should be plural, not singular.
                "VisualStudioOperator",
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

                /// <remarks>
                /// * Use = new ClassTypeName() instead of the "target-typed object creation" feature.
                ///     That feature is only available as-of C# language version 9.0, and to have a broader reach, .NET Standard 2.1 is used for libraries.
                ///     Because .NET Standard 2.1 is only C# language version 8.0, to allow .NET Standard 2.1, we have to limit ourselves and refrain from using the "target-typed object creation" feature.
                /// * Make the Instance static property type the interface type.
                ///     The "default interface methods" used for functionality have a C# language rule that they are not available from instances of the implementation class type, only instances of the interface type.
                ///     By typing the static instance as the interface, all the functionality methods are available from the instance (Namespace.ClassTypeName.Functionality() is possible).
                /// </remarks>
                var classText =
$@"
using System;


namespace {namespaceName}
{{
	public class {classTypeName} : {interfaceTypeName}
	{{
		#region Infrastructure

	    public static {interfaceTypeName} Instance {{ get; }} = new {classTypeName}();

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
