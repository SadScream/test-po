using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IlyaTestMet
{
    public static class FileModule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath">ПОЛНЫЙ путь к файлу</param>
        /// <param name="values"></param>
        /// <exception cref="Exception"></exception>
        public static void WriteToFile(string filePath, double[] values)
        {
            FilePathCkecker(filePath);

            if (values.Length == 0)
                throw new Exception("Массив значений не может быть пуст");

            // Создает новый файл, записывает в него одну или несколько строк, затем закрывает файл.
            // Если целевой файл уже существует, он будет переопределен.
            File.WriteAllLines(
                filePath,
                values.Select(x => Convert.ToString(x))
            );
        }

        /// <summary>
        /// В бесконечном цикле просит ввести название файла до тех пор,
        /// пока не будет введено корректное название.
        /// </summary>
        /// <returns>Полный путь к файлу, относительно запущенного экзешника</returns>
        public static string AskForFileName()
        {
            while (true)
            {
                string filepath;

                try
                {
                    Console.WriteLine($"Введите путь к файлу: ");
                    filepath = Console.ReadLine();

                    FilePathCkecker(filepath);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                return filepath;
            }
        }

        private static void FilePathCkecker(string filepath)
        {
            string filename = Path.GetFileName(filepath);

            if (filename == string.Empty || filename == null)
            {
                throw new Exception("Неверное название файла");
            }

            List<string> pathParts = filepath.Split("\\").ToList();

            pathParts.RemoveAt(pathParts.Count() - 1);

            var pathWithoutFilename = String.Join("\\", pathParts);

            FilenameChecker(filename);
            PathChecker(pathWithoutFilename);
        }

        private static void PathChecker(string path)
        {
            Console.WriteLine(path);
            if (!Directory.Exists(path))
            {
                throw new Exception("Неверный путь к файлу");
            }
        }

        /// <summary>
        /// Проверяет название файла по 2 критерям:
        ///		1. Не является ли оно пустым
        ///		2. Не состоит ли оно из запрещенных символов
        ///	Если название не удовлетворяет критерям, вызывается ошибка
        /// </summary>
        /// <param name="filename"></param>
        /// <exception cref="Exception">Неверное имя файла</exception>
        private static void FilenameChecker(string filename)
        {
            var isValid = !string.IsNullOrEmpty(filename) &&
              filename.IndexOfAny(Path.GetInvalidFileNameChars()) < 0;

            if (!isValid)
                throw new Exception("Неверное имя файла");
        }
    }
}
