using System.Collections;
using System.Collections.Generic;
using CaptainCoder.Core;
using UnityEngine;

namespace CaptainCoder.Inventory.UnityEngine
{
    public interface IHasInventoryGrid<T> where T : class, IInventoryItem
    {
        public IInventoryGrid<T> InventoryGrid { get; }
    }
}
