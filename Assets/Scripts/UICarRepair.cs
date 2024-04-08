using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICarRepair : MonoBehaviour
{
    [SerializeField] private Image repairMeterImage;
    [SerializeField] private Image repairMeterBackgroundImage;

    // Update the repair meter image
    // This method is called from PlayerStatus.cs
    // The value is the repair score divided by the maximum repair score
    public void UpdateRepairMeter(float value) {
        repairMeterImage.fillAmount = value;
    }


    public void HideRepairMeter() {
        repairMeterImage.gameObject.SetActive(false);
        repairMeterBackgroundImage.gameObject.SetActive(false);
    }

    public void ShowRepairMeter() {
        UpdateRepairMeter(0);
        repairMeterImage.gameObject.SetActive(true);
        repairMeterBackgroundImage.gameObject.SetActive(true);
    }
}
