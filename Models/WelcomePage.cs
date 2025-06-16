using System.Collections.ObjectModel;
using AstVisualizerApp.ViewModels;
using Newtonsoft.Json.Linq;


namespace AstVisualizerApp.Models
{
    public class WelcomePage 
    {

        public ObservableCollection<string> TreeNodes;
        public WelcomePage(ObservableCollection<string> treeNodes)
        {
            TreeNodes = treeNodes;
        }
        public ObservableCollection<string> LoadTreeFromDatabase()
        {
            string json = "{ \"name\": \"root\", \"children\": [{ \"name\": \"child1\" }, { \"name\": \"child2\" }] }";
            
            var parsedTree = ParseJsonToTree(json);
            foreach (var node in parsedTree)
            {
                TreeNodes.Add(node);
            }

            return TreeNodes;
        }

        private IEnumerable<string> ParseJsonToTree(string json)
        {
            var treeNodes = new List<string>();
            void Traverse(JToken token, string prefix)
            {
                if (token is JObject obj)
                {
                    foreach (var property in obj.Properties())
                    {
                        var nodeName = $"{prefix}{property.Name}";
                        treeNodes.Add(nodeName);
                        Traverse(property.Value, $"{nodeName}/");
                    }
                }
            }

            var root = JObject.Parse(json);
            Traverse(root, string.Empty);
            return treeNodes;
        }
    }
}