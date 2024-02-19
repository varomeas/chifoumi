using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CibleMouvement : MonoBehaviour
{
    public float vitesse = 1.0f;
    public Transform joueur;

    void Update()
    {
        // Déterminer la direction vers le joueur
        Vector3 direction = joueur.position - transform.position;
        direction.y = 0; // On ignore la direction verticale

        // Normaliser la direction
        direction.Normalize();

        // Déplacer la cible vers le joueur
        transform.position += direction * vitesse * Time.deltaTime;
    }
}
