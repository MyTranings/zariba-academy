namespace Crimsonland
{
    using RogueSharp.Random;

    class Global
    {
        public static readonly Camera Camera = new Camera();
        public static readonly IRandom Random = new DotNetRandom();
        public static readonly int MapWidth = 50;
        public static readonly int MapHeight = 40;
        public static readonly int SpriteWidth = 64;
        public static readonly int SpriteHeight = 64;
    }
}
