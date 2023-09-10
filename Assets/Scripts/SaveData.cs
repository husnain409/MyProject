using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    public Data dataToSave = new Data();
    public Transform cardsParent;
    public Card[] gameCards;
    public GameManager gm;
    public int matchedCards = 0;

    public void SaveToJson()
    {
        string gameDataToBeSaved = JsonUtility.ToJson(dataToSave);
        string filePath = Application.persistentDataPath + "/cardsgamesaveddata.json";
        System.IO.File.WriteAllText(filePath, gameDataToBeSaved);
        Debug.Log("Saved");
       
    }


    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space)) {
            SaveGridSize();
            SaveAllCardsState();
            SaveToJson();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadFromJson();
            LoadLevelAccordingToJsonData();
        }*/
    }

    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/cardsgamesaveddata.json";
        bool check = System.IO.File.Exists(filePath);

        if (check)
        {
            string dataToLoad = System.IO.File.ReadAllText(filePath);

            dataToSave = JsonUtility.FromJson<Data>(dataToLoad);
            Debug.Log("Loaded");
        }
    }

    public void SaveAllCardsState()
    {
        for (int i = 0; i <= cardsParent.childCount - 1; i++) {
            for (int j = 0; j <= gameCards.Length - 1; j++) {
                if (cardsParent.GetChild(i).GetComponent<CardController>().cardType.name == gameCards[j].name) {
                    dataToSave.cards[i].thisCard = gameCards[j];
                    break;
                }
            }
            if (cardsParent.GetChild(i).transform.GetChild(0).gameObject.activeInHierarchy || cardsParent.GetChild(i).transform.GetChild(1).gameObject.activeInHierarchy)
            {
                dataToSave.cards[i].isMatched = false;
            }
            else {
                dataToSave.cards[i].isMatched = true;
            }
        }
    }

    public void SaveGridSize() {
        dataToSave.gridRows = cardsParent.GetComponent<GridLayout>().rows;
        dataToSave.gridColumns = cardsParent.GetComponent<GridLayout>().columns;
    }

    public void SaveScoreAndMoves()
    {
        dataToSave.score = gm.score;
        dataToSave.moves = gm.movesCount;
    }

    public void LoadLevelAccordingToJsonData()
    {
        gm.tempScore = dataToSave.score;
        gm.tempMoves = dataToSave.moves;
        for (int i = 0; i <= cardsParent.childCount - 1; i++)
        {
            cardsParent.GetChild(i).GetComponent<CardController>().cardType = dataToSave.cards[i].thisCard;
            cardsParent.GetChild(i).GetChild(0).GetComponent<Image>().sprite = dataToSave.cards[i].thisCard.cardImage;
            if (dataToSave.cards[i].isMatched)
            {
                cardsParent.GetChild(i).transform.GetChild(0).gameObject.SetActive(false);
                cardsParent.GetChild(i).transform.GetChild(1).gameObject.SetActive(false);
                cardsParent.GetChild(i).GetComponent<Image>().enabled = false;
                matchedCards += 1;
            }
        }
    }

    public void SaveAllData()
    {
        SaveScoreAndMoves();
        SaveGridSize();
        SaveAllCardsState();
        SaveToJson();
    }

    public void LoadAllData()
    {
        LoadFromJson();
    }

}

[System.Serializable]
public class Data
{
    public int moves;
    public int score;
    public int gridRows;
    public int gridColumns;
    public List<Cards> cards = new List<Cards>();

}

[System.Serializable]
public class Cards
{
    public Card thisCard;
    public bool isMatched;
}

