namespace azure_m.Models.RequestModels
{

    namespace PublicIPAddressRequestModels {
        // TODO
    }

    namespace NetworkInterfaceRequestModels {
        namespace CreateOrUpdate
        {
            public class CreateOrUpdateNIUri
            {

            }
            public class CreateOrUpdateNIBody
            {

            }
            public class CreateOrUpdateNIRequest:IRequest<CreateOrUpdateNIUri,CreateOrUpdateNIBody>
            {

            }
        }
    }

    namespace VMRequestModels
    {

        namespace CreateOrUpdate
        {
            #region 虚拟机硬件配置相关配置
            public class VMSizeProperties
            {

                public int vCPUsAvailable;

                public int vCPUsPerCore;
            }
            public class HardWareProfile
            {
                public string[] vmSize;

                public VMSizeProperties vmSizeProperties;

            }
            #endregion

            #region 虚拟机网络相关配置

            public class DeleteOptions
            {

                public static string Delete = "Delete";

                public static string Detach = "Detach";
            }

            public class NetworkInterfaceProperties
            {

                public bool primary;

                // Type:  DeleteOption
                // Value: Delete, Detach
                public string deleteOptions;
            }

            public class NetworkInterface
            {

                public string id;

                public NetworkInterfaceProperties properties;



            }

            public class NetworkProfile
            {

                public NetworkInterface[] networkInterfaces;

                /*
                
                public NetworkApiVersion networkApiVersion;

                public List<VitualMachineNetworkInterfaceCOnfiguration> networkInterfaceConfigurations;
                
                */
            }
            #endregion

            #region 虚拟机操作系统相关配置

            public class OSProfile
            {

                /*
                
                最小长度 (Windows) ：8 个字符

                Linux) 最小长度 (： 6 个字符

                最大长度 (Windows) ：123 个字符

                Linux) 最大长度 (： 72 个字符

                复杂性要求： 需要满足以下 4 个条件中的 3 个
                字符较低
                具有大写字符
                包含数字
                具有特殊字符 (正则表达式匹配 [\W_])

                不允许的值： “abc@123”、“P@$$w 0rd”、“P@ssw0rd”、“P@ssword123”、“Pa$$word”、“pass@word1”、“Password！”、“Password1”、“Password22”、“iloveyou！”

                若要重置密码，请参阅如何在 Windows VM 中重置远程桌面服务或其登录密码

                */
                public string adminPassword;

                /*
                创建 VM 后，无法更新此属性。

                仅Windows限制：不能以“结尾”。

                不允许的值： “administrator”、“admin”、“user”、“user1”、“test”、“user2”、“test1”、“user1”、“user3”、“admin1”、“1”， “123”、“a”、“actuser”、“adm”、“admin2”、“aspnet”、“backup”、“console”、“david”、“guest”、“john”、“owner”、“root”、“server”、“sql”、“support”、“support_388945a0”、“sys”、“test2”、“test3”、“user4”、“user5”。

                Linux) 最小长度 (： 1 个字符

                Linux) 的最大长度 (： 64 个字符

                最大长度 (Windows) ：20 个字符。
                */
                public string adminUsername;

                public bool alllowExtensionOperations;

                public string computerName;

                public string custmData;

                public bool requireGuestProvisionSignal;

                /*
                
                public LinuxConfiguration linuxConfiguration;

                public List<VailtSecretGroup> secrets;

                public WindowsConfiguration windowsConfiguration;
                
                */

            }
            #endregion

            #region 虚拟机存储相关配置

            public class CachingTypes {

                public static string None = null;

                public static string ReadOnly = "ReadOnly";

                public static string ReadWrite = "ReadWrite";

            }

            public class DiskCreateOptionTypes {

                public static string Attach = "Attach";

                public static string Empty = "Enmpty";

                public static string FromImage = "FromImage";

            }

            public class DiskDeleteOptionTypes: DeleteOptions { }

            public class DiffDiskPlacement {

                public static string CacheDisk = "CacheDisk";

                public static string ResourceDisk = "ResourceDisk";
                
            }

            public class DiffDiskOptions {

                public static string Local = "Local";
            }

            public class DiffDiskSettings {
                
                // Type:  DiffDIskOptions
                // Value: CacheDisk, ResourceDisk
                public string placement;
                
                // Type:  DiffDiskOptions
                // Value: Local
                public string options;
            }

            public class DiskEncryptionSetParameters {
                
                public string id;

            }

            public class SecurityEncrytionTypes {

                public string DiskWithVMGuestState = "DiskWithVMGuestState";

                public string VMGuestStateOnly = "VMGuestStateOnly";

            }

            public class VMDiskSecurityProfile {

                public DiskEncryptionSetParameters diskEncryptionSet;

                // Type:  SecurityENcrytionTypes
                // Value DiskWithVMGuestState, VMGuestStateOnly
                public string securityEncryptionType;

            }

