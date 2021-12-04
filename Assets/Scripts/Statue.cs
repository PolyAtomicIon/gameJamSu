using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Collections.Generic;

[RequireComponent(typeof(Outline))]
public class Statue : BaseInteractable
{

    ParticleSystem vfx;

    private void Start() {
        base.Start();
        vfx = GetComponentInChildren<ParticleSystem>();
    }

    public override void Interact() {
        base.Interact();
        Debug.Log("from statue privet");
        PlayVFX();
        // start building statue
    }
    void PlayVFX() {
        if( vfx ){
            if( !vfx.isPlaying )
                vfx.Play();
        }
    }
}