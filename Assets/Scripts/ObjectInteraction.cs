using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ObjectInteraction : MonoBehaviour
{

    Ray ray;
    RaycastHit clickedObject, objectInRadius;
    Interactable interactableObject, lastInteractableObject;

    private void Start() {
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(0);
        }
        
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray, out clickedObject))
        {
            // Debug.Log(clickedObject.collider.name);
            
            interactableObject = clickedObject.collider.GetComponent<Interactable>();
            if( interactableObject != null ){
                if( interactableObject.isInteractable() ){
                    lastInteractableObject = interactableObject;
                    if(Input.GetMouseButton(0)){
                        interactableObject.Interact(new Color(255, 0, 0));
                    } 
                    else {
                        interactableObject.Interact(new Color(0, 255, 0));
                    }
                }
                else {
                    ResetInteractableObject();
                }
            }
            else{
                ResetInteractableObject();
            }
        } 

    }

    void ResetInteractableObject(){
        if( lastInteractableObject != null ){
            lastInteractableObject.DisableInteraction();
            lastInteractableObject = null;
        }
    }

}