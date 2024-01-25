using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Intreact : MonoBehaviour
{
    
    [SerializeField] private float Intreactrange = 3f;
    [SerializeField] private Camera Cam;
    [SerializeField] private TMP_Text Message;
    [SerializeField] private Inventory inventory;
    private void Start(){
        Cam = GetComponentInChildren<Camera>();
        inventory = GetComponent<Inventory>();
        Message.text = string.Empty;
    }

    private void Update(){
        Message.text = string.Empty; //this for the Message
        Ray ray = new Ray(Cam.transform.position , Cam.transform.forward);
        RaycastHit HitInfo;
        if(Physics.Raycast(ray,out HitInfo,Intreactrange)){
            Intreactable intreactable = HitInfo.collider.GetComponent<Intreactable>();
            //this will get if the Intreactable(Key) is in intreact range 
            if(intreactable != null){
                //this show the Message of the intreactable
                Message.text = intreactable.PrompetMasseage;
                //this intreacts if no buttons then keys
                if(Input.GetKeyDown("f")){
                    intreactable.BaseIntreact(inventory);
                }
            }
        }
    }
}
