using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetTrigger("Attack");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger("Rolling");
        }
    }
}
