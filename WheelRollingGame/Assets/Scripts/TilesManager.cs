using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    private List<GameObject> activeTiles = new List<GameObject>();
    public GameObject[] tilePrefabs;

    public float tileLength = 50;
    public int numberOfTiles = 3;

    public float zSpawn = 0;

    public Transform playerTransform;

    private int previousIndex;

    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if(i==0)
                SpawnTile();
            else
                SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
    }
    void Update()
    {
        if(playerTransform.position.z - 50 >= zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
            
    }

    public void SpawnTile(int index = 0)
    {
        GameObject spawnedTile = Instantiate(tilePrefabs[index], transform.forward * zSpawn, Quaternion.identity);
        activeTiles.Add(spawnedTile);
        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
