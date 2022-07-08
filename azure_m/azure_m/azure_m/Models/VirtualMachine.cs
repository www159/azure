namespace azure_m.Models {

    public class VirtualMachine {

        public string id { get; set; }
        
        public string resourceGroup { get; set; }

        public string name { get; set; }

        public string osDiskSize { get; set; }
    }
}