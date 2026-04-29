using System;
using System.Collections.Generic;
using System.Text;

namespace Mod5DLLDemo
{
    interface IInventoryItem
    {
        bool IsFairTrade { get; }
    }
    internal interface IBeverage
    {
        bool IsFairTrade { get; set; }
    }
    class Coffee : IBeverage, IInventoryItem
    {
        //don't see any interface name before property 
        //implicit - public bool IsFairTrade { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        //Explicit
        
        bool IBeverage.IsFairTrade { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        bool IInventoryItem.IsFairTrade => throw new NotImplementedException();
    }
}
