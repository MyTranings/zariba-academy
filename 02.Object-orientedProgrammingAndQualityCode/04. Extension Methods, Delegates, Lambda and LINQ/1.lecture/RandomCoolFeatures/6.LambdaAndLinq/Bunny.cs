namespace _6.LambdaAndLinq
{
    using System;
    public enum BunnyGender
    {
        M,F
    }
    public class Bunny
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public BunnyGender Gender { get; set; }
    }
}
