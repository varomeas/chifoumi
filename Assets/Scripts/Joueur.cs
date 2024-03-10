using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Joueur : MonoBehaviour
{
    private void Update()
    {
        // Utilisez le système d'entrée Unity pour détecter les touches F, G et H
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            DestroyTarget("Pierre");
        }
        else if (Keyboard.current.gKey.wasPressedThisFrame)
        {
            DestroyTarget("Feuille");
        }
        else if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            DestroyTarget("Ciseau");
        }
    }

    public void DestroyTarget(string targetName)
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Projectile");

        foreach (GameObject target in targets)
        {
            if (target.name.StartsWith(targetName) && target.name.EndsWith("(Clone)"))
            {
                Destroy(target);
                break;
            }
        }
    }
}
