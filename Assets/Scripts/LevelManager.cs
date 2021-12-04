using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{

    BaseInteractable[] interactableItems;
    int currentInteractableItem;

    public void Start() {
    }


    void MoveToNextInteractableObject() {
        if( currentInteractableItem + 1 <= interactableItems.Length ){
            return;
        }
        currentInteractableItem++;
        EnableInteractableObject();
    }

    void EnableInteractableObject() {
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