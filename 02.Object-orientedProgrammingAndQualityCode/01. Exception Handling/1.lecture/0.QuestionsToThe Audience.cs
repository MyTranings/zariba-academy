using System;


namespace ExceptionHandlingDemo
{
    class QuestionToTheAudience
    {
        static void Method()
        {
            try
            {
                int.Parse("blabla");
            }
            catch (FormatException)
            {
                Console.WriteLine();
            }
            catch (OverflowException)
            {
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Some Generic Exception");
            }
        }
    }
}
