using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace TinyCardsConverter
{
    public static class JSONExport
    {
        public static void Export(string fileName, string imageFolder, List<CardDeck> decks)
        {
            if (!Directory.Exists(imageFolder))
                Directory.CreateDirectory(imageFolder);

            var webClient = new WebClient();
            Console.Out.WriteLine("Downloading of deck images");
            foreach (var deck in decks)
            {
                if (deck.CoverImagePath.Trim().Length <= 0) continue;

                var imageFilePath = $"{imageFolder}\\{Guid.NewGuid()}.jpeg";
                Console.Out.WriteLine($"Downloading image \"{deck.CoverImagePath}\" to {imageFilePath} from deck {deck.Name}");
                webClient.DownloadFile(deck.CoverImagePath, imageFilePath);
                deck.CoverImagePath = imageFilePath;
            }
            var jsonData = JsonConvert.SerializeObject(decks, Formatting.Indented);
            File.WriteAllText(fileName, jsonData);
        }
    }
}