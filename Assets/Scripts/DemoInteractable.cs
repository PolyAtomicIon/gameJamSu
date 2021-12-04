using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DemoInteractable : MonoBehaviour, Interactable
{

    public void Interact() {
        Debug.Log("interacting");
    }

}