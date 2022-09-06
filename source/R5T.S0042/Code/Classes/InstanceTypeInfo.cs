using System;


namespace R5T.S0042
{
    class InstanceTypeInfo
    {
        #region Static

        public static InstanceTypeInfo DraftDemonstrations { get; } = new()
        {
            InterfacesProjectDirectoryRelativeDirectoryPath = Instances.ProjectDirectoryRelativePath.Demonstrations_Draft_Interfaces_Directory,
            MarkerAttributeNamespacedTypeName = Instances.NamespacedTypeNames.DraftDemonstrationsMarkerAttribute,
            MarkerInterfaceNamespacedTypeName = Instances.NamespacedTypeNames.DraftDemonstrationsMarkerInterface,
        };
        public static InstanceTypeInfo DraftExperiments { get; } = new()
        {
            InterfacesProjectDirectoryRelativeDirectoryPath = Instances.ProjectDirectoryRelativePath.Experiments_Draft_Interfaces_Directory,
            MarkerAttributeNamespacedTypeName = Instances.NamespacedTypeNames.DraftExperimentsMarkerAttribute,
            MarkerInterfaceNamespacedTypeName = Instances.NamespacedTypeNames.DraftExperimentsMarkerInterface,
        };
        public static InstanceTypeInfo DraftExplorations { get; } = new()
        {
            InterfacesProjectDirectoryRelativeDirectoryPath = Instances.ProjectDirectoryRelativePath.Explorations_Draft_Interfaces_Directory,
            MarkerAttributeNamespacedTypeName = Instances.NamespacedTypeNames.DraftExplorationsMarkerAttribute,
            MarkerInterfaceNamespacedTypeName = Instances.NamespacedTypeNames.DraftExplorationsMarkerInterface,
        };
        public static InstanceTypeInfo DraftFunctionality { get; } = new()
        {
            InterfacesProjectDirectoryRelativeDirectoryPath = Instances.ProjectDirectoryRelativePath.Functionality_Draft_Interfaces_Directory,
            MarkerAttributeNamespacedTypeName = Instances.NamespacedTypeNames.DraftFunctionalityMarkerAttribute,
            MarkerInterfaceNamespacedTypeName = Instances.NamespacedTypeNames.DraftFunctionalityMarkerInterface,
        };
        public static InstanceTypeInfo DraftValues { get; } = new()
        {
            InterfacesProjectDirectoryRelativeDirectoryPath = Instances.ProjectDirectoryRelativePath.Values_Draft_Interfaces_Directory,
            MarkerAttributeNamespacedTypeName = Instances.NamespacedTypeNames.DraftValuesMarkerAttribute,
            MarkerInterfaceNamespacedTypeName = Instances.NamespacedTypeNames.DraftValuesMarkerInterface,
        };


        public static InstanceTypeInfo Demonstrations { get; } = new()
        {
            InterfacesProjectDirectoryRelativeDirectoryPath = Instances.ProjectDirectoryRelativePath.Demonstrations_Interfaces_Directory,
            MarkerAttributeNamespacedTypeName = Instances.NamespacedTypeNames.DemonstrationsMarkerAttribute,
            MarkerInterfaceNamespacedTypeName = Instances.NamespacedTypeNames.DemonstrationsMarkerInterface,
        };
        public static InstanceTypeInfo Experiments { get; } = new()
        {
            InterfacesProjectDirectoryRelativeDirectoryPath = Instances.ProjectDirectoryRelativePath.Experiments_Interfaces_Directory,
            MarkerAttributeNamespacedTypeName = Instances.NamespacedTypeNames.ExperimentsMarkerAttribute,
            MarkerInterfaceNamespacedTypeName = Instances.NamespacedTypeNames.ExperimentsMarkerInterface,
        };
        public static InstanceTypeInfo Explorations { get; } = new()
        {
            InterfacesProjectDirectoryRelativeDirectoryPath = Instances.ProjectDirectoryRelativePath.Explorations_Interfaces_Directory,
            MarkerAttributeNamespacedTypeName = Instances.NamespacedTypeNames.ExplorationsMarkerAttribute,
            MarkerInterfaceNamespacedTypeName = Instances.NamespacedTypeNames.ExplorationsMarkerInterface,
        };
        public static InstanceTypeInfo Functionality { get; } = new()
        {
            InterfacesProjectDirectoryRelativeDirectoryPath = Instances.ProjectDirectoryRelativePath.Functionality_Interfaces_Directory,
            MarkerAttributeNamespacedTypeName = Instances.NamespacedTypeNames.FunctionalityMarkerAttribute,
            MarkerInterfaceNamespacedTypeName = Instances.NamespacedTypeNames.FunctionalityMarkerInterface,
        };
        public static InstanceTypeInfo Tries { get; } = new()
        {
            InterfacesProjectDirectoryRelativeDirectoryPath = Instances.ProjectDirectoryRelativePath.Tries_Interfaces_Directory,
            MarkerAttributeNamespacedTypeName = Instances.NamespacedTypeNames.TriesMarkerAttribute,
            MarkerInterfaceNamespacedTypeName = Instances.NamespacedTypeNames.TriesMarkerInterface,
        };
        public static InstanceTypeInfo Values { get; } = new()
        {
            InterfacesProjectDirectoryRelativeDirectoryPath = Instances.ProjectDirectoryRelativePath.Values_Interfaces_Directory,
            MarkerAttributeNamespacedTypeName = Instances.NamespacedTypeNames.ValuesMarkerAttribute,
            MarkerInterfaceNamespacedTypeName = Instances.NamespacedTypeNames.ValuesMarkerInterface,
        };


        #endregion


        public string MarkerAttributeNamespacedTypeName { get; set; }
        public string MarkerInterfaceNamespacedTypeName { get; set; }
        public string InterfacesProjectDirectoryRelativeDirectoryPath { get; set; }
    }
}
