using System.Collections;
using TMPro;
using UnityEngine;

public class Turret1Control : MonoBehaviour
{
	public float rotationSpeed = 100f;

	[SerializeField]
	private GameObject _horisontalRotation;
	[SerializeField]
	private GameObject _verticalRotation;
	[SerializeField]
	private Animator _animator;
	[SerializeField]
	private AudioSource _audioSource;
	[SerializeField]
	private int _ammo = 30;
	[SerializeField]
	private GameObject _reloadPanel;
	[SerializeField]
	private TMP_Text _ammoText;

	public KeyCode leftRotateButton = KeyCode.A;
	public KeyCode rightRotateButton = KeyCode.D;
	public KeyCode upRotateButton = KeyCode.W;
	public KeyCode downRotateButton = KeyCode.S;
	public KeyCode shootButton = KeyCode.Q;
	public KeyCode reloadButton = KeyCode.E;

	public GameObject bullet;
	public Camera mainCamera;
	public Transform spawnBullet;

	public float shootForce;
	public float spread;
	public float fireRate;
	Coroutine currentCoroutine;

	void Update()
	{
		if (Input.GetKey(leftRotateButton))
		{
			_horisontalRotation.transform.Rotate(Vector3.down, rotationSpeed * Time.deltaTime);
		}

		else if (Input.GetKey(rightRotateButton))
		{
			_horisontalRotation.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
		}

		if (Input.GetKey(upRotateButton))
		{
			_verticalRotation.transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);
		}

		else if (Input.GetKey(downRotateButton))
		{
			
			_verticalRotation.transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
		}

		if (_reloadPanel.active == false)
		{
			if (Input.GetKey(shootButton))
			{
				if (currentCoroutine == null)
					if (_ammo != 0)
						currentCoroutine = StartCoroutine(Shoot());
					else
					{
						_reloadPanel.SetActive(true);
					}
			}
		}
		else if (Input.GetKeyDown(reloadButton))
		{
			_ammo = 30;
			_reloadPanel.SetActive(false);
		}

		_ammoText.text = _ammo.ToString();

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
		currentBullet.tag = "p1";

		_animator.SetTrigger("Play");
		_audioSource.Play();

		_ammo -= 1;

		currentBullet.transform.forward = dirWithSpread.normalized;

		currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);

		yield return new WaitForSeconds(fireRate);

		currentCoroutine = null;
	}
}
