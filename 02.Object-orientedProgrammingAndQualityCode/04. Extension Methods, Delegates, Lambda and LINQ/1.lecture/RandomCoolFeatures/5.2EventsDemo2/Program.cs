namespace _5._2EventsDemo2
{
    using System;
    using System.Threading;
    public delegate void KeyHandler(object sender, ConsoleKeyInfo pressedKey);
    public class HandleKey
    {
        public event KeyHandler Pressed;

        private void OnPressed(ConsoleKeyInfo key)
        {
            if (this.Pressed!=null)
            {
                this.Pressed(this, key);
            }
        }
        public void InputKey()
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey();
            Console.WriteLine("\nI am called from the class. I have nothing to do with the event");
            Console.WriteLine("Pressed key is {0}",pressedKey.Key);
            Console.WriteLine();
            //Firing the event
            this.OnPressed(pressedKey);
            //if (this.Pressed != null)
            //{
            //    this.Pressed(this, pressedKey);
            //    //same as d1("bunn1",5)
            //}
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            HandleKey keyHandler = new HandleKey();
            keyHandler.InputKey();
            keyHandler.Pressed += LoadSprites;
            keyHandler.Pressed += LoadAudio;
            keyHandler.Pressed += LoadLevel;
            keyHandler.InputKey();
        }
        public static void LoadSprites(object sender, ConsoleKeyInfo key)
        {
            Console.WriteLine(key.Key);
            Console.WriteLine("Loading Sprites...");
            Thread.Sleep(1500);
            Console.WriteLine("Sprites Loaded!");
        }
        public static void LoadAudio(object sender, ConsoleKeyInfo key)
        {
            Console.WriteLine(key.Key);
            Thread.Sleep(1000);
            Console.WriteLine("Loading Audio...");
            Thread.Sleep(1500);
            Console.WriteLine("Audio Loaded!");
        }
        public static void LoadLevel(object sender, ConsoleKeyInfo key)
        {
            Console.WriteLine(key.Key);
            Thread.Sleep(1000);
            Console.WriteLine("Loading Level...");
            Thread.Sleep(1500);
            Console.WriteLine("Level Loaded!");
        }
    }
}
