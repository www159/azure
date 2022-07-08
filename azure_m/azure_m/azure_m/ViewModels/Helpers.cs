namespace azure_m.ViewModels {

    public static class Helpers {

        public static string deSerializeResourceGroup(string id) {
            //string str0 = id.Split("resourceGroups".ToCharArray())[1];
            string str = id.Split('/')[4];
            return str;
        }

    }
}