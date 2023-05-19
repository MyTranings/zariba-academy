

namespace PetShopModel.Interfaces
{
    using PetShopModel.Model;

    public interface IAnimal
    {
        string Name { get; }
        int Age { get; }
        int Weight { get; }
        string Colour { get; }
        bool IsAlive { get; }

        void Die();
        void Reproduce();
        string Eat(Food food);
        void Move();

    }
}
