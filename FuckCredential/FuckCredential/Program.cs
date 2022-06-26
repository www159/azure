// See https://aka.ms/new-console-template for more information
using Azure.Identity;
using Azure.ResourceManager;
using Azure.Core;
using System.Diagnostics;
class Program
{

    //public string myClientId = "219b2431-594f-47fa-8e85-664196aa3f92";
    public static async Task Main(string[] args)
    {

        var prog = new Program();
        try
        {
            ar credential = new DefaultAzureCredential();
            Console.WriteLine();
        }
        catch(Exception e)
        {
            Debug.WriteLine(e);
        };
    }
}