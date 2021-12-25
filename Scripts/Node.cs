using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] Transform[] neighboringNodes = new Transform[4] {null,null,null,null};
    public PacmanMovement pacman;

    private void Start() {
        pacman = GameObject.FindObjectOfType<PacmanMovement>();
        //node order: top, right, down, left (clockwise)
    }

    public Transform UpdateTargetNode(int myDirection, int nextDirection, int previousDirection) {
        // If moving upwards and direction yields null node and you can keep moving upwards, keep moving upwards
        if(nextDirection < 4 && myDirection < 4) {
            if(neighboringNodes[nextDirection] != null) {
                //Debug.Log("SCENARIO 0");
                pacman.UpdateNextDirection();
                if(nextDirection < 4) {
                    pacman.UpdateCurrentDirection(nextDirection);
                    return neighboringNodes[nextDirection];
                }
                else {
                    return null;
                }
            }
            if(neighboringNodes[nextDirection] == null && neighboringNodes[myDirection] != null) {
                //Debug.Log("SCENARIO 1");
                if(myDirection < 4) {
                    return neighboringNodes[myDirection];
                }
                else {
                    return null;
                }
            }
            return null;
        }
        else if(nextDirection >= 4 && myDirection < 4) {
            if(myDirection < 4) {
                return neighboringNodes[myDirection];
            }
            else {
                return null;
            }
        }
        else {
            //Debug.Log("SCENARIO 3");
            return null;
        }
    }

    public Transform[] GetNeighborNodes() {
        return neighboringNodes;
    }
}
