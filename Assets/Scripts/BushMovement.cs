﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushMovement : MonoBehaviour
{
    public Animator Anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Anim.SetTrigger("isPassing");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Anim.SetTrigger("isPassing");
    }
}
