using System.Collections;
using UnityEngine;

public class InstantiateAvatar : MonoBehaviour
{
    public GameObject avatar; // Assign the avatar prefab in the Inspector
    public GameObject player; // Assign the player object in the Inspector
    public float distanceInFront = 2.0f; // 2 feet in front of the player

    void Start()
    {
        StartCoroutine(InstantiateAvatarAfterDelay(1.0f));
    }

    IEnumerator InstantiateAvatarAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Vector3 playerPosition = player.transform.position;
        Vector3 playerForward = player.transform.forward;
        Vector3 spawnPosition = playerPosition + playerForward * distanceInFront;
        spawnPosition.y = playerPosition.y; // Set the same height as the player

        Instantiate(avatar, spawnPosition, Quaternion.identity);
    }
}