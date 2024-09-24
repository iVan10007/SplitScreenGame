using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLife = 3;

	private void Awake()
	{
		DestroyObject(gameObject, bulletLife);
	}
}
