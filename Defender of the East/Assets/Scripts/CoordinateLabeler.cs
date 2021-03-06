using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    GridManager gridManager;
    Vector2Int coordinates = new Vector2Int();

    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.grey;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f, 0.5f, 0f);
    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        gridManager = FindObjectOfType<GridManager>();
        label.enabled = false;
        DisplayCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
        SetLabelColor();
        ToggleLabel();
 
    }

    void SetLabelColor()
    {
        if (gridManager == null) { return; }
        Node node = gridManager.GetNode(coordinates);
        if (node == null) { return; }
        if (!node.isWalkable)
        {
            label.color = blockedColor;
        }else if (node.isPath)
        {
            label.color = pathColor;
        }else if (node.isExplored)
        {
            label.color = exploredColor;
        }
        else
        {   
            label.color = defaultColor;
        }
       
    }

    void ToggleLabel()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    void DisplayCoordinates()
    {
        if (gridManager == null) { return; }
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x/gridManager.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / gridManager.UnityGridSize);

        label.text = coordinates.x + "," + coordinates.y;
    }


    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
