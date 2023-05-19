
namespace PetShopModel.Model
{
    using System;
    using PetShopModel.Interfaces;

    public class Dog : Mammal, IPet
    {
        public string Owner { get; set; }
      

        public string InvokeHappiness()
        {
            return string.Format("Wave tail. Jump on owner. Lick {0}...", this.Owner);
        }
    }
}
