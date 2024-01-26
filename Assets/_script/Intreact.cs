using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Intreact : MonoBehaviour
{
    
    [SerializeField] private float Intreactrange = 3f;
    [SerializeField] private Camera Cam;
    [SerializeField] private TMP_Text Message;
    [SerializeField] private Button IntreactButton;
    [SerializeField] private Inventory inventory;
    private void Start(){
        Cam = GetComponentInChildren<Camera>();
        inventory = GetComponent<Inventory>();
        Message.text = string.Empty;
    }

    private void Update(){
        Message.text = string.Empty; //this for the Message
        IntreactButton.gameObject.SetActive(false);
        Ray ray = new Ray(Cam.transform.position , Cam.transform.forward);
        RaycastHit HitInfo;
        if(Physics.Raycast(ray,out HitInfo,Intreactrange)){
            Intreactable intreactable = HitInfo.collider.GetComponent<Intreactable>();
            //this will get if the Intreactable(Key) is in intreact range 
            if(intreactable != null){
                //this show the Message of the intreactable
                Message.text = intreactable.PrompetMasseage;
                //this intreacts if no buttons then keys
                IntreactButton.onClick.AddListener(()=> intreactable.BaseIntreact(inventory));
                IntreactButton.gameObject.SetActive(true);
                if(Input.GetKeyDown("f") ){
                    intreactable.BaseIntreact(inventory);
                }
            }
        }
    }
}
