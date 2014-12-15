using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;
using Clases;



namespace CodigoJuegov2
{
    struct Posicion
    {
        public int fila;
        public int columna;
        public Posicion(int row, int col)
        {
            this.fila = row;
            this.columna = col;
        }
    }

    public class Snakev2
    {
        public static void Juego()
        {
            byte derecha = 0;
            byte izquierda = 1;
            byte abajo = 2;
            byte arriba = 3;
            int ultimoTiempodeEstrella = 0;
            int tempsDesaparecerEstrella = 8000;
            int Puntosnegativos = 0;

            Posicion[] Direccions = new Posicion[]
            {
                new Posicion(0, 1), // right
                new Posicion(0, -1), // left
                new Posicion(1, 0), // down
                new Posicion(-1, 0), // up
            };
            double tiempodeEspera = 100;
            int direccion = derecha;
            Random aleaNum = new Random();

            //Probar si copia dependiendo del tamaño posible-
            Console.BufferHeight = Console.WindowHeight;
            //Obtiene el numero de milisegundos desde que se inicia el juego.
            ultimoTiempodeEstrella = Environment.TickCount;

            //Creamos nuevos objetos
            List<Posicion> obstacles = new List<Posicion>()
            {
                new Posicion(12, 12),
                new Posicion(14, 20),
                new Posicion(7, 7),
                new Posicion(19, 19),
                new Posicion(6, 9),
            };
            foreach (Posicion obstacle in obstacles)
            {
                Dibujar(obstacle, 'O', ConsoleColor.Magenta);
            }

            //Creamos una nueva colección donde guardaremos las partes de la serpiente.
            Queue<Posicion> parteSnake = new Queue<Posicion>();
            //Empezamos con 5 partes del cuerpo(#) de la serpiente.
            for (int i = 0; i <= 5; i++)
            {
                parteSnake.Enqueue(new Posicion(0, i));
            }

            foreach (Posicion position in parteSnake)
            {
                Dibujar(position, '#', ConsoleColor.Red);
            }

            //Dibujamos estrella
            Posicion estrella;
            do
            {
                estrella = new Posicion(aleaNum.Next(0, Console.WindowHeight),
                    aleaNum.Next(0, Console.WindowWidth));
            }
            while (parteSnake.Contains(estrella) || obstacles.Contains(estrella));
            Dibujar(estrella, '@', ConsoleColor.Yellow);



            while (true)
            {
                Puntosnegativos++;
                int PuntosUsuario = (parteSnake.Count - 6) * 100 - Puntosnegativos;
                Console.Title = "Snake version a la Machi, Puntuacion: " + PuntosUsuario;

                direccion = ControlesFlechas(derecha, izquierda, abajo, arriba, direccion);

                Posicion capdeSerp = parteSnake.Last();
                Posicion nuevaDireccion = Direccions[direccion];

                Posicion nouCapdeSerp = new Posicion(capdeSerp.fila + nuevaDireccion.fila,
                    capdeSerp.columna + nuevaDireccion.columna);

                if (nouCapdeSerp.columna < 0) nouCapdeSerp.columna = Console.WindowWidth - 1;
                if (nouCapdeSerp.fila < 0) nouCapdeSerp.fila = Console.WindowHeight - 1;
                if (nouCapdeSerp.fila >= Console.WindowHeight) nouCapdeSerp.fila = 0;
                if (nouCapdeSerp.columna >= Console.WindowWidth) nouCapdeSerp.columna = 0;

                //nouCapdeSerp = siEstrellaSerpienteEnObjeto(negativePoints, obstacles, parteSnake, nouCapdeSerp);
                if (parteSnake.Contains(nouCapdeSerp) || obstacles.Contains(nouCapdeSerp))
                {
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Red;

                    //int userPoints = (parteSnake.Count - 6) * 100 - negativePoints;
                    if (PuntosUsuario < 0) PuntosUsuario = 0;
                    PuntosUsuario = Math.Max(PuntosUsuario, 0);
                    LibreriaClases.GameOver(PuntosUsuario);

                    return;
                }

                Dibujar(capdeSerp, '#', ConsoleColor.Red);

                //nouCapdeSerp = direcciondeSerpiente(derecha, izquierda, abajo, arriba, direccion, parteSnake, nouCapdeSerp);
                parteSnake.Enqueue(nouCapdeSerp);
                Console.SetCursorPosition(nouCapdeSerp.columna, nouCapdeSerp.fila);
                Console.ForegroundColor = ConsoleColor.Green;
                if (direccion == derecha) Console.Write(">");
                if (direccion == izquierda) Console.Write("<");
                if (direccion == arriba) Console.Write("^");
                if (direccion == abajo) Console.Write("v");



                //SirecogidaEstrella(ref ultimoTiempodeEstrella, ref tiempodeEspera, aleaNum, obstacles, parteSnake, ref estrella, ref nouCapdeSerp);
                //if (nouCapdeSerp.columna == estrella.columna && nouCapdeSerp.fila == estrella.fila)
                //{
                //    // feeding the snake
                //    do
                //    {
                //        estrella = new Posicion(aleaNum.Next(0, Console.WindowHeight),
                //            aleaNum.Next(0, Console.WindowWidth));
                //    }
                //    while (parteSnake.Contains(estrella) || obstacles.Contains(estrella));
                //    ultimoTiempodeEstrella = Environment.TickCount;
                //    //Dibujamos estrella
                //    Dibujar(estrella,'@',ConsoleColor.Yellow);
                //    tiempodeEspera--;

                //    Posicion obstacle = new Posicion();

                //    int numPosAleaFila = aleaNum.Next(0, Console.WindowHeight);
                //    int numPosAleaColumna = aleaNum.Next(0, Console.WindowWidth);
                //    do
                //    {
                //        obstacle = new Posicion(numPosAleaFila, numPosAleaColumna);

                //    }
                //    while (parteSnake.Contains(obstacle) ||
                //        obstacles.Contains(obstacle) ||
                //        (estrella.fila != obstacle.fila && estrella.columna != obstacle.fila));
                //    obstacles.Add(obstacle);
                //    obstacle = Dibujar(obstacle, '^', ConsoleColor.Blue);

                //}
                //else
                //{
                //    // borramos la ultima parte de la serpiente en cada movimiento.
                //    Posicion last = parteSnake.Dequeue();
                //    Console.SetCursorPosition(last.columna, last.fila);
                //    Console.Write(" ");
                //}
                if (nouCapdeSerp.columna == estrella.columna && nouCapdeSerp.fila == estrella.fila)
                {
                    
                    do
                    {
                        estrella = new Posicion(aleaNum.Next(0, Console.WindowHeight),
                            aleaNum.Next(0, Console.WindowWidth));
                    }
                    while (parteSnake.Contains(estrella) || obstacles.Contains(estrella));
                    ultimoTiempodeEstrella = Environment.TickCount;
                    Dibujar(estrella, '@', ConsoleColor.Yellow);
                    tiempodeEspera--;

                    Posicion obstacle = new Posicion();
                    do
                    {
                        obstacle = new Posicion(aleaNum.Next(0, Console.WindowHeight),
                            aleaNum.Next(0, Console.WindowWidth));
                    }
                    while (parteSnake.Contains(obstacle) ||
                        obstacles.Contains(obstacle) ||
                        (estrella.fila != obstacle.fila && estrella.columna != obstacle.fila));
                    obstacles.Add(obstacle);
                    Dibujar(obstacle, 'O', ConsoleColor.Magenta);
                }
                else
                {
                    // moving...
                    Posicion last = parteSnake.Dequeue();
                    Console.SetCursorPosition(last.columna, last.fila);
                    Console.Write(" ");
                }

                if (Environment.TickCount - ultimoTiempodeEstrella >= tempsDesaparecerEstrella)
                {
                    Puntosnegativos = Puntosnegativos + 100;
                    Console.SetCursorPosition(estrella.columna, estrella.fila);
                    Console.Write(" ");
                    do
                    {
                        estrella = new Posicion(aleaNum.Next(0, Console.WindowHeight),
                            aleaNum.Next(0, Console.WindowWidth));
                    }
                    while (parteSnake.Contains(estrella) || obstacles.Contains(estrella));
                    ultimoTiempodeEstrella = Environment.TickCount;
                }

                Dibujar(estrella, '@', ConsoleColor.Yellow);

                tiempodeEspera -= 0.01;

                Thread.Sleep((int)tiempodeEspera);
            }
        }

