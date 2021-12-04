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

    public void Start() {
        base.Start();
        vfx = GetComponentInChildren<ParticleSystem>();
        currentMesh = GetComponent<MeshFilter>();
    }

    public override void Interact() {
        base.Interact();
        // Debug.Log("building statue");
        PlayVFX();
        
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