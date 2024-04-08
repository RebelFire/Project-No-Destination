using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Segment List", menuName = "ScriptableObjects/Segment List")]
public class SegmentSOListSO : ScriptableObject
{
    public string segmentListName;
    public SegmentSO[] segments;
}