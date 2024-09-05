using System.Text.Json;
using BTSexam.Models;
using BTSexam.Utils;

namespace BTSexam
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Importing the defences and create the Binary tree Search");
            await Task.Delay(4000);

            //import defenses from json
            string DefensesPath = "C:\\Users\\Mendel\\source\\repos\\BTSexam\\BTSexam\\DefenceStrategiesBalanced.Json";
            var defensesList = ReadFromJsonAsync<List<TreeNode>>(DefensesPath);
            

            //create the Binary Tree Search
            BinaryTreeSearch bts = new BinaryTreeSearch();
            //Insert the defences to the Tree
            defensesList.ForEach(bts.Insert);

            Console.WriteLine("Print the tree in PreOrder method");
            await Task.Delay(4000);
            //Print the Tree in PreOrder method
            bts.PreOrderTraversal(bts.root);

            Console.WriteLine("Importing the threats from json");
            await Task.Delay(4000);
            string ThreatsPath = "C:\\Users\\Mendel\\source\\repos\\BTSexam\\BTSexam\\Threats.Json";
            var threatsList = ReadFromJsonAsync<List<Threat>>(ThreatsPath);
            
            Console.WriteLine("Calculating the severity of the threat and responding to the threat");
                await Task.Delay(4000);

            foreach (Threat threat in threatsList)
            {
                
                int severity = Calc.ThreatSeverity(threat);
                TreeNode? defence = bts.PreOrderSearch(severity, bts.root);
                if (defence != null)
                    Console.WriteLine(string.Join(", ", defence.Defenses) + "\n");
                else
                    Console.WriteLine("Attack severity is below the threshold. Attack is ignored \n");
                await Task.Delay(2000);
            }


        }


        public static T? ReadFromJsonAsync<T>(string filePath, JsonSerializerOptions options = null)
        {
            try
            {
                options ??= new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                T? data = JsonSerializer.Deserialize<T>(
                    File.OpenRead(filePath),
                    options
                );
                return data;
            }
            catch (Exception ex)
            {
                return default;
            }
        }
    }
}
