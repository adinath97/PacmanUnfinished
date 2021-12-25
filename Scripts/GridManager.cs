using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
   public static Transform[,] gameGrid = new Transform[13,21];
   [SerializeField] Transform allNodes;

   private void Awake() {
       PopulateGameGrid();
   }

   private void PopulateGameGrid() {
        //add each child node to the gameGrid as appropriate
        int rowIndex = 0, columnIndex = 20;
        for(int nodeIndex = allNodes.transform.childCount - 1; nodeIndex >= 0; nodeIndex--) {
            // Debug.Log("CURRENTLY AT : (" + rowIndex.ToString() + " , " + columnIndex.ToString() + " ) " );
            gameGrid[rowIndex,columnIndex] = allNodes.GetChild(nodeIndex).gameObject.transform;
            columnIndex--;
            if(columnIndex < 0) {
                rowIndex++;
                columnIndex = 20;
            }
        }

        /* for(int rowIndex2 = 0; rowIndex2 < 13; rowIndex2++) {
            for(int columnIndex2 = 0; columnIndex2 < 21; columnIndex2++) {
                Debug.Log(gameGrid[rowIndex2,columnIndex2].gameObject.name);
            }
        } */
   }
}
