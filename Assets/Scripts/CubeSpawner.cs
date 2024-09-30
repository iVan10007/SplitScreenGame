
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
	[SerializeField]
	private GameObject _cubePrefab; // Префаб куба
	[SerializeField]
	private float _spawnDelay = 1f; // Задержка между появлениями кубов
	[SerializeField]
	private float _spawnPoint = 300;
	[SerializeField]
	private float spacing = 1.5f;

	void Start()
	{
		StartCoroutine(SpawnCubes());
	}

	IEnumerator SpawnCubes()
	{
		while (true)
		{
			for (int i = 0; i < MenuController.playerCount; i++)
			{
				var flag = false;
				while (!flag)
				{
					Vector3 randomPosition = generatePosition();

					if (IsPositionFree(randomPosition))
					{
						spawnCubes(randomPosition);
						flag = true;
					}
				}

				yield return new WaitForSeconds(_spawnDelay);
			}
		}
	}

	bool IsPositionFree(Vector3 position)
	{
		Collider[] colliders = Physics.OverlapSphere(position, spacing / 2);
		return colliders.Length == 0; // Позиция свободна, если нет коллайдеров в радиусе
	}

	void spawnCubes(Vector3 randomPosition)
	{
		Instantiate(_cubePrefab, randomPosition, Quaternion.identity);
		randomPosition.x += 300;
		Instantiate(_cubePrefab, randomPosition, Quaternion.identity);
		randomPosition.x += 300;
		Instantiate(_cubePrefab, randomPosition, Quaternion.identity);
		randomPosition.x += 300;
		Instantiate(_cubePrefab, randomPosition, Quaternion.identity);
		randomPosition.x = 300;
	}

	Vector3 generatePosition()
	{
		float minX = _spawnPoint - 7;
		float maxX = _spawnPoint + 7;

		Vector3 randomPosition = new Vector3(
			Random.Range(minX, maxX),
			Random.Range(2, 7),
			510);

		return randomPosition;
	}
}

