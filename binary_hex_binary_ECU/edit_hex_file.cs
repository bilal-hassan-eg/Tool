using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binary_hex_binary_ECU
{
    internal class edit_hex_file
    {
        private string path_Replace;
        public edit_hex_file(string path_Replace)
        {
            this.path_Replace = path_Replace;
        }
        public Tuple<List<string>,List<string>> Edit()
        {
            Console.WriteLine(path_Replace);
            List<string> data = new List<string>();
            List<string> searches = new List<string>();
            string script_data = File.ReadAllText(path_Replace);
            string script_dataReplace = File.ReadAllText(path_Replace);
            string[] get_data_importans = script_data.Split("begin_executable");
            string[] number_lines = get_data_importans[1].Split('\n');
            for(int i = 0; i < number_lines.Length; i++)
            {
                //Console.WriteLine(number_lines[i]);

                string[] arr_script = number_lines[i].Split("   ");
                for(int q = 1; q < arr_script.Length; q++)
                {
                    string[] type_of_command = arr_script[q].Split(' ');
                    string[] numbers = arr_script[q].Split('"');
                    if (type_of_command[0].Trim() == "replace")
                    {
                        data.Add(type_of_command[3]);
                        data.Add(numbers[1]);
                    }
                    if (type_of_command[0].Trim() == "search")
                    {
                        searches.Add(type_of_command[3]);
                        searches.Add(numbers[1]);
                    }
                }

            }

            return Tuple.Create(data,searches) ;
        }
    }
}
