using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            audio.Play();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
