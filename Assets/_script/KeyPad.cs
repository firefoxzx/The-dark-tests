using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : Intreactable
{
    [SerializeField] private GameObject ConfirmKey;
    [SerializeField] private GameObject DeleteKey;
    [SerializeField] private Door door;
    [SerializeField] int number;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip ButtonClickClip;

    private void Start(){
        audioSource = GetComponent<AudioSource>();
    }
    protected override void Intreact(Inventory inventory){
        if (this.gameObject == ConfirmKey){
            ConfirmCode();
        }
        else if (this.gameObject == DeleteKey){
            DeleteLastCodeCharacter();
        }else{
            if(door.Player_Code.Length < 4){
                door.Player_Code += number.ToString();
            }else if (door.Player_Code.Length > 4){
                door.Player_Code = string.Empty;
            }
        }
        audioSource.PlayOneShot(ButtonClickClip);
    }
    private void DeleteLastCodeCharacter(){
        if (door.Player_Code.Length > 0)
        {
            door.Player_Code = door.Player_Code.Substring(0, door.Player_Code.Length - 1);
        }
    }
    private void ConfirmCode(){
        if (door.Player_Code.Length == 4){
            door.IsEntered = true;
        }
        else{
            door.PrompetMasseage = "Please enter a 4-digit code";
        }
    }
    //of course we need animation for every key
    
}
