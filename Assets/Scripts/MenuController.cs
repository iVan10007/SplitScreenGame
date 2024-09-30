using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainPanel, _playerCountPanel, _settingsMenu;

	public static int playerCount;

	public void ClickPlayButton()
    {
		_playerCountPanel.SetActive(true);
		_mainPanel.SetActive(false);
	}

	public void ClickPlayerCountButton(int count)
	{
		playerCount = count;
		_playerCountPanel.SetActive(false);
		SceneManager.LoadScene("Game");
	}

	public void ClickSettingsButton()
	{
		_settingsMenu.SetActive(true);
		_mainPanel.SetActive(false);
	}

	public void ClickSettingsBackButton()
	{
		_mainPanel.SetActive(true);
		_settingsMenu.SetActive(false);
	}

	public void ClickPlayersCountBackButton()
	{
		_mainPanel.SetActive(true);
		_playerCountPanel.SetActive(false);
	}
}
