using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Joueur : MonoBehaviour
{
    private List<GameObject> targets = new List<GameObject>();

        // Start is called before the first frame update
    void Start()
    {
        // Find all targets and add them to the list
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag("Target");
        foreach(GameObject target in targetObjects)
        {
            targets.Add(target);
        }
    }



    private void OnDestroyPierre(){
        //envoit le message "Destroy" à l'objet "Cible"
        DestroyTarget("Pierre");
    }

    private void OnDestroyFeuille(){
        //envoit le message "Destroy" à l'objet "Cible"
        DestroyTarget("Feuille");
    }

    private void OnDestroyCiseau(){
        //envoit le message "Destroy" à l'objet "Cible"
        DestroyTarget("Ciseau");
    }



    private void DestroyTarget(string targetName)
    {
        // Find the first target with the given name and destroy it
        GameObject target = targets.Find(t => t.name.StartsWith(targetName));
        if (target != null)
        {
            Destroy(target);
            targets.Remove(target);
        }
    }


}
