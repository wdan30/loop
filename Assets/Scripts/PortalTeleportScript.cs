using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleportScript : MonoBehaviour
{
    public Transform destinationPortal;
    public float cooldownTime = 0.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered by: " + other.name);
        
        if (other.CompareTag("Player"))
        {
            PlayerTeleportScript playerTeleport = other.GetComponent<PlayerTeleportScript>();
            if (playerTeleport != null && !playerTeleport.justTeleported)
            {
                playerTeleport.Teleport(destinationPortal.transform.position, cooldownTime);
            }
        }
    }
}

