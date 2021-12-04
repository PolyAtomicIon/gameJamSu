using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ObjectInteraction : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
         {
            // if(Input.GetMouseButtonDown(0)){
                Debug.Log(hit.collider.name);
                Interactable interactableItem = hit.collider.GetComponent<Interactable>();
                if( interactableItem != null )
                    interactableItem.Interact();
            // }
         }
    }
}