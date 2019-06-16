using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehaviour : MonoBehaviour
{
    public enum Type
    {
        Multiplier,
        Invincible,
        Magnet
    };

    public Type type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.transform.GetComponent<MeshRenderer>().enabled = false;
            PlayerController player = other.gameObject.transform.GetComponent<PlayerController>();
            switch (type)
            {
                case Type.Multiplier:
                    {
                        player.ActivateMultiplier();
                    }
                    break;
                case Type.Invincible:
                    {
                        player.ActivateInvincible();
                    }
                    break;
                case Type.Magnet:
                    {
                        player.ActivateMagnet();
                    }
                    break;
            }
        }
    }
}
