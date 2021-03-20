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

    [SerializeField]
    GameObject objectToTrack;

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
        // Tracks the new copy
        objectToTrack = dummyCopy;
        // Start a routine to wait for the object to die
        StartCoroutine(WaitForObjectToDie());
    }

    void OnDrawGizmos()
    {
        // Sets of color of gizmo
        Gizmos.color = new Color(1, 1, 1, 0.25f);
        // draws a cube as the gizmo
        Gizmos.DrawCube(transform.position, new Vector3(1, 3, 1));
    }

    private void Awake()
    {
        // Starts routine to wait for the tracked object to die
        StartCoroutine(WaitForObjectToDie());
    }

    IEnumerator WaitForObjectToDie()
    {
        // Waits until the object is destroyed
        yield return new WaitUntil(() => objectToTrack == null);
        // Respawn object
        RespawnObject();
    }
}
