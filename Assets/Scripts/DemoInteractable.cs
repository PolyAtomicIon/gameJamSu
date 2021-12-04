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
        outliner.OutlineColor = new Color(0, 0, 255);    
    }

    public void Interact() {
        outliner.OutlineMode = Outline.Mode.OutlineAll;    
        Debug.Log("interacting");
    }

}