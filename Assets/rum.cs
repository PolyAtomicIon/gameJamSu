using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rum : MonoBehaviour
{
    public Camera dialogueCamera; 
    public Camera mainCamera;
    public Animation anim; 

    void Start(){
      dialogueCamera.enabled = false;
    }

    void Update () {
        if(Input.GetKeyDown (KeyCode.E)){
          anim = GetComponent<Animation>();
          // anim.Play("Rummaging");
          switchCameras();
        }
    }

    public void switchCameras(bool active = true){
      if( mainCamera )
        mainCamera.enabled = !active;
      if(dialogueCamera)
        dialogueCamera.enabled = active;
    }

}
