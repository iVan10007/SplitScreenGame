using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _player1ScoreText;
	[SerializeField]
	private TMP_Text _player2ScoreText;
	[SerializeField]
	private TMP_Text _player3ScoreText;
	[SerializeField]
	private TMP_Text _player4ScoreText;

	public static int _player1Score = 0;
	public static int _player2Score = 0;
	public static int _player3Score = 0;
	public static int _player4Score = 0;


	private void Start()
	{
		switch (MenuController.playerCount)
		{
			case 1:
				_player1ScoreText.gameObject.SetActive(true);
				break;
			case 2:
				_player1ScoreText.gameObject.SetActive(true);
				_player2ScoreText.gameObject.SetActive(true);
				break;
			case 3:
				_player1ScoreText.gameObject.SetActive(true);
				_player2ScoreText.gameObject.SetActive(true);
				_player3ScoreText.gameObject.SetActive(true);
				break;
			case 4:
				_player1ScoreText.gameObject.SetActive(true);
				_player2ScoreText.gameObject.SetActive(true);
				_player3ScoreText.gameObject.SetActive(true);
				_player4ScoreText.gameObject.SetActive(true);
				break;
		}
	}

	private void Update()
	{
		_player1ScoreText.text = "Игрок 1 - " + _player1Score;
		_player2ScoreText.text = "Игрок 2 - " + _player2Score;
		_player3ScoreText.text = "Игрок 3 - " + _player3Score;
		_player4ScoreText.text = "Игрок 4 - " + _player4Score;
	}
}
