using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DifficultyHelper
{


	public static string GetDifficultyString(GameTypes difficulty)
	{
		switch (difficulty)
		{
			case GameTypes.ONE:
				return "easy";
			case GameTypes.TWO:
				return "normal";
			case GameTypes.THREE:
				return "hard";
			default:
				return "easy";
		}
	}
	public static string GetIconSizeByDifficulty(GameTypes difficulty)
	{
		switch (difficulty)
		{
			case GameTypes.ONE:
				return "large";
			case GameTypes.TWO:
				return "normal";
			case GameTypes.THREE:
				return "small";
			default:
				return "large";
		}
	}

	public static Vector2 GetPlayAreaSize(GameTypes difficulty)
	{
		switch (difficulty)
		{
			case GameTypes.ONE:
				return new Vector2(4, 3);
			case GameTypes.TWO:
				return new Vector2(5, 4);
			case GameTypes.THREE:
				return new Vector2(6, 5);
			default:
				return new Vector2(4, 3);
		}
	}
}
