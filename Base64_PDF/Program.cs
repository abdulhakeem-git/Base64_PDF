using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Base64_PDF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConvertT cnv = new ConvertT();
            cnv.start();

            //cnv.Base64toPDF();
            //cnv.PDFtoBase64();
            WriteLine("Press any key to exit ...");
            ReadKey(true);

        }
    }
}
