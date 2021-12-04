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
        outliner.OutlineMode = Outline.Mode.SilhouetteOnly;    
    }

    public void Interact(Color color) {
        Debug.Log("interacting");
        outliner.OutlineMode = Outline.Mode.OutlineAll; 
        outliner.OutlineColor = color;   
    }

}