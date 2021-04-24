﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Waypoint waypoint;
    Vector2Int coordinates = new Vector2Int();

    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.grey;
    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        waypoint = GetComponentInParent<Waypoint>();
        label.enabled = false;
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
        DisplayCoordinates();
    }

    void SetLabelColor()
    {
        if (waypoint.IsPlacable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
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
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x/UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = coordinates.x + "," + coordinates.y;
    }


    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
