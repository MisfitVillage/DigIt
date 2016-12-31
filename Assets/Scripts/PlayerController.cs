using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private TouchController.Movement _playerMovement;
	private Animator _playerAnimator;

	[SerializeField] private Vector3 _verticalRot;
	[SerializeField] private Vector3 _leftRot;
	[SerializeField] private float _playerSpeed;


	void Awake()
	{
		_playerMovement = TouchController.Movement.Stationary;
		_playerAnimator = gameObject.GetComponent<Animator>();
	}


	void FixedUpdate()
	{
		if (_playerMovement != TouchController.Movement.Stationary)
			MovementController.Move(gameObject.transform, _playerMovement, _verticalRot, _leftRot, _playerSpeed);


		if (TouchController.SwipedUp() || Input.GetKey(KeyCode.W))
		{
			_playerMovement = TouchController.Movement.Up;
			_playerAnimator.SetBool("Walking", true);
		}


		else if (TouchController.SwipedDown() || Input.GetKey(KeyCode.S))
		{
			_playerMovement = TouchController.Movement.Down;
			_playerAnimator.SetBool("Walking", true);
		}


		else if (TouchController.SwipedLeft() || Input.GetKey(KeyCode.A))
		{
			_playerMovement = TouchController.Movement.Left;
			_playerAnimator.SetBool("Walking", true);
		}


		else if (TouchController.SwipedRight() || Input.GetKey(KeyCode.D))
		{
			_playerMovement = TouchController.Movement.Right;
			_playerAnimator.SetBool("Walking", true);
		}
	}


	void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.parent.tag.Equals("DestroyableGround"))
			Destroy(collision.gameObject);

		if (collision.transform.tag.Equals("Enemy"))
		{
			// Toggle GameOver Condition here
			Debug.Log("Game Over");
		}
	}
}