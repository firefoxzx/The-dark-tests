using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Intreactable : MonoBehaviour
{
    public string PrompetMasseage; // This to tell the player what he intreacting will do , example : Open door 
    public bool IsIntreactable;

    //this will be called in the player script
    public void BaseIntreact(Inventory inventory){
        Intreact(inventory);
    }
    protected virtual void Intreact(Inventory inventory){
        //this is a template for any type of intreaction
    }
}
