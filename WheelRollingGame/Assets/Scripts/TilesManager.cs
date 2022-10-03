using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    public GameObject[] Tiles;
    public float zspawn = 0;
    public float titleLength = 5;
    public int numTiles;
    public Transform playerTransform;
    private List<GameObject> activeTiles = new List<GameObject>();
    void Start()
    {
        for(int i=0; i<numTiles; i++)
        {
            if(i == 0)
                SpawnTile(0);
            else
                SpawnTile(Random.Range(0, Tiles.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z > zspawn - (numTiles * titleLength))
        {
            SpawnTile(Random.Range(0, Tiles.Length));
            deleteTiles();
        }
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(Tiles[tileIndex], transform.forward * zspawn, transform.rotation);
        activeTiles.Add(go);
        zspawn += titleLength;
    }

    private void deleteTiles()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
