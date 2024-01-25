using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door : Intreactable
{
    private enum Doortype {Unlocked,Locked,Key,Keypad}
    [SerializeField] Animator Anim;
    [SerializeField] private Doortype doortype;
    [Header("Door with key")]
    [SerializeField] private GameObject doorKey;
    [Header("Door with KeyPad")]
    public int Code;
    public string Player_Code;
    public bool IsEntered;
    [SerializeField] private TMP_Text Player_Text_code;
    [Header("Sounds")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip ClosedClip;
    [SerializeField] AudioClip OpenedClip;
    

    public void Start(){
        PrompetMasseage = "Open the door";
        Code = Random.Range(1000,9999); // this is for the code
        Anim = GetComponent<Animator>();
        Anim.SetBool("Open",false);
        audioSource = GetComponent<AudioSource>();
        if(Player_Text_code == null){
            return; // this is for doors withput keys
        }
    }

    private void Update(){
        Player_Text_code.text = Player_Code; //this is for the keypad
    }
    protected override void Intreact(Inventory inventory){
        switch(doortype){
            case Doortype.Unlocked: OpenUnlocked(); break;
            case Doortype.Locked: if(IsEntered){ OpenLocked();} else{PrompetMasseage = "Enter Code to open";} ; break;
            case Doortype.Key: OpenKey(inventory); break;
            case Doortype.Keypad: OpenKeyPad(); break;
        }
    }

    private void OpenUnlocked(){
        Opened();
    }
    private void OpenLocked(){
        Opened();
    }
    private void OpenKey(Inventory inventory){
        if(inventory.Main_inventory.Contains(doorKey)){
            Opened();
        }else{
            audioSource.PlayOneShot(ClosedClip);
            PrompetMasseage = "you don't have the door key";
        }
    }
    private void OpenKeyPad(){
        if(Player_Code == Code.ToString()){
            Opened();
        }else{
            audioSource.PlayOneShot(ClosedClip);
            PrompetMasseage = "Password is incorrect";
        }
    }
    private void Opened(){
        Anim.SetBool("Open",true);
        IsIntreactable = false;
        PrompetMasseage = string.Empty;
        audioSource.PlayOneShot(OpenedClip);
    }
}