using UnityEngine;

public class CubeManager : MonoBehaviour
{
	[SerializeField]
	private GameObject _healthBar;

	private bool _destroyFlag = false;

	public float cubeLife = 6;

	private void Awake()
	{
		DestroyObject(gameObject, cubeLife);
	}

	private void Update()
	{
		if (_destroyFlag)
			Destroy(gameObject);
	}

	private void OnCollisionEnter(Collision collision)
	{
		_healthBar.GetComponent<HealthBar>().takeDamage(25f);
		if (_healthBar.GetComponent<HealthBar>().health <= 0)
			if (collision.gameObject.CompareTag("p1"))
			{
				ScoreController._player1Score += 1;
				_destroyFlag = true;
			}
			else if (collision.gameObject.CompareTag("p2"))
			{
				ScoreController._player2Score += 1;
				_destroyFlag = true;
			}
			else if (collision.gameObject.CompareTag("p3"))
			{
				ScoreController._player3Score += 1;
				_destroyFlag = true;
			}
			else if (collision.gameObject.CompareTag("p4"))
			{
				ScoreController._player4Score += 1;
				_destroyFlag = true;
			}
	}
}
