using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{

    public BaseInteractable[] interactableItems;
    public int currentInteractableItem = 0;
    
    public GameObject diamond;
    public Material unactive, active;
    Renderer rd;

    public void Start() {
        EnableInteractableObject();
        rd = diamond.GetComponent<Renderer>();
        rd.material = unactive;
    }


    void MoveToNextInteractableObject() {
        if( currentInteractableItem + 1 >= interactableItems.Length ){
            return;
        }
        currentInteractableItem++;
        EnableInteractableObject();
    }

    void EnableInteractableObject() {
        if( interactableItems != null ){
            interactableItems[currentInteractableItem].SetPrerequisitesCompleted();
            SetDiamondPosition();
        }
    }

    void SetDiamondPosition(){
        Vector3 pos = interactableItems[currentInteractableItem].center;
        pos.y = 3f;
        diamond.transform.position = pos;
    }

    public void Update() {
        if( interactableItems != null ){
            if( currentInteractableItem < interactableItems.Length ){
                if( interactableItems[currentInteractableItem].isDialogueFinished ){
                    MoveToNextInteractableObject();
                }
                if( interactableItems[currentInteractableItem].isInteractable() ){
                    if( rd != null )
                        rd.material = active;
                }else {
                    if( rd != null )
                        rd.material = unactive;
                }
            }
        }
    }


}