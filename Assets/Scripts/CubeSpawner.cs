using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
	[SerializeField]
	private GameObject[] _cubePrefabs; // Префаб куба
	[SerializeField]
	private Vector3 _areaCenter; // Центр области
	[SerializeField]
	public Vector3 _areaSize; // Размер области
	[SerializeField]
	private float _spawnDelay = 2f; // Задержка между спавном кубов

	private List<GameObject> cubes = new List<GameObject>();

	void Start()
	{
		StartCoroutine(SpawnCubesCoroutine());
	}

	IEnumerator SpawnCubesCoroutine()
	{
		while(true)
		{
			CreateCube();
			yield return new WaitForSeconds(_spawnDelay); // Задержка перед созданием следующего куба
		}
	}

	void CreateCube()
	{
		Vector3 position;
		do
		{
			position = new Vector3(
				Random.Range(_areaCenter.x - _areaSize.x / 2, _areaCenter.x + _areaSize.x / 2),
				Random.Range(_areaCenter.y - _areaSize.y / 2, _areaCenter.y + _areaSize.y / 2),
				Random.Range(_areaCenter.z - _areaSize.z / 2, _areaCenter.z + _areaSize.z / 2)
			);
		} while (IsPositionOccupied(position));

		var cubeType = Random.Range(0, _cubePrefabs.Length);

		GameObject cube = Instantiate(_cubePrefabs[cubeType], position, Quaternion.identity);
	}

	bool IsPositionOccupied(Vector3 position)
	{
		foreach (GameObject cube in cubes)
		{
			if (Vector3.Distance(cube.transform.position, position) < _cubePrefabs[0].transform.localScale.x)
			{
				return true; // Позиция занята
			}
		}
		return false; // Позиция свободна
	}
}