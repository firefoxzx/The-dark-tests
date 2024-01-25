using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Intreactable
{
    protected override void Intreact(Inventory inventory)
    {
        inventory.Main_inventory.Add(gameObject);
        Destroy(gameObject);
    }
}
