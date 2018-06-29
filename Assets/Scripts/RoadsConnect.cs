using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadsConnect : MonoBehaviour {

    public int spawnPointsOnStart;
    private GameObject[] spawnPoints;
    public GameObject connectedObject;
    public bool isConnected;

    private void Start() {
        spawnPointsOnStart = transform.childCount;
        Debug.Log("SpawnPoint");
    }

    private void CheckConnected() {
        int childCount = transform.childCount;
        spawnPoints = new GameObject[childCount];

        for (int i = 0; i < childCount; i++) {
            spawnPoints[i] = transform.GetChild(i).gameObject;
        }
    }

    private void Selected() {
        CheckConnected();
        if (transform.childCount < spawnPointsOnStart) {
            isConnected = true;
        }
    }

    private void DeleteSpawnPoint(GameObject _point) {
        Destroy(_point);
    }
}
