using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CibleDestruction : MonoBehaviour
{
    public KeyCode toucheDestruction = KeyCode.Space; // La touche à presser pour détruire la cible

    void Update()
    {
        // Détruire la cible si la touche est pressée
        if (Input.GetKeyDown(toucheDestruction))
        {
            Destroy(gameObject);
        }
    }
}