using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Outline))]
public class DemoInteractable : MonoBehaviour, Interactable
{

    Transform mainCharacterTransform;
    Outline outliner;
    Bounds colliderBounds;
    Vector3 center;
    float radius;


    private void Start() {
        mainCharacterTransform = GameObject.FindWithTag("Player").transform;
        outliner = GetComponent<Outline>();
        DisableOutline();
        colliderBounds = GetComponent<Collider>().bounds;
        setObjectProperties();
    }

    private void Update() {
        if( isInteractable() ) {
            Interact(new Color(255, 255, 0));
        } else {
            DisableInteraction();
        }
    }

    void setObjectProperties(){
        center = colliderBounds.center;
        radius = Mathf.Max(colliderBounds.size.x, colliderBounds.size.z) * 1.5f;
    }
    public bool isInteractable(){
        float distanceToMainCharacter = Vector3.Distance(center, mainCharacterTransform.position);
        return ( radius >= distanceToMainCharacter );
    }

    public void Interact(Color color) {
        Debug.Log("interacting");
        EnableOutline();
        outliner.OutlineMode = Outline.Mode.OutlineVisible; 
        outliner.OutlineColor = color;   
    }

    public void DisableInteraction(){
        DisableOutline();
    }
    public void EnableOutline() {
        outliner.enabled = true; 
    }
    public void DisableOutline() {
        outliner.enabled = false; 
    }
    
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(center, radius);
    }
}