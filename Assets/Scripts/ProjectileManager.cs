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

    //start coroutine when game start
    public void Start()
    {
        Commencer();
    }

    public void Commencer()
{
    projectileLayer = LayerMask.NameToLayer("ProjectileLayer");

    StartCoroutine(SpawnProjectiles());
}
IEnumerator SpawnProjectiles()
{
    while (true)
    {
        yield return new WaitForSeconds(spawnInterval);

        // Debug the length of projectilePrefabs
        Debug.Log("Number of prefabs: " + projectilePrefabs.Length);

        int randomIndex = Random.Range(0, projectilePrefabs.Length);

        // Debug the random index
        Debug.Log("Random index: " + randomIndex);

        GameObject newProjectile = Instantiate(projectilePrefabs[randomIndex], transform.position, Quaternion.identity);

        Vector3 directionToPlayer = (playerTransform.position - newProjectile.transform.position).normalized;
        newProjectile.GetComponent<Rigidbody>().velocity = directionToPlayer * projectileSpeed;
        newProjectile.tag = generatedProjectileTag;

        // Définir la couche du projectile généré par le ProjectileManager
        newProjectile.layer = projectileLayer;
    }
}



}
