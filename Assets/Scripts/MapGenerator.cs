using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Transform player;
    public float pieceLength;
    public List<GameObject> pieces = new List<GameObject>();

    private int m_counterPieces;

    void Update()
    {
        if (player.position.z > pieceLength * m_counterPieces)
        {
            m_counterPieces++;
            int random = Random.Range(0, pieces.Count);
            Instantiate(pieces[random], Vector3.forward * pieceLength * m_counterPieces, Quaternion.identity);
        }
    }
}
