using System.Collections;
using UnityEngine;

public class DelayedCubeSpawner : MonoBehaviour
{
	public GameObject cubePrefab; // Префаб куба
	public int numberOfCubes = 10; // Количество кубов для создания
	public float spawnDelay = 1f; // Задержка между появлениями кубов
	public float minX = -5f; // Минимальное значение X
	public float maxX = 5f; // Максимальное значение X
	public float minY = 0f; // Минимальное значение Y
	public float maxY = 10f; // Максимальное значение Y
	public float minZ = -5f; // Минимальное значение Z
	public float maxZ = 5f; // Минимальное значение Z

	void Start()
	{
		StartCoroutine(SpawnCubes());
	}

	IEnumerator SpawnCubes()
	{
		for (int i = 0; i < numberOfCubes; i++)
		{
			Vector3 randomPosition = new Vector3(
				Random.Range(minX, maxX),
				Random.Range(minY, maxY),
				Random.Range(minZ, maxZ)
			);

			Instantiate(cubePrefab, randomPosition, Quaternion.identity);

			yield return new WaitForSeconds(spawnDelay); // Задержка перед следующим появлением
		}
	}
}

