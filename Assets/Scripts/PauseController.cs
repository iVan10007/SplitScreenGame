using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; // ��� �������� ����
using UnityEngine.UI; // ��� ������ � UI

public class PauseController : MonoBehaviour
{
	[SerializeField]
	private GameObject _pauseMenuUI; // ������ �� ������ ���� �����
	[SerializeField]
	private Slider _slider; // ������ �� ������ ���� �����
	[SerializeField]
	private TMP_Text _sensetivity; // ������ �� ������ ���� �����

	private bool isPaused = false;

	void Update()
	{
		// �������� ������� ������� Escape ��� �����
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
		_pauseMenuUI.SetActive(false); // ������ ���� �����
		Time.timeScale = 1f; // ����������� ����
		isPaused = false;
	}

	public void Pause()
	{
		_pauseMenuUI.SetActive(true); // �������� ���� �����
		Time.timeScale = 0f; // ������������� ����
		isPaused = true;
	}

	public void LoadMainMenu()
	{
		Time.timeScale = 1f; // ����������� ����� ����� ��������� �����
		SceneManager.LoadScene("Main Menu"); // �������� �� ��� ����� ����� �������� ����
	}

	public float getSensetivity()
	{
		return _slider.value;
	}
}