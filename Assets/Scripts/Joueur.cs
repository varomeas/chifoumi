using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Joueur : MonoBehaviour
{
    public GameObject GameOverScreen; // Reference to the XR UI GameObject
    public GameObject RestartButton; // Reference to the restart button GameObject

       //health system
    public int maxHealth;
    public int currentHealth;

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

    public void DestroyAll()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Projectile");

        foreach (GameObject target in targets)
        {
            if (target.name.EndsWith("(Clone)"))
            {
                Destroy(target);
            }
        }
    }


 

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("currentHealth"+currentHealth);
        Debug.Log("maxHealth"+maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth-damage;
        Debug.Log("Player hit"+currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Actions à effectuer lorsque le joueur meurt
        Debug.Log("Player has died");

        //destruction des projectiles
        DestroyAll();
        GameOverScreen.SetActive(true);
        RestartButton.SetActive(true);
        // Vous pouvez ajouter d'autres actions ici, comme la réinitialisation du niveau, l'affichage d'un message de défaite, etc.
    }

    //when the player collides with an object
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            TakeDamage(100);
        }
    }


}
