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
                Debug.Log(hit.collider.name);
                Interactable interactableItem = hit.collider.GetComponent<Interactable>();
                
                if(Input.GetMouseButton(0)){
                    if( interactableItem != null )
                        interactableItem.Interact(new Color(255, 0, 0));
                }else {
                    if( interactableItem != null )
                        interactableItem.Interact(new Color(0, 255, 0));
                }
         }
    }
}