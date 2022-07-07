using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher
{
    internal class PathManager
    {
        public static string Bin = Directory.GetCurrentDirectory() + @"\bin";
        public static string Game = Bin + @"\game";
        public static string Dynastio = Game + @"\Dynast.io.exe";
        public static string Version = Game + @"\version.txt";
        public static string DownloadGame = PathManager.Bin + @"\download";
    }

}
