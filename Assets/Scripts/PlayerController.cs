using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// Player Environment Variables
	private TouchController.Movement _playerMovement;

	[SerializeField] private Vector3 _movingVerticallyRot;
	[SerializeField] private Vector3 _idleStanceRot;
	[SerializeField] private Vector3 _movingLeftRot;
	[SerializeField] private float _playerSpeed;


	void Awake()
	{
		_playerMovement = TouchController.Movement.Stationary;
	}


	void FixedUpdate()
	{
		if (_playerMovement != TouchController.Movement.Stationary)
		{
			MovePlayer(_playerMovement);
		}


		if (TouchController.SwipedUp() || Input.GetKey(KeyCode.W))
			_playerMovement = TouchController.Movement.Up;

		else if (TouchController.SwipedDown() || Input.GetKey(KeyCode.S))
			_playerMovement = TouchController.Movement.Down;

		else if (TouchController.SwipedLeft() || Input.GetKey(KeyCode.A))
			_playerMovement = TouchController.Movement.Left;

		else if (TouchController.SwipedRight() || Input.GetKey(KeyCode.D))
			_playerMovement = TouchController.Movement.Right;

		Debug.Log(_playerMovement);
	}


	void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.parent.tag.Equals("DestroyableGround"))
			Destroy(collision.gameObject);

		if (collision.transform.tag.Equals("Enemy"))
			Debug.Log("Game Over");
	}


	void MovePlayer(TouchController.Movement movementDir)
	{
		switch (movementDir)
		{
			case TouchController.Movement.Up:
				transform.position += new Vector3(0, _playerSpeed, 0);
				transform.eulerAngles = _movingVerticallyRot;
				break;

			case TouchController.Movement.Down:
				transform.position += new Vector3(0, -_playerSpeed, 0);
				transform.eulerAngles = -_movingVerticallyRot;
				break;

			case TouchController.Movement.Left:
				transform.position += new Vector3(0, 0, -_playerSpeed);
				transform.eulerAngles = _movingLeftRot;
				break;

			case TouchController.Movement.Right:
				transform.position += new Vector3(0, 0, _playerSpeed);
				transform.eulerAngles = Vector3.zero;
				break;
		}
	}
}