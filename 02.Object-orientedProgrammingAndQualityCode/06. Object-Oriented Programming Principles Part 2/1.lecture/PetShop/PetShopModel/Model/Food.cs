namespace PetShopModel.Model
{
    using PetShopModel.Enumerations;

    public class Food
    {
        public int Calories { get; private set; }
        public Taste Taste { get; private set; }
    }
}