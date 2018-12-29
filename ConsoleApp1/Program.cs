using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            //Snake snake = new Snake(Actions.MoveDown);
            Console.ReadKey();
        }

        class Game
        {
            public Game()
            {
                Draw draw = new Draw(OBJECT.Fields);
            }
        }

        static class Actions
        {
            static public void MoveUp() { }
            static public void MoveDown() { }
            static public void MoveRight() { }
            static public void MoveLeft() { }
        }

        enum ACTIONS
        {
            MoveUp, MoveDown, MoveRight, MoveLeft
        }

        delegate void Do();

        class Snake
        {
            Do doIt;

            public void ChangeAction(Do doIt)
            {
                this.doIt = doIt;
            }

            public void Game()
            {
                while (true)
                {
                    doIt();
                }
            }
        }

        class Draw : Object
        {
            public Draw(OBJECT name)
            {
                switch (name)
                {
                    case OBJECT.Fields:
                        BackInterface(Interf.WerticalLine, Interf.HorizontalLine, Interf.CoordX, Interf.CoordY);
                        break;
                    case OBJECT.Snake:
                        break;
                }
            }
            public static void BackInterface(string vert, string horiz, int coordX, int coordY)
            {
                Console.SetWindowSize(50,20);
                for(int i = 0; i < Console.WindowWidth; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write(horiz);
                    Console.SetCursorPosition(i, Console.WindowHeight-1);
                    Console.Write(horiz);
                }
                for(int i = 1; i <= Console.WindowHeight-2; i++)
                {
                    Console.SetCursorPosition(0,i);
                    Console.Write(vert);
                    Console.SetCursorPosition(Console.WindowWidth-1, i);
                    Console.Write(vert);
                }
            }
        }

        enum OBJECT
        {
            Fields = 1,
            Snake = 2,
            Feed = 3
        }

        class Object
        {
            static public class Interf
            {
                static string horizontalLine = "-";
                static string werticalLine = "|";
                static int coordX = Console.WindowHeight - 1;
                static int coordY = Console.WindowWidth - 1;

                public static string HorizontalLine => horizontalLine;
                public static string WerticalLine => werticalLine;
                public static int CoordX => coordX;
                public static int CoordY => coordY;
            }
        }

        
    }
}
