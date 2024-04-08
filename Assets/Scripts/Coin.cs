using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : MonoBehaviour
{
    [SerializeField] Transform screwdriver;
    [SerializeField] Transform hammer;
    [SerializeField] Transform wrench;

    [SerializeField] Material screwdriverMaterialNormal;
    [SerializeField] Material screwdriverMaterialGlow;
    [SerializeField] Material hammerMaterialNormal;
    [SerializeField] Material hammerMaterialGlow;
    [SerializeField] Material wrenchMaterialNormal;
    [SerializeField] Material wrenchMaterialGlow;


    private bool emissionChangeState = false;
    private float emissionChangeTime = 0f;
    private float emissionChangeTimeMax = 0.5f;


    private bool magnetMode = false;

    private void Update() {
        if(emissionChangeTime < emissionChangeTimeMax) {
            emissionChangeTime += Time.deltaTime;
        } else {
            ChangeEmission();
            emissionChangeTime = 0;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.TryGetComponent<PlayerVisualCollision>(out var playerVisualCollision)) {
            playerVisualCollision.CoinCollision();
        }
        
        DestroyCoin();
    }

    public void DestroyCoin() {
        Destroy(gameObject);
    }

    private void ChangeMaterial(Transform tool, Material material) {
        tool.gameObject.GetComponent<Renderer>().material = material;
    }

    private void ChangeEmission() {

        if (emissionChangeState) {
            ChangeMaterial(wrench, wrenchMaterialNormal);
            ChangeMaterial(hammer, hammerMaterialNormal);
            ChangeMaterial(screwdriver, screwdriverMaterialNormal);
            emissionChangeState = false;
        } else {
            ChangeMaterial(wrench, wrenchMaterialGlow);
            ChangeMaterial(hammer, hammerMaterialGlow);
            ChangeMaterial(screwdriver, screwdriverMaterialGlow);
            emissionChangeState = true;
        }
    }
}
