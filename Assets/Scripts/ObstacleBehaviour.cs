using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController player = other.gameObject.transform.GetComponent<PlayerController>();
            if (player.powerUpInvincible)
            {
                Destroy(this.gameObject);
            }
            else
            {   
                player.KillPlayer();
            }
        }
    }
}
