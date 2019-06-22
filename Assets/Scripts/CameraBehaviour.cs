using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform player;
    public float offset;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z + offset);
    }
}
