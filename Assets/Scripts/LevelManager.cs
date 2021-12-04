using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{

    public BaseInteractable[] interactableItems;
    public int currentInteractableItem = 0;

    public void Start() {
        EnableInteractableObject();
    }


    void MoveToNextInteractableObject() {
        if( currentInteractableItem + 1 >= interactableItems.Length ){
            return;
        }
        currentInteractableItem++;
        EnableInteractableObject();
    }

    void EnableInteractableObject() {
        if( interactableItems != null )
            interactableItems[currentInteractableItem].SetPrerequisitesCompleted();
    }

    public void Update() {
        if( interactableItems != null ){
            if( currentInteractableItem < interactableItems.Length ){
                if( interactableItems[currentInteractableItem].isDialogueFinished ){
                    MoveToNextInteractableObject();
                }
            }
        }
    }


}