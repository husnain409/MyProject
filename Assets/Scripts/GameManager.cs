using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public UIController uiController;
	public bool gameStarted;
	public SaveData saves;

	GameState gameState;

	public CardSelectionState cardSelectionState;
	public PairSelectionState pairSelectionState;
	public MemorizeCardsState memorizeCardsState;
	public MatchingCardsState matchingCardsState;
	public EndGameState endGameState;
	public PauseGameState pauseGameState;
	//TODO EndGameState and MenuState

	public GameObject[] selectedCards;

	int cardCount;
	public int movesCount;
	public int score;
	public bool loadingSavedGame;

	public Text scoreText;

	public int tempScore;
	public int tempMoves;

	public int CardCount
	{
		set
		{
			cardCount = value;
		}
		get
		{
			return cardCount;
		}
	}

	// Start is called before the first frame update
	void Start()
	{
		if (loadingSavedGame)
		{
			//Debug.Log("this");
			//movesCount = tempMoves;
			//score = tempScore;
			cardCount = 10;
		}
		else {
			movesCount = 0;
			score = 0;
		}
		
		selectedCards = new GameObject[2];
		selectedCards[0] = null;
		selectedCards[1] = null;

		InitStates();

		
	}

	public IEnumerator UpdateCardCountOnLoadingSavedGame()
	{
		yield return new WaitForSeconds(2f);
		cardCount = (saves.dataToSave.gridRows * saves.dataToSave.gridColumns) - saves.matchedCards;
	}



	void Update()
	{

		gameState.UpdateAction();

		if (gameStarted)
		{
			Debug.Log(cardCount);
			if (cardCount <= 0)
			{
				TransitionState(endGameState);
			}
		}

		scoreText.text = "Score : " + score.ToString();
	}

	void InitStates()
	{
		cardSelectionState = new CardSelectionState(this);
		pairSelectionState = new PairSelectionState(this);
		memorizeCardsState = new MemorizeCardsState(this, 0.5f);
		matchingCardsState = new MatchingCardsState(this, 0.2f);
		pauseGameState = new PauseGameState(this);
		endGameState = new EndGameState(this);

		gameState = cardSelectionState;
	}

	public void TransitionState(GameState newState)
	{
		gameState.EndState();
		gameState = newState;
		gameState.EnterState();
	}

	public void SetSelectedCard(GameObject selectedCard)
	{
		movesCount++;
		uiController.ChangeMovesCount(movesCount);

		if (selectedCards[0] == null)
		{
			selectedCards[0] = selectedCard;
			TransitionState(pairSelectionState);
		}
		else if (selectedCards[1] == null)
		{
			selectedCards[1] = selectedCard;

			if (MatchSelectedCards())
			{
				TransitionState(matchingCardsState);
				score = score + 5;
			}
			else
			{
				TransitionState(memorizeCardsState);
			}
		}
	}

	public void RemoveSelectedCards()
	{
		selectedCards[0] = null;
		selectedCards[1] = null;
	}

	bool MatchSelectedCards()
	{
		Card first = selectedCards[0].GetComponent<CardController>().cardType;
		Card second = selectedCards[1].GetComponent<CardController>().cardType;

		return first != null && second != null && first.cardName == second.pairName && first.pairName == second.cardName;
	}
}
