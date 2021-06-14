using System;
using System.Text.Json;
using System.IO;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Comands cmd = new Comands();
            Content c = new Content();

            var path = File.ReadAllText(@"LastOpenPath.txt").Length > 0 ? File.ReadAllText(@"LastOpenPath.txt") : string.Empty;

            int maxWidth = Console.LargestWindowWidth;
            int maxHeight = Console.LargestWindowHeight;
            int widthFrame = maxWidth - 40;
            int heightFrame = maxHeight - 10;
            int count = 0;

            Frame frame = new Frame(2, 1, widthFrame, heightFrame);

            if (path.Length > 0)
            {
                string p = path.Substring(path.IndexOf(":\\") - 1, path.IndexOf("-p") - path.IndexOf(":\\"));
                c.OpenContent(p, int.Parse(path[path.Length - 1].ToString()));
            }
                
            
            while (true)
            {
                cmd.GetComands(4, heightFrame * 95 / 100 + count);

                count++;
                if (count == 3)
                    count = 0;

            }
        }
    }
}

