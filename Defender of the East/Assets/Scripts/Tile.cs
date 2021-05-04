using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlacable;
    Vector2Int coordinates = new Vector2Int();
    
    public bool IsPlacable{get{return isPlacable;}}  //property

    GridManager gridManger;

    void Awake()
    {
        gridManger = FindObjectOfType<GridManager>();    
    }

     void Start()
    {
        if (gridManger != null)
        {
            coordinates = gridManger.GetcoordinatesFromPosition(transform.position);
            if (!isPlacable)
            {
                gridManger.BlockNode(coordinates);
            }
        }    
    }

    void OnMouseDown()
    {
       
        if (isPlacable)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab,transform.position);
            isPlacable =!isPlaced;
        }
    }
}
