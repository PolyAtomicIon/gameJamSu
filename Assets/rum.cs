using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rum : MonoBehaviour
{
    // Start is called before the first frame update
    public Animation anim;
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        anim["spin"].layer = 123;
    }
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.Play("rum");
        }
    }
}
