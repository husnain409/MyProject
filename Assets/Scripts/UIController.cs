using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	public GameObject endGamePanel;

	public Text countText;

	public Text userNameField;

	public MenuController menu;

	int movesCount;

    // Start is called before the first frame update
    void Start()
    {
		endGamePanel.SetActive(false);

		//countText.text = "Moves : 0";
    }

	public void ActivateEndPanel()
	{
		endGamePanel.SetActive(true);
	}

    private void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			endGamePanel.SetActive(true);
		}
    }


    public void ChangeMovesCount(int movesCount)
	{
		this.movesCount = movesCount;
		countText.text = "Moves : " + movesCount.ToString();
	}

	public void SaveHighScore()
	{
		GameTypes gameType = (GameTypes)PlayerPrefs.GetInt("Type");

		TimerController timerController = FindObjectOfType<TimerController>();
		string userName = userNameField.text;
	}

	public void QuitToMenu()
	{
		Application.LoadLevel(Application.loadedLevel);

	}
}
