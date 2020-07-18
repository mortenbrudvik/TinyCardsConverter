using System;
using System.IO;

namespace TinyCardsConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.Out.WriteLine("Please provide file path to TinyCards csv file to convert");
                return;
            }

            var filePath = args[0];
            if( !File.Exists(filePath))
            {
                Console.Out.WriteLine("Missing file at path provided: " + filePath);
                return;
            }

            try
            {
                var cardData = File.ReadAllText(filePath);
                var cardConverter = new TinyCardsConverter();
                var decks = cardConverter.Convert(cardData);

                Console.Out.WriteLine("Data conversion completed! ");
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to convert data. Error message: " + e.Message);
            }
        }
    }
}
