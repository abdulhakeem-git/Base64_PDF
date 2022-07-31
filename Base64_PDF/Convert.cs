using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Base64_PDF
{
    internal class ConvertT
    {
        public void start()
        {
            Title = "Base64 <--> PDF";
            RunMainMenu();

        }

        private void RunMainMenu()
        {
            string prompt = @"

  ____                   __ _  _       ____                  ____     _____  _____  ______ 
 |  _ \                 / /| || |     / / /_____ ______ _____\ \ \   |  __ \|  __ \|  ____|
 | |_) | __ _ ___  ___ / /_| || |_   / / /______|______|______\ \ \  | |__) | |  | | |__   
 |  _ < / _` / __|/ _ \ '_ \__   _| < < < ______ ______ ______ > > > |  ___/| |  | |  __|  
 | |_) | (_| \__ \  __/ (_) | | |    \ \ \______|______|______/ / /  | |    | |__| | |     
 |____/ \__,_|___/\___|\___/  |_|     \_\_\                  /_/_/   |_|    |_____/|_|     

Welcome to Base64 <--> PDF Converter!

(Use the arrow keys to cycle through the options and press Enter to select an option)

";
            string[] options = { "1. Convert base64 to PDF", "2. Convert PDF to base64", "3. Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectecIntex = mainMenu.Run();

            switch (selectecIntex)
            {
                case 0:
                    Base64toPDF();
                    break;
                case 1:
                    PDFtoBase64();
                    break;
                case 2:
                    Exit();
                    break;
            }
        }
        private void Base64toPDF()
        {
            Clear();
            int selectedIndex;
            string prompt = @"
  ____                  __   _  _                     ____    ____  ____  _____ 
 | __ )  __ _ ___  ___ / /_ | || |    _____ _____ ____\ \ \  |  _ \|  _ \|  ___|
 |  _ \ / _` / __|/ _ \ '_ \| || |_  |_____|_____|_____\ \ \ | |_) | | | | |_   
 | |_) | (_| \__ \  __/ (_) |__   _| |_____|_____|_____/ / / |  __/| |_| |  _|  
 |____/ \__,_|___/\___|\___/   |_|                    /_/_/  |_|   |____/|_|    
                                                                                

(Use the arrow keys to cycle through the file name and press Enter to select the file to convert to PDF ...)

";
            string[] options = Directory.GetFiles(@Directory.GetCurrentDirectory(), "*.txt");
            Array.Resize(ref options, options.Length + 1);
            options[options.Length - 1] = "Exit";

            //Console.WriteLine(options.Length);

            if (options.Length >= 2)
            {
                Menu basetoPDFMenu = new Menu(prompt, options);
                selectedIndex = basetoPDFMenu.Run();

                if (options[selectedIndex] != null)
                {
                    Base64toPDFConvert(options[selectedIndex]);
                }
            }
            else
            {
                string[] options1 = { "No Text file available to convert. First create a txt file containing Base64 code and run the Program" };
                Menu basetoPDFMenu = new Menu(prompt, options1);
                selectedIndex = basetoPDFMenu.Run();
            }

            if (selectedIndex != options.Length - 1)
            {
                WriteLine("\n Press any key to go to Main Menu ...");
                ReadKey(true);
            }

            RunMainMenu();
        }

        private void PDFtoBase64()
        {
            Clear();
            int selectedIndex;
            string prompt = @"
 
  ____  ____  _____                   ____    ____                  __   _  _   
 |  _ \|  _ \|  ___|  _____ _____ ____\ \ \  | __ )  __ _ ___  ___ / /_ | || |  
 | |_) | | | | |_    |_____|_____|_____\ \ \ |  _ \ / _` / __|/ _ \ '_ \| || |_ 
 |  __/| |_| |  _|   |_____|_____|_____/ / / | |_) | (_| \__ \  __/ (_) |__   _|
 |_|   |____/|_|                      /_/_/  |____/ \__,_|___/\___|\___/   |_|  
  

(Use the arrow keys to cycle through the PDF file names and press Enter to select the file to convert to Base-64 ...)

";
            string[] options = Directory.GetFiles(@Directory.GetCurrentDirectory(), "*.pdf");
            Array.Resize(ref options, options.Length + 1);
            options[options.Length - 1] = "Exit";

            //Console.WriteLine(options.Length);

            if (options.Length >= 2)
            {
                Menu basetoPDFMenu = new Menu(prompt, options);
                selectedIndex = basetoPDFMenu.Run();

                if (options[selectedIndex] != null)
                {
                    PDFtoBase64Convert(options[selectedIndex]);
                }
            }
            else
            {
                string[] options1 = { "No PDF file available to convert. First load a PDF file in the same path as this Program and re-run it" };
                Menu basetoPDFMenu = new Menu(prompt, options1);
                selectedIndex = basetoPDFMenu.Run();
            }

            if (selectedIndex != options.Length - 1)
            {
                WriteLine("\n Press any key to go to Main Menu ...");
                ReadKey(true);
            }


            RunMainMenu();
        }

        private void Exit()
        {
            //Clear();
            //WriteLine("\n Press any key to Exit ...");
            //ReadKey(true);
            Environment.Exit(0);
        }

        private void Base64toPDFConvert(string baseFile)
        {
            if (baseFile != "Exit")
            {
                WriteLine(Path.GetFileName(baseFile));
                string fileName = Path.GetFileName(baseFile).Split('.')[0] + ".pdf";

                try
                {
                    string base64BinaryString = File.ReadAllText(Path.GetFileName(baseFile));
                    WriteLine();
                    //WriteLine (base64BinaryString);            
                    byte[] bytes = Convert.FromBase64String(base64BinaryString);
                    File.WriteAllBytes(fileName, bytes);
                    Write("\nPDF file \"");
                    ForegroundColor = ConsoleColor.Green;
                    Write("{0}", fileName);
                    ResetColor();
                    WriteLine("\" created Successfully!");
                }
                catch (FormatException e)
                {
                    ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(e.Message);
                    WriteLine("\nCorrect the file and try again!");
                    ResetColor();
                }

            }

            //WriteLine("Exiting to Main Menu ...");

        }

        private void PDFtoBase64Convert(string baseFile)
        {
            if (baseFile != "Exit")
            {
                WriteLine(Path.GetFileName(baseFile));
                string fileName = Path.GetFileName(baseFile).Split('.')[0] + ".txt";
                Byte[] bytes1 = File.ReadAllBytes(baseFile);
                String base64String = Convert.ToBase64String(bytes1);
                //Console.WriteLine(base64String);            
                System.IO.File.WriteAllText(fileName, base64String);

                Write("\nBase-64 text file \"");
                ForegroundColor = ConsoleColor.Green;
                Write("{0}", fileName);
                ResetColor();
                WriteLine("\" created Successfully!");
            }

            //WriteLine("Exiting to Main Menu ...");
        }
    }

}
