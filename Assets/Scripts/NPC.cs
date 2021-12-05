using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Collections.Generic;

[RequireComponent(typeof(Outline))]
public class NPC : BaseInteractable
{

    public GameObject diamond;
    public Material unactive, active;
    Renderer rd;

    public void Start() {
        base.Start();
        rd = diamond.GetComponent<Renderer>();
        rd.material = unactive;
    }

    public override void Interact() {
        base.Interact();
        if( rd != null )
            rd.material = active;
        // Debug.Log("interacting NPC");
        // Dialog
        dialogueWindow.Enable();
        if( isDialogueFinished ){
            allDialogueText = finalText;
        }
        dialogueWindow.SetAllDialogueText(allDialogueText, isDialogueFinished);
    }

    public override void DisableInteraction(){
        base.DisableInteraction();
        if( rd != null )
            rd.material = unactive;
        // dialogueWindow.Disable();
    }

    public override bool isInteractable()
    {
        return base.isInteractable() 
            && isPrerequisitesCompleted;
            // && !sound.isPlaying;
    }

    public void Update() {
        base.Update();
        outliner.enabled = false;
    }

}