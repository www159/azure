namespace azure_m.Models
{
    namespace ResponseModels
    {
        public class VirtualMachineResponse
        {
            //public ExtendedLocation extendedLocation { get; set; }

            //public VirtualMachineIdentity identity { get; set; }

            //public Plan plan { get; set; }

            public string id { get; set; }

            public string location { get; set; }

            public string name { get; set; }

            public VirtualMachineProperties properties { get; set; }

            public object tags { get; set; }

            public VirtualMachineExtension[] resources { get; set; }

            public string type { get; set; }

            public string[] zones { get; set; }
        }

        public class VirtualMachineProperties
        {
            public string vmId { get; set; }

            public SubResource availabilitySet { get; set; }

            public SubResource proximityPlacementGroup { get; set; }

            public HardwareProfile hardwareProfile { get; set; }

            public StorageProfile storageProfile { get; set; }

            public ApplicationProfile applicationProfile { get; set; }

            public string userData { get; set; }

            public OSProfile osProfile { get; set; }

            public NetworkProfile networkProfile { get; set; }

            public DiagnosticsProfile diagnosticsProfile { get; set; }

            public string extensionsTimeBudget { get; set; }

            public ProvisioningState provisioningState { get; set; }

            public string timeCreated { get; set; }
        }

        public class HardwareProfile
        {
            public string cmSize { get; set; }

            public VMSizeProperties vmSizeProperties { get; set; }
        }

        public class VMSizeProperties
        {
            public int vCPUsAvailable;

            public int vCPUsPerCore;
        }

        public class StorageProfile
        {
            public ImageReference imageReference { get; set; }

            public OSDisk osDisk { get; set; }

            public DataDisk[] dataDisks { get; set; }
        }

        public class ImageReference
        {
            public string publisher { get; set; }

            public string offer { get; set; }

            public string sku { get; set; }

            public string version { get; set; }
        }

        public class OSDisk
        {
            public string osType { get; set; }

            public string name { get; set; }

            public string createOption { get; set; }

            public string caching { get; set; }

            public ManagedDiskParameters managedDisk { get; set; }

            public int diskSizeGB { get; set; }
        }

        public class ManagedDiskParameters
        {
            public string storageAccountType { get; set; }

            public string id { get; set; }
        }

        public class DataDisk
        {
            public int lun { get; set; }

            public string name { get; set; }

            public string createOption { get; set; }

            public string caching { get; set; }

            public ManagedDiskParameters managedDisk { get; set; }

            public int diskSizeGB { get; set; }
        }

        public class ApplicationProfile
        {
            public VMGalleryApplication[] galleryApplications { get; set; }
        }

        public class VMGalleryApplication
        {
            public string configurationReference { get; set; }

            public bool enableAutomaticUpgrade { get; set; }

            public int order { get; set; }

            public string packageReferenceId { get; set; }

            public string tags { get; set; }

            public bool treatFailureAsDeploymentFailure { get; set; }
        }

        public class OSProfile
        {
            public string computerName { get; set; }

            public string adminUsername { get; set; }

            public WindowsConfiguration windowsConfiguration { get; set; }

            public VaultSecretGroup[] secrets { get; set; }
        }

        public class WindowsConfiguration
        {
            public bool provisionVMAgent { get; set; }

            public bool enableAutomaticUpdates { get; set; }
        }

        public class VaultSecretGroup
        {
            public SubResource sourceVault { get; set; }

            //public VaultCertificate[] vaultCertificates { get; set; }
        }

        public class NetworkProfile
        {
            //public NetworkApiVersion networkApiVersion { get; set; }

            //public VirtualMachineNetworkInterfaceConfiguration[] networkInterfaceConfigurations { get; set; }

            public NetworkInterfaceReference[] networkInterfaces { get; set; }
        }

        public class NetworkInterfaceReference
        {
            public string id { get; set; }

            //public NetworkInterfaceReferenceProperties properties { get; set; }

        }

        public class DiagnosticsProfile
        {
            public BootDiagnostics bootDiagnostics { get; set; }
        }

        public class BootDiagnostics
        {
            public bool enabled { get; set; }

            public string storageUri { get; set; }
        }

        public class VirtualMachineExtension
        {
            public string id { get; set; }

            public string location { get; set; }

            public string name { get; set; }

            public VirtualMachineExtensionProperties properties { get; set; }

            public object tags { get; set; }

            public string type { get; set; }
        }

        public class VirtualMachineExtensionProperties
        {
            public bool autoUpgradeMinorVersion { get; set; }

            public string provisioningState { get; set; }

            public string publisher { get; set; }

            public string type { get; set; }

            public string typeHandlerVersion { get; set; }

            public object settings { get; set; }
        }
    }
}
