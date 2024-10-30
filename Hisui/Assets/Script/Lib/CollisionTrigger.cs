using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    public bool isActiveTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player")|| other.transform.CompareTag("PlayerAI"))
        {
            isActiveTrigger = true;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player") || other.transform.CompareTag("PlayerAI"))
        {
            isActiveTrigger = false;

        }

    }
}
