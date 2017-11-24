//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Xml.Linq;
//using Newtonsoft.Json;

//namespace Moravia.Homework
//{
//    public class Document
//    {
//        public string Title { get; set; }
//        public string Text { get; set; }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\Document1.xml");
//            var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.json");

//            try
//            {
//                FileStream sourceStream = File.Open(sourceFileName, FileMode.Open);
//Chyba tu using. Alebo da sa pridat nakonci vo finaly bloku uvolnenie cez interface ako to microsoft pise tu https://docs.microsoft.com/cs-cz/dotnet/csharp/language-reference/keywords/using-statement
//Niektori programatori veria ze using je nejaky magicky prikaz . Pravda je taka ze microsoft otvorene hovori ze aj tak sa vytvori pocas compile time namiesto toho finaly block a zavola sa interface.
//Toto plati pre vsetky komentare typu "chyba tu using".

//                var reader = new StreamReader(sourceStream);
//                //chyba tu using

//                string input = reader.ReadToEnd();
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//ak vytvorite jednu jedinu custom exception budete presne vediet kde v kode nastala.
// custom excetions umoznuju napriklad aj automaticke logovanie, zobrazovanie vnutorneho stavu programu kedy exception nastala , posielanie cez service a podobne...
//            }

//            var xdoc = XDocument.Parse(input);
//            //input premenna neexistuje 
//            var doc = new Document
//            {
//                Title = xdoc.Root.Element("title").Value,
//                Text = xdoc.Root.Element("text").Value
//            };
//            //stringy by mali byt definovane ako konstanta

//            var serializedDoc = JsonConvert.SerializeObject(doc);
// Nehandluje sa tu exception. Exception treba pridat pretoze je to serializacia, je mozne ze nieco v instancii doc neojde zoserializovat.



//            var targetStream = File.Open(targetFileName, FileMode.Create, FileAccess.Write);
//               // nepouziva sa tu using
//            var sw = new StreamWriter(targetStream);
//            //chyba tu using
//            sw.Write(serializedDoc);
//            // chyba tu flush
// Nehandluje sa tu exception. Exception treba pridat pretoze su to io operacie  a operacie so streami.

//        }
//    }
//}
