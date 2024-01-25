using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Paper : Intreactable
{
    [SerializeField] Door door;
    [SerializeField] TMP_Text text;

    private void Start(){
        PrompetMasseage = "Revel Paper Text";
    }
    protected override void Intreact(Inventory inventory)
    {
        text.text = door.Code.ToString();
        //maybe an animation here
    }
}
