using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Collections.Generic;

[RequireComponent(typeof(Outline))]
public class NPC : BaseInteractable
{

    private bool isPrerequisitesCompleted = false;

    public void Start() {
        base.Start();
        SetPrerequisitesCompleted();
    }

    public override void Interact() {
        base.Interact();
        Debug.Log("interacting NPC");
        // Dialog
    }

    public override bool isInteractable()
    {
        return base.isInteractable() 
            && isPrerequisitesCompleted;
            // && !sound.isPlaying;
    }

    public void SetPrerequisitesCompleted(){
        isPrerequisitesCompleted = true;
    }

}