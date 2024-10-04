using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Turret4Control : MonoBehaviour
{
	public float rotationSpeed = 100f;

	[SerializeField]
	private GameObject _horisontalRotation;
	[SerializeField]
	private GameObject _verticalRotation;
	[SerializeField]
	private Slider _slider;
	[SerializeField]
	private Animator _animator;
	[SerializeField]
	private int _ammo = 30;
	[SerializeField]
	private GameObject _reloadPanel;
	[SerializeField]
	private TMP_Text _ammoText;

	public KeyCode leftRotateButton = KeyCode.Keypad4;
	public KeyCode rightRotateButton = KeyCode.Keypad6;
	public KeyCode upRotateButton = KeyCode.Keypad8;
	public KeyCode downRotateButton = KeyCode.Keypad5;
	public KeyCode shootButton = KeyCode.Keypad7;
	public KeyCode reloadButton = KeyCode.Keypad9;

	public GameObject bullet;
	public Camera mainCamera;
	public Transform spawnBullet;

	public float shootForce;
	public float spread;
	public float fireRate;
	Coroutine currentCoroutine;

	void Update()
	{
		var rotationSpeed = _slider.value;

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
		currentBullet.tag = "p4";

		_animator.SetTrigger("Play");

		_ammo -= 1;

		currentBullet.transform.forward = dirWithSpread.normalized;

		currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);

		yield return new WaitForSeconds(fireRate);

		currentCoroutine = null;
	}
}
