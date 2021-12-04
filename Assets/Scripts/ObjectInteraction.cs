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
    Vector3 interactingObjectPosition;
    float interactingObjectHeight;
    Transform mainCharacterTransform;

    public float radius = 2.5f;

    private void Start() {
        mainCharacterTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(0);
        }
        
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray, out clickedObject))
        {
            Debug.Log(clickedObject.collider.name);
            interactingObjectPosition = clickedObject.collider.bounds.center;
            interactingObjectHeight = clickedObject.collider.bounds.size.y;
            if( isInteractable() ){
                interactableObject = clickedObject.collider.GetComponent<Interactable>();
                if( interactableObject != null ){
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
        Debug.Log("Disabling interaction");
        interactingObjectPosition = Vector3.zero;
        if( lastInteractableObject != null ){
            lastInteractableObject.DisableInteraction();
            lastInteractableObject = null;
        }
    }

    bool isInteractable(){
        float distanceToMainCharacter = Vector3.Distance(interactingObjectPosition, mainCharacterTransform.position);
        // Debug.Log(distanceToMainCharacter);
        return ( radius >= distanceToMainCharacter );
    }

     void OnDrawGizmos()
    {
        if( interactingObjectPosition != Vector3.zero ){
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(interactingObjectPosition, radius);
        }
    }
}