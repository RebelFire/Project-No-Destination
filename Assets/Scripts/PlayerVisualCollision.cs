using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerVisualCollision : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private CapsuleCollider magnetCollider;
    [SerializeField] private SpriteRenderer magnetSprite;
    private PlayerStatus playerStatus;
    private PlayerScore playerScore;
    private bool magnetMode = false;
    private BoxCollider boxCollider;
    private Vector3 boxColliderSize;
    private const float magnetModeSize = 15f;
    private const float nonMagnetModeSize = 2.5f;

    private float remainingMagnetDuration = 5f;
    private float magnetDuration = 5f;

    private void Start() {
        playerStatus = player.GetComponent<PlayerStatus>();
        playerScore = player.GetComponent<PlayerScore>();
        boxCollider = GetComponent<BoxCollider>();

        boxCollider = GetComponent<BoxCollider>();

        boxColliderSize = boxCollider.size;
    }

    private void Update() {

        
        if (magnetMode == true) {
            if (remainingMagnetDuration > 0) {
                remainingMagnetDuration -= Time.deltaTime;
            }
            else {
                remainingMagnetDuration = magnetDuration;
                ToggleMagnetMode();
            }
        }
        

        
        
    }

    public void DamageCar() {
        playerStatus.DamageCar();
    }

    public void ToggleMagnetMode() {
        if(magnetMode) {
            //boxCollider.size = new Vector3(nonMagnetModeSize, boxColliderSize.y, boxColliderSize.z);
            magnetMode = false;
            magnetCollider.enabled = false;
            magnetSprite.gameObject.SetActive(false);
        } else {
            //boxCollider.size = new Vector3(magnetModeSize, boxColliderSize.y, boxColliderSize.z);
            magnetMode = true;
            magnetCollider.enabled = true;
            magnetSprite.gameObject.SetActive(true);
        }
    }

    public void CoinCollision() {
        playerScore.AddScore(1);
        playerStatus.AddCarRepairScore(1);
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.GetComponent<Magnet>()){
            ToggleMagnetMode();
            other.gameObject.GetComponent<Magnet>().DestroyMagnet();
        }


    }
}
