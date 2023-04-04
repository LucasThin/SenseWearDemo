using UnityEngine;

public class TriggerCube : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabToSpawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnPrefabToRight();
            gameObject.tag = "Default";
        }
    }

    private void SpawnPrefabToRight()
    {
        if (prefabToSpawn != null)
        {
            Vector3 spawnPosition = transform.position + transform.right * 2f;
            GameObject spawnedPrefab = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
            spawnedPrefab.transform.Rotate(Vector3.up, -90);
        }
        else
        {
            Debug.LogError("Prefab to spawn is not assigned. Please assign a prefab in the TriggerCube component.");
        }
    }
}