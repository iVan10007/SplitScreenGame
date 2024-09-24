using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainPanel;

	[SerializeField]
	private GameObject _playerCountPanel;

	public int _playerCount;

	public void ClickPlayButton()
    {
		_playerCountPanel.SetActive(true);
		_mainPanel.SetActive(false);
	}

	public void ClickPlayerCountButton(int count)
	{
		_playerCount = count;
		_playerCountPanel.SetActive(false);
		SceneManager.LoadScene("Game");
	}
}
