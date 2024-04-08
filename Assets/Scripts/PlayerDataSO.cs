using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "ScriptableObjects/PlayerDataSO")]
public class PlayerDataSO : ScriptableObject
{
    public string playerID;
    public int lastPlayID;
    public int highScore;
    public int totalScore;
    public int totalPlayCount;
    public PlayHistorySO[] last10PlayHistorySO = new PlayHistorySO[10];
}