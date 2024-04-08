using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovement : MonoBehaviour
{
    [SerializeField] private Transform[] roads;
    private Transform activeRoad;
    private Transform passiveRoad;
    [SerializeField] float movementSpeed = 20f;
    const int ROAD_LENGTH = 75;
    const int PASSIVE_ROAD_POSITION = 210;
    [SerializeField] private Transform startingLocation;
    private float test = 0;


    private void Start() {
        activeRoad = roads[0];
        passiveRoad = roads[1];
        MoveToStartingPoint();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<PlayerVisualCollision>()) {
            SegmentSO lastSpawned = getLastSpawnedElement();
            ChangeActiveRoad();
            PrepareNextRoad(lastSpawned);
            
            MoveToStartingPoint();


        }
    }

    private void MoveToStartingPoint() {
        //transform.position = startingLocation.position;
        transform.position = new Vector3(0, 0, CalculateRoadSpawnPoint() - 70f);
    }

    private void Update() {
        transform.position += Vector3.back * Time.deltaTime * movementSpeed;
        activeRoad.position += Vector3.back * Time.deltaTime * movementSpeed;
        passiveRoad.position += Vector3.back * Time.deltaTime * movementSpeed;

        test = activeRoad.position.z;
    }

    private SegmentSO getLastSpawnedElement() {
        return activeRoad.gameObject.GetComponent<SegmentCreator>().GetLastSpawnedSegment();
    }

    private void PrepareNextRoad(SegmentSO lastSpawned) {
        
        passiveRoad.gameObject.GetComponent<SegmentCreator>().ResetRoad(lastSpawned);
        passiveRoad.transform.position = new Vector3(0, 0, CalculateRoadSpawnPoint());
    }
    
    private float CalculateRoadSpawnPoint() {
        return _ = activeRoad.position.z  + ROAD_LENGTH * 2f;
    }

    public Transform GetActiveRoad() {
        return activeRoad;
    }

    private void ChangeActiveRoad() {
        if(activeRoad == roads[0]) {
            activeRoad = roads[1];
            passiveRoad = roads[0];
        }
        else {
            activeRoad = roads[0];
            passiveRoad = roads[1];
        }
    }

}
