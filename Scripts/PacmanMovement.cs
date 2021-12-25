using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;

    private int currentGridPosX = 10, currentGridPosY = 6, myDirectionInt, nextDirectionInt, previousDirectionInt;

    public bool nextDirectionUsed;

    private enum Directions { up, right, down, left, none }

    Directions myDirection, previousDirection, nextDirection;

    private Transform targetNode, currentNode, psuedoCurrentNode;

    // Start is called before the first frame update
    void Start()
    {
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        //GetPlayerInput();
        //MovePacMan();
    }

    public void UpdateNextDirection() {
        nextDirection = Directions.none;
    }

    public void UpdateCurrentDirection(int setDirection) {
        switch(setDirection) {
            case 0:
                myDirection = Directions.up;
                break;
            case 1:
                myDirection = Directions.right;
                break;
            case 2:
                myDirection = Directions.down;
                break;
            case 3:
                myDirection = Directions.left;
                break;
        }
    }

    private void SetUp() {
        targetNode = null;
        psuedoCurrentNode = null;
        //currentNode = GridManager.gameGrid[currentGridPosY,currentGridPosX - 4];
        currentNode = GridManager.gameGrid[6,10];
        myDirection = Directions.up;
        nextDirection = myDirection;
        transform.position = currentNode.transform.position;
        FindAccessibleNodes();
    }

    private void GetPlayerInput() {
        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            nextDirection = Directions.up;
            /* if(myDirection == Directions.down) {
                myDirection = Directions.up;
                GoBackwards();
            } */
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow)) {
            nextDirection = Directions.down;
            /* if(myDirection == Directions.up) {
                myDirection = Directions.down;
                GoBackwards();
            } */
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            nextDirection = Directions.left;
            /* if(myDirection == Directions.right) {
                myDirection = Directions.left;
                GoBackwards();
            } */
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow)) {
            nextDirection = Directions.right;
            /* if(myDirection == Directions.left) {
                myDirection = Directions.right;
                GoBackwards();
            } */
        }
    }

    private void GoBackwards() {
        psuedoCurrentNode = currentNode;
        currentNode = targetNode;
        targetNode = psuedoCurrentNode;
    }

    private void MovePacMan() {
        if(this.transform.position != targetNode.position) {
            MoveToNode(targetNode);
        }
        else if(this.transform.position == targetNode.position) {
            FindAccessibleNodes();
        }
    }

    private void MoveToNode(Transform targetNode) {
        this.transform.position = Vector2.MoveTowards(this.transform.position,targetNode.position,moveSpeed * Time.deltaTime);
    }

    private void FindAccessibleNodes() {
        /* 
         once at a node, check the neighboring nodes
         once direction of movement matches the directions associated with the neighboring nodes, move in that direction
        */
        if(targetNode != null) {
            currentNode = targetNode;
        }
        
        targetNode = null;

        targetNode = currentNode.gameObject.GetComponent<Node>().UpdateTargetNode((int) myDirection, (int) nextDirection, (int) previousDirection);
        
        if(targetNode == null) {
            targetNode = currentNode;
        }
    }
}
