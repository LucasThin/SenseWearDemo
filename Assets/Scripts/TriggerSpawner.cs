using UnityEngine;

public class TriggerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject TriggerCube;

    void Start()
    {
        SpawnTrigger();
    }

    private void SpawnTrigger()
    {
        if (TriggerCube != null)
        {
            Vector3 spawnPosition = transform.position + transform.forward * 5f;
            GameObject triggerCube = Instantiate(TriggerCube, spawnPosition, Quaternion.identity);
         
        }
        else
        {
            Debug.LogError("Prefab to spawn is not assigned. Please assign a prefab in the PrefabSpawner component.");
        }
        
    }
}