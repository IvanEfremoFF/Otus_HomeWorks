using System.IO;
using System.Linq.Expressions;
using System.Text;

namespace FilesAndDirectories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string otusPath = @"c:\Otus\";
            string test1Path = @"c:\Otus\Test1";
            string test2Path = @"c:\Otus\Test2";
            string fileNameLayout = @"FileX.txt";

            CreateDirectory(otusPath);
            CreateDirectory(test1Path);
            CreateDirectory(test2Path);

            CreateFiles(test1Path, fileNameLayout);
            CreateFiles(test2Path, fileNameLayout);

            AddFileNameToFiles(test1Path);
            AddFileNameToFiles(test2Path);

            AppendDateToFileAsync(test1Path);
            AppendDateToFileAsync(test2Path);

            ReadDateFromFile(test1Path);
            ReadDateFromFile(test2Path);


        }

        static void CreateDirectory(string fodlerName)
        {
            
            if (!Directory.Exists(fodlerName))
            {
                DirectoryInfo _newDirectory = new DirectoryInfo(fodlerName);
                _newDirectory.Create();
            }

        }

        static void CreateFiles(string path, string fileNameLayout)
        {

            for (int i = 1; i <= 10; i++)
            {
                string fileName = fileNameLayout.Replace("X", i.ToString());
                string fullPath = Path.Combine(path, fileName);

                if (File.Exists(fullPath))
                {
                    continue;
                }
                else
                {
                    using (FileStream _fs = File.Create(fullPath)) { }                        
                }
            }
        }

        private static async void AddFileNameToFiles(string path)
        {
            for (int i = 1; i <= 10; i++)
            {
                string fullPath = Path.Combine(path, $"File{i}.txt");

                if (File.Exists(fullPath))
                {
                    try
                    {
                        using (StreamWriter _streamWriter = new StreamWriter(new FileStream(fullPath, FileMode.Append), Encoding.UTF8))
                        {
                            await _streamWriter.WriteLineAsync($"File{i}.txt");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine($"Error on writing info to file: {fullPath}");
                }
            }
        }

        private static async void AppendDateToFileAsync(string path)
        {
            string _dateTimeNow = DateTime.Now.ToString();

            for (int i = 1; i <= 10; i++)
            {
                string fullPath = Path.Combine(path, $"File{i}.txt");

                try
                {
                    using (StreamWriter _streamWriter = new StreamWriter(new FileStream(fullPath, FileMode.Append),Encoding.UTF8))
                    {
                        await _streamWriter.WriteLineAsync(_dateTimeNow);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void ReadDateFromFile(string path)
        {
            foreach (FileInfo _file in new DirectoryInfo(path).GetFiles())
            {
                try
                {
                    using (FileStream _fs = File.OpenRead(_file.FullName))
                    {
                        Console.WriteLine($"\nFILE INFO: \n\t- name {_file.Name} \n\t- full path {_file.FullName}");
                        Console.WriteLine($"\t- date/time of creation: {_file.CreationTime}");
                        Console.WriteLine($"\nStart reading...\n");
                        Console.WriteLine(File.ReadAllText(_file.FullName));
                        Console.WriteLine($"Reading completed.\n");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
}
