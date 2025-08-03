using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerTeleportScript : MonoBehaviour
{
    public bool justTeleported = false;

    public void Teleport(Vector3 destination, float delay)
    {
        StartCoroutine(TeleportCooldown(destination, delay));
    }

    private IEnumerator TeleportCooldown(Vector3 destination, float delay)
    {
        justTeleported = true;
        transform.position = destination;
        yield return new WaitForSeconds(delay);
        justTeleported = false;
    }
}

