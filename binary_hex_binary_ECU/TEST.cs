using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace binary_hex_binary_ECU
{
    internal class TEST
    {

        public static List<byte> bytes;
        public EventHandler<IEVENT3> event_to_store_new_file;
        private string path_file;
        private Tuple<List<string>, List<string>> data;
        private string path_of_new_file;
        static List<bool> timer_of_searches;
        static int index_data = 0;

        public TEST(string path_file, Tuple<List<string>, List<string>> offest_to_edit, string path_of_new_file)
        {
            index_data = 0;
            timer_of_searches = new List<bool>();
            this.path_of_new_file = path_of_new_file;
            this.data = offest_to_edit;
            this.path_file = path_file;
        }

        public async Task Adapter()
        {
            try
            {
                lock ("")
                {
                    FileStream fsss = new FileStream(path_file, FileMode.OpenOrCreate);
                    BinaryReader binnn = new BinaryReader(fsss, Encoding.Default);
                    //MessageBox.Show("Start");
                    Console.WriteLine("start");
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    List<byte> chars1 = binnn.ReadBytes(Convert.ToInt32(binnn.BaseStream.Length)).ToList();
                    fsss.Close();
                    binnn.Close();
                    List<bool> check = new List<bool>();
                    Task.Run(() =>
                    {
                        Task.Run(() =>
                        {

                            try
                            {
                                for (int q = 0; q < data.Item2.Count; q+=2)
                                {
                                    string[] valsSearch = data.Item2[q + 1].Split(' ');
                                    string[] valsReplace = data.Item1[q + 1].Split(' ');
                                    for (int i = 0; i < (chars1.Count / 2) / 2; i++)
                                    {
                                        try
                                        {
                                            if (chars1[i] == Convert.ToByte(valsSearch[0]))
                                            {
                                                if (chars1[i + 1] == Convert.ToByte(valsSearch[1]))
                                                {
                                                    if (chars1[i + 2] == Convert.ToByte(valsSearch[2]))
                                                    {
                                                        List<string> array_of_data_to_check = new List<string>();
                                                        for (int y = 0; y < valsSearch.Length; y++)
                                                        {
                                                            if ((chars1.Count) - i > (valsSearch.Length))
                                                            {
                                                                try
                                                                {
                                                                    decimal dec = Convert.ToChar(chars1[i + y]);
                                                                    array_of_data_to_check.Add(dec.ToString());
                                                                }
                                                                catch { }
                                                            }
                                                        }
                                                        int counter = 0;
                                                        for (int y = 0; y < array_of_data_to_check.Count; y++)
                                                        {
                                                            if (array_of_data_to_check[y] == valsSearch[y])
                                                            {
                                                                int prev_offest = 0;
                                                                int offest = i;
                                                                if (prev_offest != offest)
                                                                {
                                                                    counter++;
                                                                    prev_offest = offest;
                                                                }
                                                                else { prev_offest = offest; }
                                                                if (counter == array_of_data_to_check.Count)
                                                                {
                                                                    string[] new_vals = data.Item1[q + 1].Split(' ');
                                                                    int offest_to_edit = i;
                                                                    for (int x = 0; x < new_vals.Length - 1; x++)
                                                                    {
                                                                        string hex = Convert.ToString(Convert.ToInt32(new_vals[x].Trim()), 16);
                                                                        string hex_test = Convert.ToString(Convert.ToInt32(new_vals[x]), 16);
                                                                        byte char_x = Convert.ToByte(Int16.Parse(hex, System.Globalization.NumberStyles.AllowHexSpecifier));

                                                                        chars1[offest_to_edit] = char_x;
                                                                        offest_to_edit++;
                                                                    }
                                                                }
                                                            }
                                                            else { break; }
                                                        }
                                                    }
                                                }

                                            }
                                        }
                                        catch { }

                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            check.Add(true);
                            if (check.Count == 4)
                            {
                                stopwatch.Stop();
                                INSERT_NEW_BIN1(chars1, path_of_new_file);
                                Console.WriteLine(stopwatch.ElapsedMilliseconds.ToString());
                            }
                        });


                        Task.Run(() =>
                        {

                            try
                            {
                                for (int q = 0; q < data.Item2.Count; q+=2)
                                {
                                    string[] valsSearch = data.Item2[q + 1].Split(' ');
                                    string[] valsReplace = data.Item1[q + 1].Split(' ');
                                    for (int i = (chars1.Count / 2) / 2; i < (chars1.Count / 2); i++)
                                    {
                                        try
                                        {
                                            if (chars1[i] == Convert.ToByte(valsSearch[0]))
                                            {
                                                if (chars1[i + 1] == Convert.ToByte(valsSearch[1]))
                                                {
                                                    if (chars1[i + 2] == Convert.ToByte(valsSearch[2]))
                                                    {
                                                        List<string> array_of_data_to_check = new List<string>();
                                                        for (int y = 0; y < valsSearch.Length; y++)
                                                        {
                                                            if ((chars1.Count) - i > (valsSearch.Length))
                                                            {
                                                                try
                                                                {
                                                                    decimal dec = Convert.ToChar(chars1[i + y]);
                                                                    array_of_data_to_check.Add(dec.ToString());
                                                                }
                                                                catch { }
                                                            }
                                                        }
                                                        int counter = 0;
                                                        for (int y = 0; y < array_of_data_to_check.Count; y++)
                                                        {
                                                            if (array_of_data_to_check[y] == valsSearch[y])
                                                            {
                                                                int prev_offest = 0;
                                                                int offest = i;
                                                                if (prev_offest != offest)
                                                                {
                                                                    counter++;
                                                                    prev_offest = offest;
                                                                }
                                                                else { prev_offest = offest; }
                                                                if (counter == array_of_data_to_check.Count)
                                                                {
                                                                    string[] new_vals = data.Item1[q + 1].Split(' ');
                                                                    int offest_to_edit = i;
                                                                    for (int x = 0; x < new_vals.Length - 1; x++)
                                                                    {
                                                                        string hex = Convert.ToString(Convert.ToInt32(new_vals[x].Trim()), 16);
                                                                        string hex_test = Convert.ToString(Convert.ToInt32(new_vals[x]), 16);
                                                                        byte char_x = Convert.ToByte(Int16.Parse(hex, System.Globalization.NumberStyles.AllowHexSpecifier));

                                                                        chars1[offest_to_edit] = char_x;
                                                                        offest_to_edit++;
                                                                    }
                                                                }
                                                            }
                                                            else { break; }
                                                        }
                                                    }
                                                }

                                            }
                                        }
                                        catch { }

                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            check.Add(true);
                            if (check.Count == 4)
                            {
                                stopwatch.Stop();
                                INSERT_NEW_BIN1(chars1, path_of_new_file);
                                Console.WriteLine(stopwatch.ElapsedMilliseconds.ToString());
                            }
                        });

                        Task.Run(() =>
                        {

                            for (int q = 0; q < data.Item2.Count; q+=2)
                            {
                                try
                                {
                                    string[] valsSearch = data.Item2[q + 1].Split(' ');
                                    string[] valsReplace = data.Item1[q + 1].Split(' ');
                                    for (int i = (chars1.Count / 2); i < ((chars1.Count / 2) / 2) * 3; i++)
                                    {
                                        try
                                        {
                                            if (chars1[i] == Convert.ToByte(valsSearch[0]))
                                            {
                                                if (chars1[i + 1] == Convert.ToByte(valsSearch[1]))
                                                {
                                                    if (chars1[i + 2] == Convert.ToByte(valsSearch[2]))
                                                    {
                                                        List<string> array_of_data_to_check = new List<string>();
                                                        for (int y = 0; y < valsSearch.Length; y++)
                                                        {
                                                            if ((chars1.Count) - i > (valsSearch.Length))
                                                            {
                                                                try
                                                                {
                                                                    decimal dec = Convert.ToChar(chars1[i + y]);
                                                                    array_of_data_to_check.Add(dec.ToString());
                                                                }
                                                                catch { }
                                                            }
                                                        }
                                                        int counter = 0;
                                                        for (int y = 0; y < array_of_data_to_check.Count; y++)
                                                        {
                                                            if (array_of_data_to_check[y] == valsSearch[y])
                                                            {
                                                                int prev_offest = 0;
                                                                int offest = i;
                                                                if (prev_offest != offest)
                                                                {
                                                                    counter++;
                                                                    prev_offest = offest;
                                                                }
                                                                else { prev_offest = offest; }
                                                                if (counter == array_of_data_to_check.Count)
                                                                {
                                                                    string[] new_vals = data.Item1[q + 1].Split(' ');
                                                                    int offest_to_edit = i;
                                                                    for (int x = 0; x < new_vals.Length - 1; x++)
                                                                    {
                                                                        string hex = Convert.ToString(Convert.ToInt32(new_vals[x].Trim()), 16);
                                                                        string hex_test = Convert.ToString(Convert.ToInt32(new_vals[x]), 16);
                                                                        byte char_x = Convert.ToByte(Int16.Parse(hex, System.Globalization.NumberStyles.AllowHexSpecifier));

                                                                        chars1[offest_to_edit] = char_x;
                                                                        offest_to_edit++;
                                                                    }
                                                                }
                                                            }
                                                            else { break; }
                                                        }
                                                    }
                                                }

                                            }
                                        }
                                        catch { }

                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }


                            check.Add(true);
                            if (check.Count == 4)
                            {
                                stopwatch.Stop();
                                INSERT_NEW_BIN1(chars1, path_of_new_file);
                                Console.WriteLine(stopwatch.ElapsedMilliseconds.ToString());
                            }

                        });
                        Task.Run(() =>
                        {

                            for (int q = 0; q < data.Item2.Count; q+=2)
                            {
                                try
                                {
                                    string[] valsSearch = data.Item2[q + 1].Split(' ');
                                    string[] valsReplace = data.Item1[q + 1].Split(' ');
                                    for (int i = ((chars1.Count / 2) /2) * 3; i < ((chars1.Count / 2) / 2) * 4; i++)
                                    {
                                        try
                                        {
                                            if (chars1[i] == Convert.ToByte(valsSearch[0]))
                                            {
                                                if (chars1[i + 1] == Convert.ToByte(valsSearch[1]))
                                                {
                                                    if (chars1[i + 2] == Convert.ToByte(valsSearch[2]))
                                                    {
                                                        List<string> array_of_data_to_check = new List<string>();
                                                        for (int y = 0; y < valsSearch.Length; y++)
                                                        {
                                                            if ((chars1.Count) - i > (valsSearch.Length))
                                                            {
                                                                try
                                                                {
                                                                    decimal dec = Convert.ToChar(chars1[i + y]);
                                                                    array_of_data_to_check.Add(dec.ToString());
                                                                }
                                                                catch { }
                                                            }
                                                        }
                                                        int counter = 0;
                                                        for (int y = 0; y < array_of_data_to_check.Count; y++)
                                                        {
                                                            if (array_of_data_to_check[y] == valsSearch[y])
                                                            {
                                                                int prev_offest = 0;
                                                                int offest = i;
                                                                if (prev_offest != offest)
                                                                {
                                                                    counter++;
                                                                    prev_offest = offest;
                                                                }
                                                                else { prev_offest = offest; }
                                                                if (counter == array_of_data_to_check.Count)
                                                                {
                                                                    string[] new_vals = data.Item1[q + 1].Split(' ');
                                                                    int offest_to_edit = i;
                                                                    for (int x = 0; x < new_vals.Length - 1; x++)
                                                                    {
                                                                        string hex = Convert.ToString(Convert.ToInt32(new_vals[x].Trim()), 16);
                                                                        string hex_test = Convert.ToString(Convert.ToInt32(new_vals[x]), 16);
                                                                        byte char_x = Convert.ToByte(Int16.Parse(hex, System.Globalization.NumberStyles.AllowHexSpecifier));

                                                                        chars1[offest_to_edit] = char_x;
                                                                        offest_to_edit++;
                                                                    }
                                                                }
                                                            }
                                                            else { break; }
                                                        }
                                                    }
                                                }

                                            }
                                        }
                                        catch { }

                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }


                            check.Add(true);
                            if (check.Count == 4)
                            {
                                stopwatch.Stop();
                                INSERT_NEW_BIN1(chars1, path_of_new_file);
                                Console.WriteLine(stopwatch.ElapsedMilliseconds.ToString());
                            }

                        });

                    }).Wait();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }



        public void Adapter1()
        {
            FileStream fsss = new FileStream(path_file, FileMode.OpenOrCreate);
            BinaryReader binnn = new BinaryReader(fsss, Encoding.Default);
            Console.WriteLine("Start");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<byte> chars1 = binnn.ReadBytes(Convert.ToInt32(binnn.BaseStream.Length)).ToList();
            fsss.Close();
            binnn.Close();
            List<bool> check = new List<bool>();
            Task.Run(() =>
            {
                Task.Run(() =>
                {

                    try
                    {
                        for (int q = 0; q < data.Item2.Count / 2; q+=2)
                        {
                            string[] valsSearch = data.Item2[q + 1].Split(' ');
                            string[] valsReplace = data.Item1[q + 1].Split(' ');
                            for (int i = 0; i < chars1.Count / 2; i++)
                            {
                                try
                                {
                                    if (chars1[i] == Convert.ToByte(valsSearch[0]))
                                    {
                                        if (chars1[i + 1] == Convert.ToByte(valsSearch[1]))
                                        {
                                            if (chars1[i + 2] == Convert.ToByte(valsSearch[2]))
                                            {
                                                List<string> array_of_data_to_check = new List<string>();
                                                for (int y = 0; y < valsSearch.Length; y++)
                                                {
                                                    if ((chars1.Count) - i > (valsSearch.Length))
                                                    {
                                                        try
                                                        {
                                                            decimal dec = Convert.ToChar(chars1[i + y]);
                                                            array_of_data_to_check.Add(dec.ToString());
                                                        }
                                                        catch { }
                                                    }
                                                }
                                                int counter = 0;
                                                for (int y = 0; y < array_of_data_to_check.Count; y++)
                                                {
                                                    if (array_of_data_to_check[y] == valsSearch[y])
                                                    {
                                                        int prev_offest = 0;
                                                        int offest = i;
                                                        if (prev_offest != offest)
                                                        {
                                                            counter++;
                                                            prev_offest = offest;
                                                        }
                                                        else { prev_offest = offest; }
                                                        if (counter == array_of_data_to_check.Count)
                                                        {
                                                            string[] new_vals = data.Item1[q + 1].Split(' ');
                                                            int offest_to_edit = i;
                                                            for (int x = 0; x < new_vals.Length - 1; x++)
                                                            {
                                                                string hex = Convert.ToString(Convert.ToInt32(new_vals[x].Trim()), 16);
                                                                string hex_test = Convert.ToString(Convert.ToInt32(new_vals[x]), 16);
                                                                byte char_x = Convert.ToByte(Int16.Parse(hex, System.Globalization.NumberStyles.AllowHexSpecifier));

                                                                chars1[offest_to_edit] = char_x;
                                                                offest_to_edit++;
                                                            }
                                                        }
                                                    }
                                                    else { break; }
                                                }
                                            }
                                        }

                                    }
                                }
                                catch { }

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    check.Add(true);
                    if (check.Count == 2)
                    {
                        INSERT_NEW_BIN1(chars1, path_of_new_file);
                        stopwatch.Stop();
                        Console.WriteLine(stopwatch.ElapsedMilliseconds.ToString());
                    }
                });

                Task.Run(() =>
                {

                    for (int q = 0; q < data.Item2.Count; q+=2)
                    {
                        try
                        {
                            string[] valsSearch = data.Item2[q + 1].Split(' ');
                            string[] valsReplace = data.Item1[q + 1].Split(' ');
                            for (int i = (chars1.Count / 2); i < chars1.Count; i++)
                            {
                                try
                                {
                                    if (chars1[i] == Convert.ToByte(valsSearch[0]))
                                    {
                                        if (chars1[i + 1] == Convert.ToByte(valsSearch[1]))
                                        {
                                            if (chars1[i + 2] == Convert.ToByte(valsSearch[2]))
                                            {
                                                List<string> array_of_data_to_check = new List<string>();
                                                for (int y = 0; y < valsSearch.Length; y++)
                                                {
                                                    if ((chars1.Count) - i > (valsSearch.Length))
                                                    {
                                                        try
                                                        {
                                                            decimal dec = Convert.ToChar(chars1[i + y]);
                                                            array_of_data_to_check.Add(dec.ToString());
                                                        }
                                                        catch { }
                                                    }
                                                }
                                                int counter = 0;
                                                for (int y = 0; y < array_of_data_to_check.Count; y++)
                                                {
                                                    if (array_of_data_to_check[y] == valsSearch[y])
                                                    {
                                                        int prev_offest = 0;
                                                        int offest = i;
                                                        if (prev_offest != offest)
                                                        {
                                                            counter++;
                                                            prev_offest = offest;
                                                        }
                                                        else { prev_offest = offest; }
                                                        if (counter == array_of_data_to_check.Count)
                                                        {
                                                            string[] new_vals = data.Item1[q + 1].Split(' ');
                                                            int offest_to_edit = i;
                                                            for (int x = 0; x < new_vals.Length - 1; x++)
                                                            {
                                                                string hex = Convert.ToString(Convert.ToInt32(new_vals[x].Trim()), 16);
                                                                string hex_test = Convert.ToString(Convert.ToInt32(new_vals[x]), 16);
                                                                byte char_x = Convert.ToByte(Int16.Parse(hex, System.Globalization.NumberStyles.AllowHexSpecifier));

                                                                chars1[offest_to_edit] = char_x;
                                                                offest_to_edit++;
                                                            }
                                                        }
                                                    }
                                                    else { break; }
                                                }
                                            }
                                        }

                                    }
                                }
                                catch { }

                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }


                    check.Add(true);
                    if (check.Count == 2)
                    {
                        INSERT_NEW_BIN1(chars1, path_of_new_file);
                        stopwatch.Stop();
                        Console.WriteLine(stopwatch.ElapsedMilliseconds.ToString());
                    }
                });


            }).Wait();

        }
        public static void INSERT_NEW_BIN1(List<byte> chars, string PathNewFile)
        {
            try
            {
                FileStream fs = new FileStream(PathNewFile, FileMode.OpenOrCreate);
                BinaryWriter bin = new BinaryWriter(fs, Encoding.Unicode, false);
                bin.Write(chars.ToArray());
                bin.Close();
                fs.Close();
                Console.WriteLine("Finish :)");
            }
            catch(Exception ex)
            {
                Console.WriteLine (ex.Message);
            }

        }
    }
    class IEVENT3 : EventArgs
    {
        public int counter;
        public string path_file;
        public List<byte> chars1;
        public int number_of_all_edits;
        public IEVENT3(int counter, string path_file, ref List<byte> chars1, int number_of_all_edits)
        {
            this.chars1 = chars1;
            this.path_file = path_file;
            this.counter = counter;
            this.number_of_all_edits = number_of_all_edits;
        }
    }
}
