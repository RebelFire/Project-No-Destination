using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour {

    [SerializeField] private Image score;
    [SerializeField] private Transform carRepairUI;

    public event EventHandler OnPlayerDeath;


    private UICarRepair carRepairUIComponent;
    private enum CarStatus { normal, damaged, destroyed };
    private CarStatus carStatus = CarStatus.normal;
    private int carRepairScore = 0;
    private int carRepairScoreMax = 10;

    private void Start() {
        carRepairUIComponent = carRepairUI.GetComponent<UICarRepair>();
    }
    private void Update() {
        if (GameStateManager.instance.CurrentGameState == GameStateManager.GameState.GameOver) {
            return;
        }
    }

    public void DamageCar() {
        switch (carStatus) {
            case CarStatus.normal:
                carStatus = CarStatus.damaged;
                ResetCarRepairScore();
                carRepairUIComponent.ShowRepairMeter();
                break;
            case CarStatus.damaged:
                carStatus = CarStatus.destroyed;
                OnPlayerDeath?.Invoke(this, EventArgs.Empty);
                GameStateManager.instance.GameOver();
                break;
            case CarStatus.destroyed:
                Debug.LogError("Car is already destroyed");
                break;
        }
    }

    private void ResetCarRepairScore() {
        carRepairScore = 0;
    }

    public void AddCarRepairScore(int amount) {
        if(carStatus == CarStatus.damaged) {
            carRepairScore += amount;
            float repairMeterValue = (float)carRepairScore / carRepairScoreMax;
            carRepairUIComponent.UpdateRepairMeter(repairMeterValue);
            if (carRepairScore >= carRepairScoreMax) {
                carStatus = CarStatus.normal;
                ResetCarRepairScore();
                carRepairUIComponent.HideRepairMeter();
            }
        }
        
    }
}
