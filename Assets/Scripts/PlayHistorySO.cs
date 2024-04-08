using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayHistory", menuName = "ScriptableObjects/PlayHistorySO")]
public class PlayHistorySO : ScriptableObject
{
    public int score;
    public int time;
    public string date = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
}