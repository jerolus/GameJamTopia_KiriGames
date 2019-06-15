using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "MagnetCollider")
        {
            PlayerController player = PlayerController.GetInstance();
            if (player.powerUpMultiplier)
            {
                player.pagesNumber += 2;
            }
            else
            {   
                player.pagesNumber ++;
            }
            Destroy(gameObject);
        }
    }
}
