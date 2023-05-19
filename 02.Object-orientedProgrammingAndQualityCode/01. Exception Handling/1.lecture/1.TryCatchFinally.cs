using System;

namespace ExceptionHandlingDemo
{
    class TryCatchFinally
    {
       
        static void Main()
        {
            Console.WriteLine();
            Console.WriteLine();
            try
            {
                ReadInput();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("The variable that we try to assign is of type int. ");
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number is too big to fit int.");

            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("You cannot divide by zero. You have broken Maths. You suck!");
            }
            catch (Exception)
            {
                Console.WriteLine("Some generic error");
            }
            finally
            {
                Console.WriteLine("This is always executed");
            }

            Console.WriteLine("This is executed after the block.");
        }

        private static void ReadInput()
        {
            int number = int.Parse(Console.ReadLine());
            DivideNumber(number);
        }

        private static void DivideNumber(int number)
        {
            int result = 5 / number;
        }
    }
}
