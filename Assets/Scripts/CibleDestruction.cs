using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CibleDestruction : MonoBehaviour
{
    // This method will be called when the "Destroy" message is sent to this object
    public void Destroy()
    {
        // Perform any actions you want when the "Destroy" message is received
        Debug.Log("Cible détruite");
        // For example, you can destroy the target object itself
        Destroy(gameObject);
    }
}