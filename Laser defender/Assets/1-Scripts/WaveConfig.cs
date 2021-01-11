using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "Enemy Wave Config" )]
public class WaveConfig : ScriptableObject {
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.7f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] int numberOfEnemys = 5;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }
    public List<Transform> GetWaypoints() {
        var waveWaypoints = new List<Transform>();
        foreach(Transform waypoint in pathPrefab.transform ) {
            waveWaypoints.Add( waypoint );
        }
        return waveWaypoints; 
    }
    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }
    public float GetSpawnRandomFactor() { return spawnRandomFactor; }
    public float GetMoveSpeed() { return moveSpeed; }
    public int GetNumberOfEnemys() { return numberOfEnemys; }
    public Vector3 GetStartPosition() {
        return pathPrefab.transform.GetChild(0).position;
    }

}
