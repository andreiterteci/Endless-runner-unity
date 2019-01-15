using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapGenerator : MonoBehaviour {

    public GameObject[] tile;
    private Transform playerTransform;
    private float spawnLoc = 0.0f;
    private float lengthTile = 7.62f;
    private int amountTile = 10;
    private float safeZone = 21.0f;
    private int lastTileIndex = 0;


    private List<GameObject> activeTiles = new List<GameObject>();

    private void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < amountTile; i++)
           spawnTile();
	}
	
	
	private void Update () {
        if ((playerTransform.position.z - safeZone) > (spawnLoc - amountTile * lengthTile))
        {
            spawnTile();
            DeleteTile();
        }
	}

    private void spawnTile(int indexTile = -1)
    {
        GameObject obj;
        obj = Instantiate(tile[randomTileIndex()]) as GameObject;
        obj.transform.SetParent(transform);
        obj.transform.position = Vector3.forward * spawnLoc;
        spawnLoc += lengthTile;
        activeTiles.Add(obj);
    }

    private void DeleteTile()
   {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int randomTileIndex()
    {
        if (tile.Length <= 1)
            return 0;
        int randomIndex = lastTileIndex;
        while(randomIndex == lastTileIndex)
        {
            randomIndex = Random.Range(0, tile.Length);
        }
        lastTileIndex = randomIndex;
        return randomIndex;
    }
}
