using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Card Objects")]
public class Card : ScriptableObject
{
    public string cardName;
    public string pairName;
    public Sprite cardImage;
}
