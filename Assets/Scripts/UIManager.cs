using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject cardPrefab;
    public CardCollection collection;

    public GameData gameTypeOne;
    public GameData gameTypeTwo;
    public GameData gameTypeThree;

    GameData gameData;

    List<CardController> cardControllers;

    private void Awake()
    {

        cardControllers = new List<CardController>();

        GetGameTypeFromGameData();

        SetCardGridLayout();

        GenerateCards();
    }

    private void GenerateCards()
    {
        int cardCount = gameData.rows * gameData.columns;
        for (int i = 0; i < cardCount; i++)
        {
            GameObject card = Instantiate(cardPrefab, transform);
            card.transform.name = "Card (" + i.ToString() + ")";
            cardControllers.Add(card.GetComponent<CardController>());
        }
    }

    private void SetCardGridLayout()
    {
        GridLayout cardGridLayout = GetComponent<GridLayout>();

        cardGridLayout.topPadding = gameData.topPadding;
        cardGridLayout.rows = gameData.rows;
        cardGridLayout.columns = gameData.columns;
        cardGridLayout.spacing = gameData.spacing;
    }

    private void GetGameTypeFromGameData()
    {
        GameTypes gameType = (GameTypes)PlayerPrefs.GetInt("Type", (int) GameTypes.TWO);
        Debug.Log(gameType);

        switch (gameType)
        {
            case GameTypes.ONE:
                gameData = gameTypeOne;
                break;
            case GameTypes.TWO:
                gameData = gameTypeTwo;
                break;
            case GameTypes.THREE:
                gameData = gameTypeThree;
                break;
        }
    }
}
