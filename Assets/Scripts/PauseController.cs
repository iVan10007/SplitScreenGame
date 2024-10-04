using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; // Для загрузки сцен
using UnityEngine.UI; // Для работы с UI

public class PauseController : MonoBehaviour
{
	[SerializeField]
	private GameObject _pauseMenuUI; // Ссылка на панель меню паузы
	[SerializeField]
	private Slider _slider; // Ссылка на панель меню паузы
	[SerializeField]
	private TMP_Text _sensetivity; // Ссылка на панель меню паузы

	private bool isPaused = false;

	void Update()
	{
		// Проверка нажатия клавиши Escape для паузы
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (isPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}

		_sensetivity.text = _slider.value.ToString();
	}

	public void Resume()
	{
		_pauseMenuUI.SetActive(false); // Скрыть меню паузы
		Time.timeScale = 1f; // Возобновить игру
		isPaused = false;
	}

	public void Pause()
	{
		_pauseMenuUI.SetActive(true); // Показать меню паузы
		Time.timeScale = 0f; // Приостановить игру
		isPaused = true;
	}

	public void LoadMainMenu()
	{
		Time.timeScale = 1f; // Возобновить время перед загрузкой сцены
		SceneManager.LoadScene("Main Menu"); // Замените на имя вашей сцены главного меню
	}

	public float getSensetivity()
	{
		return _slider.value;
	}
}