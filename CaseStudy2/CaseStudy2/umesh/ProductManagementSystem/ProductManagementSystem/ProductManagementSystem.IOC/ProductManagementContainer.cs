using System;

namespace ProductManagementSystem.IOC
{
    public class ProductManagementContainer
    {
        public TInterface Create<TInterface, TClass>() where TClass : TInterface
        {
            Type typeOfTClass = typeof(TClass);
            return (TInterface)Activator.CreateInstance(typeOfTClass);
        }
    }
}
