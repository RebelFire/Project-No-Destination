using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] obstacleSpawnPoints;
    [SerializeField] private Transform[] obstacle;
    private bool isInitializingStarted = false;
    private Transform[] createdObstacles;
    private int obstacleCount = 0;

    private int starCounter = 0;


    private void Start() {
        PickRandomStarCounter();
        createdObstacles = new Transform[obstacleSpawnPoints.Length];
        InitiateObstacleSpawn();
    }

    private void Update() {
        
        
    }

    private void PickRandomStarCounter() {
        starCounter = UnityEngine.Random.Range(50, 100);
    }

    private void InitiateObstacleSpawn() {
        if (!isInitializingStarted) {
            foreach (Transform spawnPoint in obstacleSpawnPoints) {
                if (UnityEngine.Random.Range(1, 100) > 50) {
                    createdObstacles[obstacleCount] = SpawnObstacle(spawnPoint);
                    obstacleCount++;
                }
            }
            isInitializingStarted = true;
        }
    }

    private Transform SpawnObstacle(Transform spawnPoint) {
        if (starCounter == 0) {

        }
        Transform chosenObstacle = obstacle[UnityEngine.Random.Range(0, obstacle.Length - 1)];
        Transform spawnedObject = Instantiate(chosenObstacle, spawnPoint);
        return spawnedObject;
    }

    public void ResetRoad(float position) {

        foreach (Transform obstacle in createdObstacles) {
            if(obstacle != null) {
                Destroy(obstacle.gameObject);
            }
        }
        Array.Clear(createdObstacles, 0, createdObstacles.Length);
        obstacleCount = 0;
        isInitializingStarted = false;
        InitiateObstacleSpawn();
        transform.position = new Vector3(0,0,position);
        
    }




}
