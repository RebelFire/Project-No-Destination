using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    private bool left = true;
    // Start is called before the first frame update
    void Start() {

    }


    // Update is called once per frame
    void Update() {

        if (GameStateManager.instance.CurrentGameState == GameStateManager.GameState.GameOver) {
            return;
        }

        if (left) {
            transform.position += new Vector3(-5, 0, 0) * Time.deltaTime;
        }
        else {
            transform.position += new Vector3(5, 0, 0) * Time.deltaTime;
        }



        if (transform.position.x <= -5) {
            left = false;
        }

        if (transform.position.x >= 5) {
            left = true;
        }
    }
}
