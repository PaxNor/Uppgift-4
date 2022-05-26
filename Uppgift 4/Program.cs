using System;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main() {

            while (true) {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input) {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList() {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            bool quit = false;
            const string subMenu = "'+' add, '-' remove, 'q' quit.";
            List<string> theList = new List<string>();
            Console.WriteLine(subMenu);

            do {
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav) {

                    case '+':
                        theList.Add(value);
                        break;

                    case '-':
                        theList.Remove(value);
                        break;

                    case 'q':
                        quit = true;
                        break;

                    default:
                        break;
                }

                // present result
                foreach (string str in theList) {
                    Console.Write($"{str} ");
                }
                Console.WriteLine();

            } while (quit == false);
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue() {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            bool quit = false;
            const string subMenu = "'+' enqueue, '-' dequeue, 'q' quit.";
            Queue<string> theQueue = new Queue<string>();
            Console.WriteLine(subMenu);

            do {
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav) {

                    case '+':
                        theQueue.Enqueue(value);
                        break;

                    case '-':
                        if (theQueue.Count > 0) {
                            theQueue.Dequeue();
                        }
                        break;

                    case 'q':
                        quit = true;
                        break;

                    default:
                        break;
                }

                // present result
                foreach (string str in theQueue) {
                    Console.Write($"{str} ");
                }
                Console.WriteLine();

            } while (quit == false);

        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack() {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            bool quit = false;
            const string subMenu = "'+' push, '-' pop, 'q' quit.";
            Stack<string> theStack = new Stack<string>();
            Console.WriteLine(subMenu);

            do {
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav) {

                    case '+':
                        theStack.Push(value);
                        break;

                    case '-':
                        if (theStack.Count > 0) {
                            theStack.Pop();
                        }
                        break;

                    case 'q':
                        quit = true;
                        break;

                    default:
                        break;
                }

                // present result
                foreach (string str in theStack) {
                    Console.Write($"{str} ");
                }
                Console.WriteLine();

            } while (quit == false);


        }

        static void CheckParanthesis() {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            Stack<Char> lParens = new Stack<Char>();
            string input = Console.ReadLine();

            foreach (char c in input) {
                switch (c) {
                    case '(':
                    case '{':
                    case '[':
                    case '<':
                        lParens.Push(c);
                        break;

                    case ')':
                        MatchAndReport(lParens, expected: '(', c);
                        break;

                    case '}':
                        MatchAndReport(lParens, expected: '{', c);
                        break;

                    case ']':
                        MatchAndReport(lParens, expected: '[', c);
                        break;

                    case '>':
                        MatchAndReport(lParens, expected: '<', c);
                        break;
                }
            }

            if (lParens.Count != 0) {

                while(lParens.Count != 0) {
                    Char p = lParens.Pop();
                    Console.WriteLine($"Error: no matching closing parenthesis to \'{p}\'");
                }
            }
        }

        // helper function, testing and reporting
        private static void MatchAndReport(Stack<Char> lParens, Char expected, Char closing) {

            if (lParens.Count == 0) {
                Console.WriteLine($"Error: no matching \'{expected}\' found");
            }
            else {
                Char paren = lParens.Pop();
                if (paren != expected) {
                    Console.WriteLine($"Error: \'{paren}\' does not match \'{closing}\'");
                }
            }
        }


    }
}


