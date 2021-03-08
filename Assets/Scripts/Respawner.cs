using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    // Object we want to respawn
    [SerializeField]
    GameObject ObjectToRespawn;
    // Delay between respawning
    [SerializeField]
    float timeToRespawn = 5f;
    // Function to respawn object
    public void RespawnObject()
    {
        // Starts the respawner routine
        StartCoroutine(RespawnerRoutine());
    }
    // Routine for respawning the object
    IEnumerator RespawnerRoutine()
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(timeToRespawn);
        //Spawn a copy of the dummy at the location and rotation of the respawner object
        var dummyCopy = GameObject.Instantiate(ObjectToRespawn, transform.position, transform.rotation);
    }
}
