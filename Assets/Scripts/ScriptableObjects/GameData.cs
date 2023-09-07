using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName ="GameData")]
public class GameData : ScriptableObject
{
    [Header("Grid size settings")]
    public GameTypes type;
    public int rows;
    public int columns;

    [Header("Card background Settings")]
    public Sprite background;

    [Header("Grid Layout Settings")]
    public int topPadding;
    public Vector2 spacing;
}

