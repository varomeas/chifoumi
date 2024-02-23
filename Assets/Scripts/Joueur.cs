using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Joueur : MonoBehaviour
{
    private void OnDestroy(){
        Debug.Log("Joueur détruit");
        //envoit le message "Destroy" à l'objet "Cible"
        GameObject.Find("Cible").SendMessage("Destroy");
    }


}
