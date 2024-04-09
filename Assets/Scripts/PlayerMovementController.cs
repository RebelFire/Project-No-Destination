using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 12f;
    //[SerializeField] private float jumpSpeed = 5f; // Not implemented yet
    [SerializeField] private Transform[] movementPositionGameObjects;
    [SerializeField] private Transform jumpPoint;
    [SerializeField] private Transform playerVisual;
    [SerializeField] private ShrinkUI shrinkUI;
    private bool isMovingCompleted = true;
    private bool isJumpingCompleted = true;
    private int score = 0; // Temporary score system

    private float remainingShrinkCooldown = 0f;
    private float shrinkCooldown = 30f;

    private float remainingShrinkDuration = 5f;
    private float shrinkDuration = 5f;

    private bool isShrunk = false;

    private enum movementPoints {
        left,
        right,
        middle
    }
    private movementPoints currentMovementPoint;

    private void Start() {
        shrinkUI = shrinkUI.GetComponent<ShrinkUI>();
        currentMovementPoint = movementPoints.middle;
    }

    private void Update() {

        if (GameStateManager.instance.CurrentGameState == GameStateManager.GameState.GameOver) {
            return;
        }

        ShrinkController();

        if (!isMovingCompleted) {
            MoveTowards(currentMovementPoint);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isJumpingCompleted) {

        }

        if (Input.GetKeyDown(KeyCode.T) && remainingShrinkCooldown <= 0 && !isShrunk) {
            Shrink();
        }



        if (Input.GetKey(KeyCode.A) && isMovingCompleted) {
            switch (currentMovementPoint) {
                case movementPoints.left:
                    break;
                case movementPoints.middle:
                    currentMovementPoint = movementPoints.left;
                    break;
                case movementPoints.right:
                    currentMovementPoint = movementPoints.middle;
                    break;
                default:
                    break;
            }
            isMovingCompleted = false;
        }

        if (Input.GetKey(KeyCode.D) && isMovingCompleted) {
            switch (currentMovementPoint) {
                case movementPoints.left:
                    currentMovementPoint = movementPoints.middle;
                    break;
                case movementPoints.middle:
                    currentMovementPoint = movementPoints.right;
                    break;
                case movementPoints.right:
                    break;
                default:
                    break;
            }
            isMovingCompleted = false;

        }


    }

    private void Shrink() {
        playerVisual.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        isShrunk = true;
        remainingShrinkDuration = shrinkDuration;
    }

    private void Unshrink() {
        playerVisual.transform.localScale = new Vector3(1f, 1f, 1f);
        isShrunk = false;
        remainingShrinkDuration = shrinkDuration;
        remainingShrinkCooldown = shrinkCooldown;
    }

    private void ShrinkController() {
        if (isShrunk) {
            if (remainingShrinkDuration <= 0) {
                Unshrink();
            }
            else {
                remainingShrinkDuration -= Time.deltaTime;
                
            }
        }
        else {
            if(remainingShrinkCooldown > 0) {
                remainingShrinkCooldown -= Time.deltaTime;
                shrinkUI.ChangeImageRadial(remainingShrinkCooldown / shrinkCooldown, remainingShrinkCooldown);
            }
        }


      
    }


    private void MoveTowards(movementPoints movementPoint) {

        switch (movementPoint) {
            case movementPoints.left:
                transform.position = Vector3.MoveTowards(transform.position, movementPositionGameObjects[0].position, moveSpeed * Time.deltaTime);
                break;
            case movementPoints.middle:
                transform.position = Vector3.MoveTowards(transform.position, movementPositionGameObjects[1].position, moveSpeed * Time.deltaTime);
                break;
            case movementPoints.right:
                transform.position = Vector3.MoveTowards(transform.position, movementPositionGameObjects[2].position, moveSpeed * Time.deltaTime);
                break;
            default:
                break;
        }

        if (transform.position == movementPositionGameObjects[0].position || transform.position == movementPositionGameObjects[1].position || transform.position == movementPositionGameObjects[2].position) {
            isMovingCompleted = true;
        }
        else {
            isMovingCompleted = false;
        }
    }



}
