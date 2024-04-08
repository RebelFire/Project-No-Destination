using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Segment", menuName = "ScriptableObjects/Segment")]
public class SegmentSO : ScriptableObject
{
    public string segmentName;
    //public int segmentSize = 3; // I am planning to change maximum segment limit to 5 in future. 3 is the default value for now.
    public enum NextSegmentChooseMethod {
        allowed,
        forbidden,
    }
    public GameObject[] segmentPrefabs;
    //public SegmentSO requiredNextSegment; // This is not needed anymore. Not deleting it incase of future use.
    public NextSegmentChooseMethod nextSegmentChooseMethod;
    public SegmentSO[] allowedNextSegments;
    public SegmentSOListSO allowedNextSegmentsList;
    public SegmentSO[] forbiddenNextSegments;
    public SegmentSOListSO fobiddenNextSegmentsList;


    // This is for the block system. It will be used in the future. With increasing segment number, it will be more useful.
    public enum blockLocation {         
        left,
        right,
        middle,
        all,
        none
    }
    public blockLocation[] blockLocationType;
}