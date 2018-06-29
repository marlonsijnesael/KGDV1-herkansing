using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns grid of tiles and parents them to an empty gameobject
/// </summary>

public class SpawnGrid : MonoBehaviour {

    [Header("Gameobjects")]
    public GameObject prefabGridTile;
    public GameObject[] prefabBuildings;
    public GameObject[] prefabOtherTypes;
    public GameObject trees, water;

    [Header("others")]
    public int spawnRate;
    public Vector2 gridSize;
    private GameObject[] tiles;

    private void Start() {
        GridSpawn();
    }

    private void GridSpawn() {
        tiles = new GameObject[(int)gridSize.x * (int)gridSize.y];

        //iterations for easy naming in nested for loop
        int iterations = 0;

        //set counter and random number, if counter is equal to random number --> set other type of tile
        int randomCount = 0;
        int randomNumber = Random.Range(0, spawnRate);

        for (int x = 0; x < gridSize.x; x++) {
            for (int z = 0; z < gridSize.y; z++) {
                if (randomCount < randomNumber) {
                    tiles[iterations] = InstantiateTile(new Vector3(x, 0, z), this.transform, prefabGridTile);
                    randomCount++;
                } else {
                    randomCount = 0;
                    randomNumber = Random.Range(0, spawnRate);
                    tiles[iterations] = InstantiateTile(new Vector3(x, 0, z), this.transform, RandomObject());

                }
                iterations++;
            }
        }
    }

    //instantiates tile -> sets name, position, transform 
    private GameObject InstantiateTile(Vector3 _position, Transform _parent, GameObject _prefab) {
        GameObject tile = Instantiate(_prefab);
        tile.name = _prefab.name;
        tile.transform.position = _position;
        tile.transform.SetParent(_parent);
        return tile;
    }

    //spawntable of tiles
    private GameObject RandomObject() {
        if (Random.value < 0.2f) {
            return trees;
        } else if (Random.value < 0.5) {
            return water;
        }

        return prefabGridTile;
    }
}