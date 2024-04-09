using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour {

    public static GameStateManager instance { get; private set; }

    public enum GameState {
        InGame,
        GameOver
    }

    private void Awake() {
        if (instance != null && instance != this)
            Destroy(gameObject);    // Ensures that there aren't multiple Singletons

        instance = this;

    }

    public void RestartScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private GameState currentGameState = GameState.InGame;

    public GameState CurrentGameState {
        get
        {
            return currentGameState;
        }
    }

    public void StartGame() {
        currentGameState = GameState.InGame;
    }

    public void GameOver() {
        currentGameState = GameState.GameOver;
    }


}
