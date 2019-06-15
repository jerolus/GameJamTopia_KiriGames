using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Transform player;
    public float pieceLength;
    public List<GameObject> pieces = new List<GameObject>();

    private int m_counterPieces;
    private List<GameObject> m_piecesToRemove = new List<GameObject>();

    void Update()
    {
        if (player.position.z > pieceLength * m_counterPieces)
        {
            m_counterPieces++;
            int random = Random.Range(0, pieces.Count);
            GameObject pieceToInstantiate = Instantiate(pieces[random], Vector3.forward * pieceLength * m_counterPieces, Quaternion.identity);
            m_piecesToRemove.Add(pieceToInstantiate);
            if (m_piecesToRemove.Count > 3)
            {
                GameObject toDestroy = m_piecesToRemove[0];
                m_piecesToRemove.RemoveAt(0);
                Destroy(toDestroy);
            }
        }
    }
}
