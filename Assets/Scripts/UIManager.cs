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

    CardGridGenerator cardGridGenerator;

    List<CardController> cardControllers;

    private void Awake()
    {

        cardControllers = new List<CardController>();

        GetGameTypeFromGameData();

        cardGridGenerator = new CardGridGenerator(collection, gameData);

        SetCardGridLayout();

        GenerateCards();

        GameManager gameManager = (GameManager)FindObjectOfType(typeof(GameManager));
        gameManager.CardCount = gameData.rows * gameData.columns;
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

        for (int i = 0; i < cardCount / 2; i++)
        {
            Card randomCard = cardGridGenerator.GetRandomAvailableCardSO();
            SetRandomCardToGrid(randomCard);

            Card randomCardPair = cardGridGenerator.GetCardPairSO(randomCard.cardName);
            SetRandomCardToGrid(randomCardPair);
        }
    }

    private void SetCardGridLayout()
    {
        GridLayout cardGridLayout = GetComponent<GridLayout>();

        cardGridLayout.topPadding = gameData.topPadding;
        cardGridLayout.rows = gameData.rows;
        cardGridLayout.columns = gameData.columns;
        cardGridLayout.spacing = gameData.spacing;
        cardGridLayout.Invoke("CalculateLayoutInputHorizontal", 0.1f);
    }

    private void GetGameTypeFromGameData()
    {
        GameTypes gameType = (GameTypes)PlayerPrefs.GetInt("Type", (int) GameTypes.TWO);

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


    private void SetRandomCardToGrid(Card randomCard)
    {
        int index = cardGridGenerator.GetRandomCardPositionIndex();
        CardController cardObject = cardControllers[index];
        cardObject.SetCardDatas(gameData.background, randomCard);
    }
}
