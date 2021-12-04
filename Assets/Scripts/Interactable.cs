using UnityEngine;
using System.Collections;
public interface Interactable 
{
    bool isInteractable();
    void Interact(Color color);
    void DisableInteraction();
    void EnableOutline();
    void DisableOutline();
    void OnDrawGizmos();
}