using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card Collection", menuName ="Card Collection")]
public class CardCollection : ScriptableObject
{
    public List<Card> cards;
}
