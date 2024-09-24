using System;
using System.Collections;
using UnityEngine;

public class Shoting : MonoBehaviour
{
    private Animator _animator;
	private AudioSource _audioSource;

	public GameObject bullet;
    public Camera mainCamera;
    public Transform spawnBullet;

    public float shootForce;
    public float spread;
    public float fireRate;
	Coroutine currentCoroutine;

    void Awake()
    {
		_animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
	}

	void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if(currentCoroutine == null)
				currentCoroutine = StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        Vector3 dirWithoutSpread = targetPoint - spawnBullet.position;

        float x = UnityEngine.Random.Range(-spread, spread);
        float y = UnityEngine.Random.Range(-spread, spread);

        Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet, spawnBullet.position, Quaternion.identity);

        _animator.SetTrigger("Play");
        _audioSource.Play();


		currentBullet.transform.forward = dirWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);

        yield return new WaitForSeconds(fireRate);

        currentCoroutine = null;
    }
}
