using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float xSpawn = 0;
    public float tileLength = 400;
    public Vector3 startPosition = Vector3.zero; // Starting position for tile spawning
    public int numberOfTiles = 4;
    public Transform playerTransform;
    private List<GameObject> activeTiles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        xSpawn = startPosition.x; // Set initial xSpawn to the starting position's x value
        for (int i = 0; i < numberOfTiles; i++)
        {
            SpawnTile(i == 0 ? 0 : Random.Range(0, tilePrefabs.Length)); // Spawn the initial tile as a specific one, others randomly
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if we need to spawn a new tile
        if (playerTransform.position.x < xSpawn + (numberOfTiles - 1) * tileLength)
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], new Vector3(xSpawn, startPosition.y, startPosition.z), Quaternion.identity);
        activeTiles.Add(go);
        xSpawn -= tileLength; // Move spawn position to the left for negative x-direction
    }

    private void DeleteTile()
    {
        // Check if we have more tiles than we need to keep
        if (activeTiles.Count > numberOfTiles)
        {
            Destroy(activeTiles[0]);
            activeTiles.RemoveAt(0);
        }
    }
}