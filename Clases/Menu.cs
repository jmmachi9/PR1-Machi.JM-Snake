using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class LibreriaClases
    {
        //public static void SetWindowSize{
        //    int width = 
        //    int height
        //}
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Title = "Menu Snake";
            Console.WriteLine(@"      $$$$     $$$     $$       $$$       $$  $$   $$$$$$$ ");
            Console.WriteLine(@"     $$   $$   $$ $$   $$      $$ $$      $$ $$    $$      ");
            Console.WriteLine(@"      $$       $$  $$  $$     $$   $$     $$$$     $$$$    ");
            Console.WriteLine(@"       $$      $$   $$ $$    $$ $$$ $$    $$ $$    $$$$    ");
            Console.WriteLine(@"   $$   $$     $$    $$$$   $$       $$   $$  $$   $$      ");
            Console.WriteLine(@"     $$$$      $$     $$$  $$         $$  $$   $$  $$$$$$$ ");
            Console.Write("\n\n\n\n\n\n\n");
            Console.Write(" 	1. Start \n");
            Console.Write(" 	2. Controles  \n");
            Console.Write(" 	3. Creditos   \n");
            Console.Write(" 	4. Salir   \n");
            Console.WriteLine();

            ConsoleKeyInfo TeclaMenu;
            TeclaMenu = Console.ReadKey(true);
            switch (TeclaMenu.KeyChar)
            {
                case '1':
                    
                    Console.Clear();
                    Console.WriteLine("\n\nIniciando Juego...");
                    Console.Clear();
                    CodigoJuegov2.Snakev2.Juego();
                    
                    break;
                case '2':
                    Console.Clear();
                    Console.WriteLine("\n\nMostrando Controles...");
                    Console.ReadKey();
                    break;
                case '3':
                    Console.Clear();
                    Console.WriteLine("\n\n\tJose Miguel Machi Piles");
                    Console.WriteLine("\n\t1ºDAW");
                    Console.WriteLine("\n\tProgramación");
                    Console.WriteLine("\n\n\n\n\n\n\n Si quieres \"Volver\" pulsa V.");
                    Submenu();
                    break;
                case '4':
                    Console.WriteLine("   \n Hasta la proxima... ");
                    
                    break;
                
            }
            
        }

        public static void GameOver(int puntos)
        {
            Console.Clear();
            
            Console.WriteLine();
            Console.Title = " Si quieres volver a jugar presiona la tecla 'R'. Puntuacion: " + puntos; 
            Console.WriteLine(@"  $$$$       $$$$$     $$$     $$$ $$$$$$$ $$$$$$$ $$       $$ $$$$$$$ $$$$$$");
            Console.WriteLine(@" $$         $$   $$    $$ $$ $$ $$ $$      $$   $$  $$     $$  $$      $$  $$");
            Console.WriteLine(@"$$  $$$$   $$ $$$ $$   $$   $$  $$ $$$$    $$   $$   $$   $$   $$$$    $$$$");
            Console.WriteLine(@" $$   $$  $$       $$  $$       $$ $$      $$   $$    $$ $$    $$      $$  $$");
            Console.WriteLine(@"   $$$$$ $$         $$ $$       $$ $$$$$$$ $$$$$$$     $$      $$$$$$$ $$   $$");
            Console.Write("\n\n\n\n\tPuntos: " + puntos);

            Submenu();
            
        }

        public static void Submenu()
        {
            ConsoleKeyInfo TeclaGameOver;
            TeclaGameOver = Console.ReadKey(true);
            switch (TeclaGameOver.KeyChar)
            {
                case 'R':

                    Menu();
                    break;
                case 'r':

                    Menu();
                    break;
                case 'v':
                    Menu();
                    break;
                case 'V':
                    Menu();
                    break;
                default:
                    break;
            }
        }
    }
}
