using System.IO;
namespace binary_hex_binary_ECU
{
    class Program
    {
        static public async Task Main(string[] args)
        {
            Console.WriteLine("Hello IN Editing BIN file ");

            Console.WriteLine("Enter Path of BIN File :");
            string path_binfile = File.ReadAllText("./PathBIN.txt");
            Console.WriteLine("Enter Path of Replace Script :");
            string path_Replace = File.ReadAllText("./scriptReplace.txt");
            Console.WriteLine("Enter Path of New Bin file :");
            string path_new_file = File.ReadAllText("./NewBin.txt");
            Console.WriteLine("Enter Path of Search Command : ");
            string path_Search = File.ReadAllText("./scriptSearch.txt");
            //string path_Search = File.ReadAllText("./SearchScript.txt");
            Tuple<List<string>, List<string>> data;
            //edit_hex_file editor = new edit_hex_file(path_Replace);

            //data = editor.Edit();

            ReadScriptFile readScriptFile = new ReadScriptFile(path_Search, path_Replace);
            data = readScriptFile.Read();
                TEST bin_hex = new TEST(path_binfile, data, path_new_file);
                await bin_hex.Adapter();
            /*File.Delete("./PathBIN.txt");
            File.Delete("./PathBIN.");
            File.Delete("./PathBIN.txt");*/
            Thread.Sleep(150);
        }
    }
}