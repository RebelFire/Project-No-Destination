using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Obstacle : MonoBehaviour
{

    public void DestroyObstacle() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {

        if (other is BoxCollider) {

            if(other.gameObject.TryGetComponent<PlayerVisualCollision>(out var playerVisualCollision)) {
                playerVisualCollision.DamageCar();
            }
            DestroyObstacle();

        }
        else {

        }
    }
}
