using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private UIScore ui;
    [SerializeField] private UIEndGame endGameUI;
    
    private UIScore uiComponent;
    [SerializeField] private int score = 0;
    private int highScore = 0;
    private float timePassed = 0;
    private bool isHighScoreAchieved = false;
    private bool webglbuild = false;

    private PlayerData playerData;
    private PlayHistory[] plays;
    //[SerializeField] private PlayerScore playerScore;

    [Serializable]
    public struct PlayerData
    {
        public string playerName;
        public int highScore;
        public int totalScore;
        public int totalPlayTime;
        public int totalPlayCount;
        public int[] playHistory;
    }

    public struct PlayHistory
    {
        public int score;
        public int time;
        public DateTime date;
    }


    public float GetTime() {
        return timePassed;
    }

    private void Awake() {
#if UNITY_WEBGL
        webglbuild = true;
#endif
    }



    private void Start() {
        uiComponent = ui.gameObject.GetComponent<UIScore>();
        gameObject.GetComponent<PlayerStatus>().OnPlayerDeath += OnPlayerDeathEvent;

        if (!webglbuild) {
            playerData = ReadData();
            highScore = playerData.highScore;
        }



        

    }

    private void Update() {

        if (GameStateManager.instance.CurrentGameState == GameStateManager.GameState.GameOver) {
            return;
        }

        timePassed += Time.deltaTime;
        uiComponent.UpdateTime((int)timePassed);
    }

    public PlayerData GetPlayerData() {
        return playerData;
    }

    private void OnPlayerDeathFromPlayerScore(int score, int time) {
        if (!webglbuild) {
            int lastPlay = WritePlayHistory(score, time);
            UpdateLastPlay(lastPlay);
            playerData.totalScore += score;
            if (playerData.highScore < score) {
                isHighScoreAchieved = true;
                playerData.highScore = score;
            }
            playerData.totalPlayTime += time;
            playerData.totalPlayCount++;
            WritePlayerData(playerData);
        }
        
    }



    private void UpdateLastPlay(int lastPlay) {

        File.Delete("Saves/Plays/" + playerData.playHistory[0] + ".json");
        for (int i = 0; i < playerData.playHistory.Length - 1; i++) {
            playerData.playHistory[i] = playerData.playHistory[i + 1];
        }
        playerData.playHistory[playerData.playHistory.Length - 1] = lastPlay;
    }

    private void CreateEmptyPlayerData() {
        playerData = new PlayerData {
            playerName = "Player",
            highScore = 0,
            totalScore = 0,
            totalPlayTime = 0,
            totalPlayCount = 0,
            playHistory = new int[10]
        };

        for (int i = 0; i < playerData.playHistory.Length; i++) {
            playerData.playHistory[i] = WritePlayHistory(0, 0);
        }

        WritePlayerData(playerData);
    }


    private PlayerData ReadData() {
        if (!webglbuild) {
            string json = File.ReadAllText("Saves/PlayerData.json");

            PlayerData loadedPlayer = JsonUtility.FromJson<PlayerData>(json);

            return loadedPlayer;
        }
        return new PlayerData();
        
    }

    private PlayHistory ReadPlayHistory(string playName) {
        string json = File.ReadAllText("Saves/Plays/" + playName + ".json");

        PlayHistory loadedPlay = JsonUtility.FromJson<PlayHistory>(json);

        return loadedPlay;
    }

    public int WritePlayHistory(int score, int time) {

        PlayHistory playHistory = new PlayHistory {
            score = score,
            time = time,
            date = DateTime.Now
        };

        int randomNumber = UnityEngine.Random.Range(100000, 999999);
        string json = JsonUtility.ToJson(playHistory);
        File.WriteAllText("Saves/Plays/" + randomNumber + ".json", json);
        return randomNumber;
    }

    public void WritePlayerData(PlayerData playerData) {
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText("Saves/PlayerData.json", json);
    }

    private void OnPlayerDeathEvent(object sender, EventArgs e) {
        OnPlayerDeathFromPlayerScore(score, (int)timePassed);
        ShowGameEndUI();
    }

   


    private void ShowGameEndUI() {
        endGameUI.EnableGUI(isHighScoreAchieved, score, (int)timePassed);
    }



    public void AddScore(int amount) {
        score += amount;
        if(score >= highScore) {
            SetHighScore(score);
            ui.UpdateScore(score, true);
        }
        else {
            ui.UpdateScore(score, false);
        }   
    }



    public int GetScore() {
        return score;
    }

    public void ResetScore() {
        score = 0;
    }

    public void ShowScore() {
        
    }

    public int GetHighScore() {
        return highScore;
    }

    public void SetHighScore(int score) {
        highScore = score;
        isHighScoreAchieved = true;
        playerData.highScore = highScore;
        uiComponent.UpdateHighScore(highScore);
    }

}
