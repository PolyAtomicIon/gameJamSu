using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ObjectInteraction : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;
    Interactable interactableItem, lastInteractableItem;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(0);
        }
        
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.name);
            
            interactableItem = hit.collider.GetComponent<Interactable>();
            if( interactableItem != null ){
                lastInteractableItem = interactableItem;
                if(Input.GetMouseButton(0)){
                    interactableItem.Interact(new Color(255, 0, 0));
                } 
                else {
                    interactableItem.Interact(new Color(0, 255, 0));
                }
            }
            else {
                Debug.Log("Disabling interaction");
                lastInteractableItem.DisableInteraction();
                lastInteractableItem = null;
            }
        } 
            
    }
}