using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkyGhostMovement : MonoBehaviour
{
    [SerializeField] Transform targetNode;

    private Transform[] tempNeighborNodes;
    
    private List<Transform> evaluatedNodes = new List<Transform>();

    private List<Transform> optimalPathNodes = new List<Transform>();

    private List<float> gCosts = new List<float>();

    private List<float> hCosts = new List<float>();

    private List<float> fCosts = new List<float>();

    private Transform localOptimalNode, temporaryTargetNode, currentNode, previousNode, nextNode, startingNode;

    private int currentGridPosX = 20, currentGridPosY = 12, nodeCounter = 0;

    private bool pathFound = false;

    private float moveSpeed = 1.5f, gCost, fCost, hCost;

    
    private void Start() {
        SetUp();
    }

    private void SetUp() {
        targetNode = GridManager.gameGrid[6,10];
        currentNode = GridManager.gameGrid[currentGridPosY,currentGridPosX];
        transform.position = currentNode.transform.position;
        FindOptimalPath();
        Debug.Log("LOOKING FOR OPTIMAL PATH!");
    }

    private void FindOptimalPath() {
        
    }

    /*
    private void MoveToTargetNode() {
        if(temporaryTargetNode == null) { return; }
        if(transform.position != temporaryTargetNode.position) {
            MoveToNode(temporaryTargetNode);
        }
        else if(this.transform.position == temporaryTargetNode.position) {
            previousNode = currentNode;
            currentNode = temporaryTargetNode;
            FindTemporaryTargetNode();
        }

    }

    private void MoveToNode(Transform tempTargetNode) {
        this.transform.position = Vector2.MoveTowards(this.transform.position,tempTargetNode.position,moveSpeed * Time.deltaTime);

    }

    private void FindTemporaryTargetNode() {
        //look in possible directions
        //determine which one is closer to target (Euclidean metric on R2)
        //Go after the one that is closer, then re-evaluate
        tempNeighborNodes = currentNode.gameObject.GetComponent<Node>().GetNeighborNodes();
        float distance = 1000f;
        foreach(Transform neighborNode in tempNeighborNodes) {
            if(neighborNode == null) { 
                continue;
            }
            float distanceTemp = Mathf.Sqrt(Mathf.Pow(neighborNode.position.x - targetNode.position.x,2) + Mathf.Pow(neighborNode.position.y - targetNode.position.y,2));
            if(distanceTemp < distance && neighborNode != previousNode) {
                distance = distanceTemp;
                temporaryTargetNode = neighborNode;
            }
        }
    }
    */
}
