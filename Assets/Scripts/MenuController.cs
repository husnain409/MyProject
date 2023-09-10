using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
	public GameObject mainMenuPanel;
	public GameObject gamePanel;
	public UIController gameController;

	public SaveData saves;

	public GameManager gm;
	public UIController UI;


	void Start()
	{
		Time.timeScale = 1;
	}

	public void PlayGame(int type)
	{
		gm.loadingSavedGame = false;
		PlayerPrefs.SetInt("Type", type);

		mainMenuPanel.SetActive(false);
		gamePanel.SetActive(true);
		gameController.enabled = true;
		GetComponent<MenuController>().enabled = false;
		gm.gameStarted = true;
	}

	public void LoadGame()
	{
		gm.loadingSavedGame = true;
		saves.LoadAllData();
		gm.score = saves.dataToSave.score;
		gm.movesCount = saves.dataToSave.moves;
		UI.countText.text = "Moves : " + gm.movesCount;
		if (saves.dataToSave.gridRows == 3 && saves.dataToSave.gridColumns == 4) {
			PlayerPrefs.SetInt("Type", 1);
			mainMenuPanel.SetActive(false);
			gamePanel.SetActive(true);
			gameController.enabled = true;
			GetComponent<MenuController>().enabled = false;
			saves.LoadLevelAccordingToJsonData();
		}

		if (saves.dataToSave.gridRows == 4 && saves.dataToSave.gridColumns == 5)
		{
			PlayerPrefs.SetInt("Type", 2);
			mainMenuPanel.SetActive(false);
			gamePanel.SetActive(true);
			gameController.enabled = true;
			GetComponent<MenuController>().enabled = false;
			saves.LoadLevelAccordingToJsonData();
		}

		if (saves.dataToSave.gridRows == 5 && saves.dataToSave.gridColumns == 6)
		{
			PlayerPrefs.SetInt("Type", 3);
			mainMenuPanel.SetActive(false);
			gamePanel.SetActive(true);
			gameController.enabled = true;
			GetComponent<MenuController>().enabled = false;
			saves.LoadLevelAccordingToJsonData();
		}

		gm.gameStarted = true;
		StartCoroutine(gm.UpdateCardCountOnLoadingSavedGame());
	}

}
