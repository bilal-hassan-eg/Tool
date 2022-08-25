using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binary_hex_binary_ECU
{
    internal class ReadScriptFile
    {
        public string pathSearch { get; set; }
        public string pathReplace { get; set; }
        public ReadScriptFile(string pathSearch, string pathReplace)
        {
            this.pathSearch=pathSearch;
            this.pathReplace=pathReplace;
        }
        public Tuple<List<string>,List<string>> Read()
        {
            List<string> dataReplace = new List<string>();
            List<string> dataSearch = new List<string>();
            
            string ContentSearch = File.ReadAllText(pathSearch);
            string ContentReplace = File.ReadAllText(pathReplace);
            string[] contentSearchByLine = ContentSearch.Split('\n');
            foreach(string item in contentSearchByLine)
            {
                string[] itemSpliter = item.Split(':');
                if (itemSpliter[0] != "" && itemSpliter[0] != null)
                {
                    dataSearch.Add(itemSpliter[0]);
                    string[] items1 = itemSpliter[1].Split('\r');
                    dataSearch.Add(items1[0]);
                }
            }
            string[] contentReplaceByLine = ContentReplace.Split('\n');
            foreach (string item in contentReplaceByLine)
            {
                string[] itemSpliter = item.Split(':');
                if (itemSpliter[0] != "" && itemSpliter[0] != null)
                {
                    dataReplace.Add(itemSpliter[0]);
                    string[] items1 = itemSpliter[1].Split('\r');
                    dataReplace.Add(items1[0]);
                }
            }
            return Tuple.Create(dataReplace, dataSearch);
        }
    }
}
