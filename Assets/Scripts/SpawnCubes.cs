using System.Collections;
using UnityEngine;

public class DelayedCubeSpawner : MonoBehaviour
{
	public GameObject cubePrefab; // ������ ����
	public int numberOfCubes = 10; // ���������� ����� ��� ��������
	public float spawnDelay = 1f; // �������� ����� ����������� �����
	public float minX = -5f; // ����������� �������� X
	public float maxX = 5f; // ������������ �������� X
	public float minY = 0f; // ����������� �������� Y
	public float maxY = 10f; // ������������ �������� Y
	public float minZ = -5f; // ����������� �������� Z
	public float maxZ = 5f; // ����������� �������� Z

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

			yield return new WaitForSeconds(spawnDelay); // �������� ����� ��������� ����������
		}
	}
}

