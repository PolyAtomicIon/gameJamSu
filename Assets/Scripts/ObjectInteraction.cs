using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ObjectInteraction : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(0);
        }
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