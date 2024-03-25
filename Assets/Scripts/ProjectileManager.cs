using System.Collections;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public GameObject[] projectilePrefabs;
    public float spawnInterval = 2f;
    public float projectileSpeed = 5f;
    public Transform playerTransform;
    public string generatedProjectileTag = "GeneratedProjectile"; // Ajoutez cette variable pour le tag
    public Joueur player; // Référence au joueur pour savoir s'il est en vie.

    private int projectileLayer;
    private Coroutine spawnCoroutine; // Référence à la coroutine

    // Démarrer la coroutine lorsque le jeu commence
    public void Start()
    {
        projectileLayer = LayerMask.NameToLayer("ProjectileLayer");
        StartSpawnProjectiles(); // Commencer à faire apparaître des projectiles
    }

    // Méthode pour commencer à faire apparaître des projectiles
    public void StartSpawnProjectiles()
    {
        spawnCoroutine = StartCoroutine(SpawnProjectiles());
    }

    // Méthode pour arrêter de faire apparaître des projectiles
    public void StopSpawnProjectiles()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }

    IEnumerator SpawnProjectiles()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // Vérifier si le joueur est toujours en vie avant de faire apparaître des projectiles
            if (!PlayerIsAlive())
            {
                // Si le joueur est mort, arrêter de faire apparaître des projectiles
                StopSpawnProjectiles();
                yield break; // Sortir de la coroutine
            }

            // Déboguer la longueur de projectilePrefabs
            Debug.Log("Nombre de préfabriqués : " + projectilePrefabs.Length);

            int randomIndex = Random.Range(0, projectilePrefabs.Length);

            // Déboguer l'index aléatoire
            Debug.Log("Index aléatoire : " + randomIndex);

            GameObject newProjectile = Instantiate(projectilePrefabs[randomIndex], transform.position, Quaternion.identity);

            Vector3 directionToPlayer = (playerTransform.position - newProjectile.transform.position).normalized;
            newProjectile.GetComponent<Rigidbody>().velocity = directionToPlayer * projectileSpeed;
            newProjectile.tag = generatedProjectileTag;

            // Définir la couche du projectile généré par le ProjectileManager
            newProjectile.layer = projectileLayer;
        }
    }

    // Vérifier si le joueur est en vie
    private bool PlayerIsAlive()
    {
        return player.currentHealth > 0;
    }
}
