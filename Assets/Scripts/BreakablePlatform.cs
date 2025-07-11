using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BreakablePlatform : MonoBehaviour
{
    public Tilemap tilemap;
    public float breakDelay = 4f;
    public float respawnDelay = 3f;
    public AnimatedTile animatedTile;
    public PlayerMovement playerMovement;
    public Tile breakablePlatformTile;

    private HashSet<Vector3Int> brokenTiles = new HashSet<Vector3Int>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        {
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3Int contactTile = tilemap.WorldToCell(contactPoint);
            HashSet<Vector3Int> breakTiles = new HashSet<Vector3Int>();

            if (brokenTiles.Contains(contactTile) || !playerMovement.isGrounded) return;

            // Find center tile 
            Vector3Int i = contactTile;
            Vector3Int j = contactTile;
            Vector3Int centerTile = i;
            if (!tilemap.HasTile(i))
            {
                i.x += 1;
                j.x -= 1;
            }
            if (tilemap.HasTile(i))
            {
                centerTile = i;
            }
            else if (tilemap.HasTile(j))
            {
                centerTile = j;
            }
            brokenTiles.Add(centerTile);

            // Start animation
            tilemap.SetTile(centerTile, animatedTile);

            // Destroy after 4 seconds
            StartCoroutine(BreakTileAfterDelay(centerTile));

        }
    }

    private IEnumerator BreakTileAfterDelay(Vector3Int tileToBreak)
    {
        yield return new WaitForSeconds(breakDelay);
        tilemap.SetTile(tileToBreak, null);
        // Respawn after 3 seconds
        StartCoroutine(RespawnTileAfterDelay(tileToBreak));
    }

    private IEnumerator RespawnTileAfterDelay(Vector3Int tileToRespawn)
    {
        yield return new WaitForSeconds(respawnDelay);
        tilemap.SetTile(tileToRespawn, breakablePlatformTile);
        brokenTiles.Remove(tileToRespawn);

    }
}