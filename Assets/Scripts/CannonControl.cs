using UnityEngine;

public class CannonControl : MonoBehaviour
{
	public float rotationSpeed = 100f; 

	public KeyCode leftRotateButton = KeyCode.A;
	public KeyCode rightRotateButton = KeyCode.D;
	public KeyCode upRotateButton = KeyCode.W;
	public KeyCode downRotateButton = KeyCode.S;

	private GameObject _horisontalRotation;
	private GameObject _verticalRotation;
	private Animator _animator;
	
	private void Awake()
	{
		_horisontalRotation = GameObject.FindGameObjectWithTag("horizontal");
		_verticalRotation = GameObject.FindGameObjectWithTag("vertical");
		_animator = GetComponent<Animator>();
		//Cursor.visible = false;
	}

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
	}
}
