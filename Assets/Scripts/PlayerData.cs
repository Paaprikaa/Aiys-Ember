using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public List<GameObject> data = new List<GameObject>();
    public Vector3 lastPosition;
    public GameObject lastAltar;
    public GameObject player;

    private void Start()
    {
        lastPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        lastAltar = null;
    }
    public void SaveSparkle(GameObject sparkle)
    {
        data.Add(sparkle);
    }

    public void RespawnSparkles()
    {
        for (int i = 0; i < data.Count; i++)
        {
            data[i].SetActive(true);
        }
    }

    public void SaveCheckpoint(Vector3 newPosition, GameObject altar)
    {
        if (lastAltar != altar)
        {
            lastAltar = altar;
            DeleteOldSparkles();
            lastPosition = newPosition;
        }
    }

    private void DeleteOldSparkles()
    {
        for (int i = 0; i < data.Count; i++)
        {
            Destroy(data[i]);
        }
        data = new List<GameObject>();
    }
}
