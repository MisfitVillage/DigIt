using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// Player Environment Variables
	private TouchController.Movement _playerMovement;

	[SerializeField] private Vector3 _verticalRot;
	[SerializeField] private Vector3 _leftRot;
	[SerializeField] private float _playerSpeed;


	void Awake()
	{
		_playerMovement = TouchController.Movement.Stationary;
	}


	void FixedUpdate()
	{
		if (_playerMovement != TouchController.Movement.Stationary)
			MovementController.Move(gameObject.transform, _playerMovement, _verticalRot, _leftRot, _playerSpeed);


		if (TouchController.SwipedUp() || Input.GetKey(KeyCode.W))
			_playerMovement = TouchController.Movement.Up;

		else if (TouchController.SwipedDown() || Input.GetKey(KeyCode.S))
			_playerMovement = TouchController.Movement.Down;

		else if (TouchController.SwipedLeft() || Input.GetKey(KeyCode.A))
			_playerMovement = TouchController.Movement.Left;

		else if (TouchController.SwipedRight() || Input.GetKey(KeyCode.D))
			_playerMovement = TouchController.Movement.Right;
	}


	void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.parent.tag.Equals("DestroyableGround"))
			Destroy(collision.gameObject);

		if (collision.transform.tag.Equals("Enemy"))
			Debug.Log("Game Over");
	}
}