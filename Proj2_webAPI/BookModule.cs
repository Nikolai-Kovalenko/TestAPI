using Nancy;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using Newtonsoft.Json;

namespace Proj2_webAPI
{
    public class BookModule : NancyModule
    {
        public BookModule()
        {
            Get("/nancy-api/{Content}/", parameters =>
            {
                return string.Concat("Hallo ", parameters.Content);
            });

            // add new book in txt format
            Get("/nancy-api/add/txt/{book}/", parameters => {

                using (StreamWriter writer = new StreamWriter(Const.BookTxtFilePath, append: true)) // append: true означает, что данные будут добавляться в конец файла
                {
                    writer.WriteLine((string)parameters.Book);
                }

                return string.Concat(parameters.Book, " addeted!" );
            });

            // add new book in json format 
            Get("/nancy-api/add/json/{book}/", parameters =>
            {
                string lastLine = null;
                using (StreamReader reader = new StreamReader(Const.BookJsonFilePath))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        lastLine = line;
                    }
                }

                int lastID = 1;

                if (lastLine == null)
                {
                    Console.WriteLine("Books is not find");
                }
                else
                {
                    try
                    {
                        var lastBook = JsonConvert.DeserializeObject<Book>(lastLine);
                        lastID = lastBook.ID + 1;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error deserializing last book: " + ex.Message);
                    }
                }

                var book = new
                {
                    ID = lastID,
                    Name = (string)parameters.Book
                };

                string json = JsonConvert.SerializeObject(book);


                using (StreamWriter writer = new StreamWriter(Const.BookJsonFilePath, append: true))
                {
                    writer.WriteLine(json);
                }

                return string.Concat(parameters.Book, " addeted!");
            });

        }
    }
}
