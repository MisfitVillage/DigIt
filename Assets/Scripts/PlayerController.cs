using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// Player Components
	private Rigidbody _playerRb;


	// Player Environment Variables
	public float PlayerSpeed;

	void Start()
	{
		_playerRb = gameObject.GetComponent<Rigidbody>();
	}


	void Update()
	{
	}


	void OnCollisionEnter(Collision collision)
	{
	}
}