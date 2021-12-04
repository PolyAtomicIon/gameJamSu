using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Collections.Generic;

[RequireComponent(typeof(Outline))]
public class Statue : BaseInteractable
{

    ParticleSystem vfx;
    
    MeshFilter currentMesh;
    int currentMeshIndex = 0;
    public Mesh[] statueStates;
    private bool isStatueCompleted = false;

    public void Start() {
        base.Start();
        vfx = GetComponentInChildren<ParticleSystem>();
        currentMesh = GetComponent<MeshFilter>();
    }

    public override void Interact() {
        base.Interact();
        // Debug.Log("building statue");
        if( !isStatueCompleted ){
            PlayVFX();
            StopSound();
            PlaySound();
            UpdateMesh();
        } else {
            dialogueWindow.Enable();
            if( isDialogueFinished ){
                allDialogueText = "Statue:I'm done;";
            }
            dialogueWindow.SetAllDialogueText(allDialogueText, isDialogueFinished);
        }
    }

    public override bool isInteractable()
    {
        return base.isInteractable() 
            && isPrerequisitesCompleted 
            && !vfx.isPlaying;
            // && !sound.isPlaying;
    }

    void UpdateMesh(){
        if( currentMeshIndex + 1 >= statueStates.Length ){
            isStatueCompleted = true;
            return;
        }
        currentMeshIndex++;
        currentMesh.mesh = statueStates[currentMeshIndex];
    }

    void PlayVFX() {
        if( vfx ){
            if( !vfx.isPlaying )
                vfx.Play();
        }
    }
}