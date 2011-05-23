//#no checks for out of bounds
//#I would put a inner function here, but don't know how
#define SHORT

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeLog
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Back spacX\be");

            int i = 0;
            foreach( var arg in args )
            {
                Console.WriteLine("{0}) {1}", i, arg );
                i++;
            }
            byte a = 255, b = 255, d;
            int c = a + b;
            d = (byte)c;
            Console.WriteLine("c = {0}, d = {1}", c, d);

            var dtl = new List<DateTime>();
            
            dtl.Add( new DateTime(1990, 3, 5) );
            dtl.Add( new DateTime(1979, 4, 30) );

            foreach( var date in dtl )
                Console.WriteLine( date );

#if LONG
            for (var d1 = 0; d1 < dtl.Count; ++d1)
            {
                for (var d2 = 0; d2 < dtl.Count; ++d2)
                {
                    if ( dtl[d1] < dtl[d2] )
                    {
                        var temp = dtl[d1];

                        dtl[ d1 ] = dtl[ d2 ];
                        dtl[ d2 ] = temp;
                    }
                }
            }
#endif

#if SHORT
            dtl.Sort(); // this works too, don't know how to do comparison(sp) - or even spell it
#endif

            foreach (var date in dtl)
                Console.WriteLine(date);

            Console.WriteLine( "Using Task class instance:" );
            var tasks = new List<Task>();
            tasks.Add( new Task( new DateTime( 2011, 3, 24 ) ) );
            tasks.Add( new Task( new DateTime( 1979, 4, 30 ) ) );
            //#I would put a inner function here, but don't know how
            Print(tasks);
            //tasks.Sort();
            Console.WriteLine("Is it sorted?");
            //Print(tasks);

            Run();
        }

        private static bool inBounds(int value, int min, int max)
        {
            return (value >= min && value <= max);
        }

        private static List<int> GetArguments(string str)
        {
            var root = GetRoot( str );
            str = str.Substring( root.Length, str.Length - root.Length);
            //#no checks for out of bounds
            bool isInBounds = true;
            if (inBounds(str.Length, 1, 42) == isInBounds) //str.Length > 0)
            {
                const int quotes = 1;
                if (str[0] == '"')
                    str = str.Substring(quotes, str.Length - 1 - quotes);

                var strWithSpaceRemoved = removeSpaces( str );

                var numbers = new List<int>();
                foreach (var strNum in strWithSpaceRemoved.Split(' '))
                {
                    Console.WriteLine( "'" + strNum + "'" );
                    numbers.Add(Convert.ToInt32(strNum));
                }
                return numbers;
            }

            return null;
        }

        private static string removeSpaces( string str )
        {
            string oldStr = str;

            str = str.Trim();
            str = str.Replace("  ", " ");

            if (str == oldStr)
                return str;
            else
                return removeSpaces(str); // recursion call
        }

        private static string PrintArgs(List<int> args)
        {
            if (args == null)
                return "";
            string argStr = "";

            foreach(var arg in args)
            {
                argStr += "<" + arg + "> ";
            }

            return argStr;
        }

        private static void Run()
        {
            var input = "";
            var done = false;
            while (!done)
            {
                Console.WriteLine( "Enter 'q' to quit, 'h' for help:" );
                input = Console.ReadLine();
                var root = GetRoot(input);
                List<int> arguments = GetArguments( input );
                Console.WriteLine(
                        "root:" + root + "\n" +
                        "arguments: " + PrintArgs( arguments ) );
                switch (root)
                {
                    case "q":
                        done = true;
                        break;
                    case "h":
                        Console.WriteLine("Usage:\nq - quit\nh - this help\nadd - eg. add" + '"' + "1 2 3" + '"' );
                        break;
                    case "add":
                        int total = 0;
                        foreach(var number in arguments)
                        {
                            Console.Write(number + " ");
                            total += number;
                        }
                        Console.WriteLine( " - " + total);
                        break;
                }
            }
        }

        private static bool IsNumber(char c)
        {
            for (int i = 0; i < 10; ++i)
            {
                if (c == (char)('0' + i))
                    return true;
            }

            return false;
        }

        private static string GetRoot(string input)
        {
            var index = 0;
            for (int i = 0; i < input.Length; ++i)
            {
                if (input[i] == '"' || IsNumber(input[i]) == true)
                {
                    break;
                }
                else
                {
                    ++index;
                }
            }

            return input.Substring( 0, index ); // input.Remove(0 /*, find index of '"' or # */ );
        }

        private static int[] GetNumbers(string input)
        {
            return new int[] { 1, 2, 3 };
        }

        private static void Print(List<Task> tasks)
        {
            foreach (var task in tasks)
            {
                Console.WriteLine( task );
            }
        }
    } // class 
} // namespace
