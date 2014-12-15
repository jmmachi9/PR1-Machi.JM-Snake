using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    struct Posicion
    {
        public int fila;
        public int columna;
        public Posicion(int columna, int fila)
        {
            this.fila = fila;
            this.columna = columna;
        }
    }

    public class CodigoJuego
    {


        Posicion[] Direccion = new Posicion[]
        {
            new Posicion(0, 1), // derecha
            new Posicion(0, -1), // izquierda
            new Posicion(1, 0), // abajo
            new Posicion(-1, 0), // arriba
        };

        
        
        public static void Juego()
        {
            //Puntuacion:
            int Puntuacion = 1;
            


            Posicion Cabeza = new Posicion(40, 15);
            //creem una nova llista per a guardar les posicion de la serp.
            List<Posicion> Serp = new List<Posicion>();
            //añadim el cap a la serp
            Serp.Add(Cabeza);
            //Creem una estrella del firmament
            Posicion Estrella = new Posicion(59, 18);

            Posicion Proxima;
            //while (!Quit)
            //         Console.Title = "Snake version a la Machi, Puntuacion: " + Puntuacion;
            bool Quit = false;
            while (Quit != true)
            {
                Console.Clear();
                Console.Title = "Snake version a la Machi, Puntuacion: " + Puntuacion;
                Proxima = Serp[0];
                
                
                //Serp maquexa ????
               foreach (Posicion posicio in Serp)
               {
                   //Console.SetCursorPosition(posicio.columna, posicio.fila);
                   //Console.Write("#");
                   Dibujar(posicio.columna, posicio.fila, "#");

               }
                //Marquem la estrella.
               //Console.SetCursorPosition(Estrella.columna, Estrella.fila);
               //Console.Write('*');
               Dibujar(Estrella.columna, Estrella.fila, "*");
                //Marcada

                //Creem el menu dels moviments per a la serp.
               ConsoleKeyInfo MovSerp = Console.ReadKey(true);
               ConsoleKeyInfo BotonAnterior = MovSerp;
               
                //Els moviments se poden fer en cualquier tecla, lo que vaig a gastar son les flechetes.
              /// while (Quit != false)
               //{
                     switch (MovSerp.Key)
                       {
                       
                       case ConsoleKey.UpArrow:
                           if (Proxima.fila > 0)
                           {
                               Proxima.fila--;
                               BotonAnterior = MovSerp;
                               Puntuacion++;
                           }

                           break;
                       case ConsoleKey.DownArrow:
                           if (Proxima.fila < 24)
                           {
                               Proxima.fila++;
                               BotonAnterior = MovSerp;
                               Puntuacion++;
                           }
                           break;
                       case ConsoleKey.LeftArrow:
                           if (Proxima.columna > 0)
                           {
                               Proxima.columna--;
                               BotonAnterior = MovSerp;
                               Puntuacion++;
                           }
                           
                           break;
                       case ConsoleKey.RightArrow:
                           if (Proxima.columna < 79)
                           {
                               Proxima.columna++;
                               BotonAnterior = MovSerp;
                               Puntuacion++;
                           }
                           break;
                         //case 'q':
                         //  Quit = true;
                         //  break;
                      


                         }
                     switch (MovSerp.KeyChar)
                     {
                         case 'q':
                             Quit = true;
                             LibreriaClases.GameOver(Puntuacion);
                             break;
                         case 'Q':
                             Quit = true;
                             LibreriaClases.GameOver(Puntuacion);
                             break;
                        
                     }
                
            //}

               Serp.Insert(0, Proxima);
               if (Proxima.columna == Estrella.columna && Proxima.fila == Estrella.fila)
               {
                   //creem una nova estrella
                   Random EstAlea = new Random();
                   Estrella.columna = EstAlea.Next(0, 80);
                   Estrella.fila = EstAlea.Next(0, 25);
                   Puntuacion = Puntuacion + 50; 


               }
               else
                   Serp.RemoveAt(Serp.Count - 1);

                

            }

            
        }
        public static void Dibujar(int DColumna, int DFila,string Figura)
        {
            Console.SetCursorPosition(DColumna, DFila);
            Console.Write(Figura);
        }
        //public static void PruebaEstrella()
        //{

        //    Console.SetCursorPosition(Estrella.fila, Estrella.columna);
        //    Console.Write('*');

        //}
    }

    

}
