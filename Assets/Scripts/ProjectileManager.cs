using System.Collections;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public GameObject[] projectilePrefabs;
    public float spawnInterval = 2f;
    public float projectileSpeed = 5f;
    public Transform playerTransform;
    public string generatedProjectileTag = "GeneratedProjectile"; // Ajoutez cette variable pour le tag

    private int projectileLayer;

    public void Commencer()
    {
        projectileLayer = LayerMask.NameToLayer("ProjectileLayer");

        if (projectilePrefabs != null && projectilePrefabs.Length > 0)
        {
            StartCoroutine(SpawnProjectiles());
        }
        else
        {
            Debug.LogError("Aucun projectilePrefab n'a été attribué au ProjectileManager. Veuillez assigner les préfabriqués dans l'inspecteur Unity.");
        }
    }

    IEnumerator SpawnProjectiles()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            int randomIndex = Random.Range(0, projectilePrefabs.Length);

            if (randomIndex >= 0 && randomIndex < projectilePrefabs.Length)
            {
                GameObject newProjectile = Instantiate(projectilePrefabs[randomIndex], transform.position, Quaternion.identity);

                Vector3 directionToPlayer = (playerTransform.position - newProjectile.transform.position).normalized;
                newProjectile.GetComponent<Rigidbody>().velocity = directionToPlayer * projectileSpeed;
                newProjectile.tag = generatedProjectileTag;

                // Définir la couche du projectile généré par le ProjectileManager
                newProjectile.layer = projectileLayer;
            }
            else
            {
                Debug.LogError("Index généré aléatoirement hors des limites du tableau projectilePrefabs.");
            }
        }
    }
}
