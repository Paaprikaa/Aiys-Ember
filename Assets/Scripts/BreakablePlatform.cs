using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BreakTiles : MonoBehaviour
{
    public Tilemap tilemap;
    public float breakDelay = 4f;
    private HashSet<Vector3Int> brokeTiles = new HashSet<Vector3Int>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3Int contactTile = tilemap.WorldToCell(contactPoint);
            if (brokeTiles.Contains(contactTile)) return;

            HashSet<Vector3Int> breakingTiles = new HashSet<Vector3Int>();
            Vector3Int i = contactTile;
            Vector3Int j = contactTile;
            while (tilemap.HasTile(i))
            {
                breakingTiles.Add(i);
                i.x += 1;
            }
            while (tilemap.HasTile(j))
            {
                breakingTiles.Add(j);
                j.x -= 1;
            }
            brokeTiles.UnionWith(breakingTiles);

            StartCoroutine(BreakTileAfterDelay(breakingTiles.ToList()));
        }
    }

    private IEnumerator BreakTileAfterDelay(List<Vector3Int> breakingTiles)
    {
        yield return new WaitForSeconds(breakDelay);
        for (int i = 0; i < breakingTiles.Count; i++)
        {
            tilemap.SetTile(breakingTiles[i], null);
        }
    }
}