            public class StorageAccountTypes {
                
                public static string  PRemiumV2_LRS = "PRemiumV2_LRS";
               
                public static string  Premium_LRS = "Premium_LRS";
               
                public static string  Premium_ZRS = "Premium_ZRS";

                public static string  StandardSSD_LRS = "StandardSSD_LRS";

                public static string  StandardSSD_ZRS = "StandardSSD_ZRS";

                public static string  Standard_LRS = "Standard_LRS";

                public static string  UltraSSD_LRS = "UltraSSD_LRS";
                
            }
            public class ManagedDiskParameters {
                
                public DiskEncryptionSetParameters diskEncryptionSet;

                public string id;

                public VMDiskSecurityProfile securityProfile;

                // Type:  StorageAccountTypes
                // Value: ...
                public string storageAccountType;
            }

            public class OperatingSystemTypes {

                public static string Linux = "Linux";

                public static string Windows = "Windows";
            }

            public class VirtualHardDisk {

                public string uri;
            }
            public class Disk {
                
                // Type:  CachingTypes
                // Value: None, ReadOnly, ReadWrite
                public string caching;

                // Type:  DiskCreateOptionTypes
                // Value: Attach, Empty, FromImage
                public string createOptions;

                // Type:  DiskDeleteOptionTypes
                // Value: Delete, Detach
                public string deleteOption;

                public int diskSizeGB;

                /*

                public VirtualHardDisk image;

                */

                public ManagedDiskParameters managedDisk;

                public string name;



                public VirtualHardDisk vhd;

                public bool writeAcceleratorEnabled;

            }

            public class OSDisk: Disk {

                // Type:  OperatingSystemTypes
                // Value: Linux, Windows
                public string osType;

                /*
                
                public DiskEncryptionSettings encryptionSettings

                */
            }

            public class DiskDetachOptionTypes {

                public static string ForceDetach = "ForceDetach";
            }

            public class DataDisk: Disk {

                // Type:  DiskDetachOptionTypes
                // Value: ForceDetach
                public string detachOption;

                public int diskIOSReadWrtite;

                public int diskMBpsReadWrite;

                public int lun;

                public bool toBeDetach;
            }

            public class ImageReference {

                public string communityGalleryImageId;

                public string exactVersion;

                public string offer;

                public string publisher;

                public string shareGalleryImageId;

                public string sku;

                public string verison;

                public override string ToString()
                {
                    return offer + sku;
                }
            }

            public class StorageProfile {

                public DataDisk[] dataDisks;

                public OSDisk oSDisk;

                public ImageReference imageReference;
            }

            #endregion

            #region 虚拟机配置汇总
            public class CreateOrUpdateVMProperties
            {
                public HardWareProfile hardWareProfile;

                public NetworkProfile networkProfile;

                public OSProfile osProfile;

                public StorageProfile storageProfile;

                /*
                
                public AdditionalCapabilities addtionalCapabilities;

                public ApplicationProfile applicationProfile;

                public SubResource availabilitySet;

                public BillingProfile billingProfile;

                public CapacityReservationProfile capacityReservation;

                public DiagnosticsProfile diagnosticProfile;

                public VirtualMachineEvictionPolicyTypes evictionPolicy;

                public string extensionsTumeBuget;

                public SubResource host;

                public string licenseType;

                public int platformFaultDomain;;

                public VirtualMachinePrioityTypes priority;

                public SubResource proximityPlacementGroup;

                public SecurityProfile securityProfile;

                public string userData;

                public SubResource virtualMachineScaleSet;

                */

            }

            #endregion

            public class CreateOrUpdateVMBody
            {
                public string location;

                /*
                
                public ExtendedLocation extendedLocation;

                public VirtualMachineIdentity identity;

                public Plan plan;
                
                */

                public CreateOrUpdateVMProperties properties;

                public object tags;

                public string[] zones;
            }

            public class CreateOrUpdateVMUri
            {
                public string resourceGroupName;

                public string vmName;

            }

            public class CreateOrUpdateVMRequest : IRequest<
                CreateOrUpdateVMUri,
                CreateOrUpdateVMBody>
            {
                public CreateOrUpdateVMRequest()
                {
                    body = new CreateOrUpdateVMBody
                    {
                        properties = new CreateOrUpdateVMProperties
                        {
                            storageProfile = new StorageProfile { imageReference = new ImageReference() },
                            hardWareProfile = new HardWareProfile { vmSizeProperties = new VMSizeProperties() },
                            osProfile = new OSProfile { computerName = "", adminUsername = "", adminPassword = "" },
                            networkProfile = new NetworkProfile()
                        }
                    };
                    uri = new CreateOrUpdateVMUri { resourceGroupName = "", vmName = "" };
                }
            }
        }
    }


}
