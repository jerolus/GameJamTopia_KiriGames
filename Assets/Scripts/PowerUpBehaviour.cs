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
                        StartCoroutine(MultiplierCoroutine(player));
                    }
                    break;
                case Type.Invincible:
                    {
                        StartCoroutine(InvincibleCoroutine(player));
                    }
                    break;
                case Type.Magnet:
                    {
                        StartCoroutine(MagnetCoroutine(player));
                    }
                    break;
            }
        }
    }

    private IEnumerator MultiplierCoroutine(PlayerController player)
    {
        player.powerUpMultiplier = true;
        yield return new WaitForSeconds(5);
        player.powerUpMultiplier = false;
        Destroy(gameObject);
    }

    private IEnumerator InvincibleCoroutine(PlayerController player)
    {
        player.powerUpInvincible = true;
        yield return new WaitForSeconds(5);
        player.powerUpInvincible = false;
        Destroy(gameObject);
    }
    
    private IEnumerator MagnetCoroutine(PlayerController player)
    {
        player.powerUpMagnet = true;
        player.magnetCollider.SetActive(true);
        yield return new WaitForSeconds(5);
        player.powerUpMagnet = false;
        player.magnetCollider.SetActive(false);
        Destroy(gameObject);
    }
}
