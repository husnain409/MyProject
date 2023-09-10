﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class CardGridGenerator 
{
	CardCollection cardCollection;

	Vector2[] positions;
	List<GameObject> cards;

	List<int> availableImageIndexes;
	List<int> availablePositionIndexes;

	int cardCount;

	public CardGridGenerator(CardCollection cardCollection, GameData gameDatas)
	{
		this.cardCollection = cardCollection;
		cardCount = gameDatas.rows * gameDatas.columns;

		GenerateAvailableImageIndexes();
		GenerateAvailablePositionIndexes(cardCount);
	}

	public Card GetRandomAvailableCardSO()
	{
		int random = UnityEngine.Random.Range(0, this.availableImageIndexes.Count);
		int randomIndex = availableImageIndexes[random];

		availableImageIndexes.RemoveAt(random);

		return cardCollection.cards[randomIndex];
	}

	public Card GetCardPairSO(string cardPairName)
	{
		foreach(Card card in cardCollection.cards)
		{
			if(card.IsPair(cardPairName))
			{
				return card;
			}
		}

		return null;
	}

	public int GetRandomCardPositionIndex()
	{
		int randomIndex = UnityEngine.Random.Range(0, availablePositionIndexes.Count);
		int randomPosition = availablePositionIndexes[randomIndex];

		availablePositionIndexes.RemoveAt(randomIndex);

		return randomPosition;
	}

	void GenerateAvailableImageIndexes()
	{
		availableImageIndexes = new List<int>();
		int index = cardCollection.cards.Count;

		for(int i = 0; i < index; i++)
		{
			if (i % 2 == 0)
			{
				this.availableImageIndexes.Add(i);
			}
		}
	}

	private void GenerateAvailablePositionIndexes(int cardCount)
	{
		availablePositionIndexes = new List<int>();

		for (int i = 0; i < cardCount; i++)
		{
			availablePositionIndexes.Add(i);
		}
	}
}
