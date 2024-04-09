using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SegmentCreator : MonoBehaviour {

    [SerializeField] private Transform[] segmentSpawnPoints;
    private SegmentSO[] segments;
    [SerializeField] private SegmentSOListSO segmentList;
    [SerializeField] private SegmentSO lastSpawnedSegment;
    [SerializeField] private SegmentSOListSO starSegmentList;
    [SerializeField] private SegmentSO startingSegment;
    private SegmentSO[] starSegments;
    private GameObject[] spawnedSegments;
    private int segmentCount = 0;
    private bool isInitializingStarted = false;
    private int starCounter = 0;
    private const int SEGMENT_STARTING_LOCATION = -5;

    private void Start() {
        PickRandomStarCounter();
        spawnedSegments = new GameObject[segmentSpawnPoints.Length*3];
        segments = segmentList.segments;
        starSegments = starSegmentList.segments;
        InitiateSegmentSpawn();
        
    }

    private void Update() {
        if (GameStateManager.instance.CurrentGameState == GameStateManager.GameState.GameOver) {
            return;
        }
    }
    private void PickRandomStarCounter() {
        starCounter = UnityEngine.Random.Range(50, 100);
    }

    public SegmentSO GetLastSpawnedSegment() {
        return lastSpawnedSegment;
    }


    public void ResetRoad(SegmentSO lastSpawnedSegmentFromPrevious) {

        foreach (GameObject segment in spawnedSegments) {
            if(segment != null) {
                Destroy(segment);
            }
        }
        lastSpawnedSegment = lastSpawnedSegmentFromPrevious;
        Array.Clear(spawnedSegments, 0, spawnedSegments.Length);
        segmentCount = 0;
        isInitializingStarted = false;
        InitiateSegmentSpawn();
    }

    private void InitiateSegmentSpawn() {
        if(isInitializingStarted) {
            return;
        }

        foreach (Transform spawnPoint in segmentSpawnPoints) {
            if(starCounter == 0) {
                FillSegment(spawnPoint, true);
            }
            else {
                starCounter--;
                FillSegment(spawnPoint, false);
            }
            
            
        }
        isInitializingStarted = true;
    }

    private SegmentSO GetRandomStarSegment() {
        SegmentSO randomSegment;
        randomSegment = starSegments[UnityEngine.Random.Range(0, starSegments.Length)];
        return randomSegment;
    }

    private SegmentSO GetRandomSegment(SegmentSO previousSegment) {
        SegmentSO randomSegment;
        switch (previousSegment.nextSegmentChooseMethod) {
            case SegmentSO.NextSegmentChooseMethod.allowed:
                randomSegment = previousSegment.allowedNextSegments[UnityEngine.Random.Range(0, previousSegment.allowedNextSegments.Length)];
                break;
            case SegmentSO.NextSegmentChooseMethod.forbidden:
                if (previousSegment.forbiddenNextSegments.Length != 0) {
                    randomSegment = segments[UnityEngine.Random.Range(0, segments.Length)];
                    while (System.Array.Exists(previousSegment.forbiddenNextSegments, element => element == randomSegment)) {
                        randomSegment = segments[UnityEngine.Random.Range(0, segments.Length)];
                    }
                }
                else {
                    randomSegment = segments[UnityEngine.Random.Range(0, segments.Length)];
                    //goto case default;
                }
                break;
            default:
                randomSegment = segments[UnityEngine.Random.Range(0, segments.Length)];
                break;
        }
        return randomSegment;

    }

    private void FillSegment(Transform spawnPoint, bool starSpawn) {

        SegmentSO spawnedSegment;
        int firstSpawnPoint = SEGMENT_STARTING_LOCATION;
        if (starSpawn) {
            spawnedSegment = GetRandomStarSegment();
            PickRandomStarCounter();
            lastSpawnedSegment = startingSegment;
        }
        else {
            spawnedSegment = GetRandomSegment(lastSpawnedSegment);
            lastSpawnedSegment = spawnedSegment;
        }
        
        foreach(GameObject prefab in spawnedSegment.segmentPrefabs) {
            GameObject g = Instantiate(prefab, spawnPoint);
            g.transform.localPosition = new Vector3(0, 0, firstSpawnPoint);
            spawnedSegments[segmentCount] = g;
            segmentCount++;
            firstSpawnPoint += 5;
        }

        

    }


}
