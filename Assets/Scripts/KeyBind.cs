using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class KeyBind : MonoBehaviour
{
    private Dictionary<string, KeyCode> _1playerKeys = new Dictionary<string, KeyCode>();
	private Dictionary<string, KeyCode> _2playerKeys = new Dictionary<string, KeyCode>();
	private Dictionary<string, KeyCode> _3playerKeys = new Dictionary<string, KeyCode>();
	private Dictionary<string, KeyCode> _4playerKeys = new Dictionary<string, KeyCode>();

	private GameObject _currentKey;

	private Color normal = Color.white;
	private Color selected = Color.gray;

	public TMP_Text left, right, up, down, fire, reload;

	void Start()
    {
		_1playerKeys.Add("Left", (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A")));
        _1playerKeys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));
		_1playerKeys.Add("Down", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Down", "S")));
		_1playerKeys.Add("Up", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));
		_1playerKeys.Add("Fire", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Fire", "Q")));
		_1playerKeys.Add("Reload", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Reload", "E")));

		//_2playerKeys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));
		//_2playerKeys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));
		//_2playerKeys.Add("Down", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));
		//_2playerKeys.Add("Up", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));
		//_2playerKeys.Add("Fire", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));
		//_2playerKeys.Add("Reload", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));

		//_3playerKeys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));
		//_3playerKeys.Add("Right", (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));
		//_3playerKeys.Add("Down", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));
		//_3playerKeys.Add("Up", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));
		//_3playerKeys.Add("Fire", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));
		//_3playerKeys.Add("Reload", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));

		//_4playerKeys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));
		//_4playerKeys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));
		//_4playerKeys.Add("Down", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));
		//_4playerKeys.Add("Up", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));
		//_4playerKeys.Add("Fire", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));
		//_4playerKeys.Add("Reload", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));

		left.text = _1playerKeys["Left"].ToString();
		right.text = _1playerKeys["Right"].ToString();
		up.text = _1playerKeys["Up"].ToString();
		down.text = _1playerKeys["Down"].ToString();
		fire.text = _1playerKeys["Fire"].ToString();
		reload.text = _1playerKeys["Reload"].ToString();
	}

	void OnGUI()
	{
		if(_currentKey != null)
		{
			Event e = Event.current;
			if(e.isKey)
			{
				_1playerKeys[_currentKey.name] = e.keyCode;
				_currentKey.transform.GetChild(0).GetComponent<TMP_Text>().text = e.keyCode.ToString();
				_currentKey.GetComponent<Image>().color = normal;
				_currentKey = null;
			}
		}
	}

	public void ChangeKey(GameObject clicked)
	{
		if (_currentKey != null)
		{
			_currentKey.GetComponent<Image>().color = normal;
		}
		_currentKey = clicked;
		_currentKey.GetComponent<Image>().color = selected;
	}

	public void SaveKeys()
	{
		foreach(var key in _1playerKeys)
		{
			PlayerPrefs.SetString(key.Key, key.Value.ToString());
		}

		PlayerPrefs.Save();
	}
}