        private static Posicion Dibujar(Posicion objeto, char valor, ConsoleColor color)
        {
            Console.SetCursorPosition(objeto.columna, objeto.fila);
            Console.ForegroundColor = color;
            Console.Write(valor);
            return objeto;
        }

        public static int ControlesFlechas(byte derecha, byte izquierda, byte abajo, byte arriba, int direccion)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();

                if (userInput.Key == ConsoleKey.LeftArrow)
                {
                    if (direccion != derecha) direccion = izquierda;
                }
                if (userInput.Key == ConsoleKey.RightArrow)
                {
                    if (direccion != izquierda) direccion = derecha;
                }
                if (userInput.Key == ConsoleKey.UpArrow)
                {
                    if (direccion != abajo) direccion = arriba;
                }
                if (userInput.Key == ConsoleKey.DownArrow)
                {
                    if (direccion != arriba) direccion = abajo;
                }
            }
            return direccion;
        }

        //public static void SirecogidaEstrella(ref int ultimoTiempodeEstrella, ref double tiempodeEspera, Random aleaNum, List<Posicion> obstacles, Queue<Posicion> parteSnake, ref Posicion estrella, ref Posicion nouCapdeSerp)
        //{
        //    
        // }

        //public static Posicion siEstrellaSerpienteEnObjeto(int negativePoints, List<Posicion> obstacles, Queue<Posicion> parteSnake, Posicion nouCapdeSerp)
        //{
        //    if (parteSnake.Contains(nouCapdeSerp) || obstacles.Contains(nouCapdeSerp))
        //    {
        //        Console.SetCursorPosition(0, 0);
        //        Console.ForegroundColor = ConsoleColor.Red;

        //        int userPoints = (parteSnake.Count - 6) * 100 - negativePoints;
        //        //if (userPoints < 0) userPoints = 0;
        //        userPoints = Math.Max(userPoints, 0);
        //        LibreriaClases.GameOver(userPoints);

        //        //return;
        //    }
        //    return nouCapdeSerp;
        //}

        //public static Posicion direcciondeSerpiente(byte derecha, byte izquierda, byte abajo, byte arriba, int direccion, Queue<Posicion> parteSnake, Posicion nouCapdeSerp)
        //{
        //    parteSnake.Enqueue(nouCapdeSerp);
        //    Console.SetCursorPosition(nouCapdeSerp.columna, nouCapdeSerp.fila);
        //    Console.ForegroundColor = ConsoleColor.Gray;
        //    if (direccion == derecha) Console.Write(">");
        //    if (direccion == izquierda) Console.Write("<");
        //    if (direccion == arriba) Console.Write("^");
        //    if (direccion == abajo) Console.Write("v");
        //    return nouCapdeSerp;
        //}

        //public static Queue<Posicion> CrearSerpiente()
        //{
        //    //Creamos una nueva colección donde guardaremos las partes de la serpiente.
        //    Queue<Posicion> parteSnake = new Queue<Posicion>();
        //    //Empezamos con 5 partes del cuerpo(#) de la serpiente.
        //    for (int i = 0; i <= 5; i++)
        //    {
        //        parteSnake.Enqueue(new Posicion(0, i));
        //    }

        //    foreach (Posicion position in parteSnake)
        //    {
        //        Console.SetCursorPosition(position.columna, position.fila);
        //        Console.ForegroundColor = ConsoleColor.DarkGray;
        //        Console.Write("#");
        //    }
        //    return parteSnake;
        //}

        //public static List<Posicion> mapaObjetos()
        //{
        //    List<Posicion> obstacles = new List<Posicion>()
        //    {
        //        new Posicion(12, 12),
        //        new Posicion(14, 20),
        //        new Posicion(7, 7),
        //        new Posicion(19, 19),
        //        new Posicion(6, 9),
        //    };
        //    foreach (Posicion obstacle in obstacles)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Cyan;
        //        Console.SetCursorPosition(obstacle.columna, obstacle.fila);
        //        Console.Write("==Ç");
        //    }
        //    return obstacles;
        //}

        //public static Posicion dibujarEstrella(Random aleaNum, List<Posicion> obstacles, Queue<Posicion> parteSnake, char valor)
        //{
        //    Posicion estrella;
        //    do
        //    {
        //        estrella = new Posicion(aleaNum.Next(0, Console.WindowHeight),
        //            aleaNum.Next(0, Console.WindowWidth));
        //    }
        //    while (parteSnake.Contains(estrella) || obstacles.Contains(estrella));
        //    Console.SetCursorPosition(estrella.columna, estrella.fila);
        //    Console.ForegroundColor = ConsoleColor.Yellow;
        //    Console.Write(valor);
        //    return estrella;
        //}
    }
}