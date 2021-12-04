using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Outline))]
public class DemoInteractable : MonoBehaviour, Interactable
{

    Outline outliner;

    private void Start() {
        outliner = GetComponent<Outline>();
        DisableOutline();
    }

    public void EnableOutline() {
        outliner.enabled = true; 
    }
    public void DisableOutline() {
        outliner.enabled = false; 
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
}