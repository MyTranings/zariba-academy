using System;

class FormattingStrings
{
    static void Main()
    {
        string emailTemplate = "Dear {0},\nThank you for your email.\nSincerely,\n{1}";
        string sampleEmail = String.Format(emailTemplate,"Mr Bunny","The Carrot Cake Factory");
        Console.WriteLine(sampleEmail);

        //DateTimeFormat
        DateTime now = DateTime.Now;
        Console.WriteLine("{0:dddd.MM.yyyy HH:mm:ss}, {1,allignment:format}",now);

    }
}

