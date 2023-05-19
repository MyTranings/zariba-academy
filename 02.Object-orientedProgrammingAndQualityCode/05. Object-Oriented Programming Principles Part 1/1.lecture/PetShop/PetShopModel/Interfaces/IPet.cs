namespace PetShopModel.Interfaces
{
    public interface IPet
    {
        string Owner { get;  }

        string InvokeHappiness();
    }
}
