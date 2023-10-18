using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellPoint : MonoBehaviour
{
    public bool isFull;
    public string tileRed = "TileRed";
    public string tileYellow = "TileYellow";
    public string tileGreen = "TileGreen";
    public string tilePink = "TilePink";
    public string tilePurple = "TilePurple";
    public int cellReturnCountRed;
    public int cellReturnCountYellow;
    public int cellReturnCountGreen;
    public int cellReturnCountPink;
    public int cellReturnCountPurple;
    // Start is called before the first frame update
    void Start()
    {
        cellReturnCountRed = 0;
        isFull = false;
    }

    // Update is called once per frame
    void Update()
    {
        checkCellPoint();
    }
    void checkCellPoint()
    {
        if (transform.childCount != 1)
        {
            if (transform.GetChild(1).CompareTag(tileRed))
            {
                cellReturnCountRed = 1;
            }
            else if (transform.GetChild(1).CompareTag(tileGreen))
            {
                cellReturnCountGreen = 1;
            }
            else if (transform.GetChild(1).CompareTag(tileYellow))
            {
                cellReturnCountYellow = 1;
            }
            else if (transform.GetChild(1).CompareTag(tilePink))
            {
                cellReturnCountPink = 1;
            }
            else if (transform.GetChild(1).CompareTag(tilePurple))
            {
                cellReturnCountPurple = 1;
            }
        }
        else
        {
            cellReturnCountRed = 0;
            cellReturnCountGreen = 0;
            cellReturnCountYellow = 0;
            cellReturnCountPink = 0;
            cellReturnCountPurple = 0;
        } 
    }
}
