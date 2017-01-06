using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
	private MovementController.Movement _playerMovement;
	private Animator _playerAnimator;
	private GameManager _gm;
	private int _coinCount;

	public int CoinCount
	{
		get { return _coinCount; }
		private set { _coinCount = value; }
	}

	public AudioClip clip;

	[SerializeField] private Vector3 _upRot;
	[SerializeField] private Vector3 _downRot;
	[SerializeField] private Vector3 _leftRot;
	[SerializeField] private Vector3 _rightRot;
	[SerializeField] private float _playerSpeed;


	void Awake()
	{
		_playerMovement = MovementController.Movement.Stationary;
		_playerAnimator = gameObject.GetComponent<Animator>();
		_coinCount = 0;
		_gm = GameObject.Find("LevelManager").GetComponent<GameManager>();
	}


	void FixedUpdate()
	{
		if (_playerMovement != MovementController.Movement.Stationary)
			MovementController.Move(gameObject.transform, _playerMovement, _upRot, _downRot, _leftRot, _rightRot,
				_playerSpeed);


		if (TouchController.SwipedUp() || Input.GetKey(KeyCode.W))
		{
			_playerMovement = MovementController.Movement.Up;
			_playerAnimator.SetBool("Walking", true);
		}


		else if (TouchController.SwipedDown() || Input.GetKey(KeyCode.S))
		{
			_playerMovement = MovementController.Movement.Down;
			_playerAnimator.SetBool("Walking", true);
		}


		else if (TouchController.SwipedLeft() || Input.GetKey(KeyCode.A))
		{
			_playerMovement = MovementController.Movement.Left;
			_playerAnimator.SetBool("Walking", true);
		}


		else if (TouchController.SwipedRight() || Input.GetKey(KeyCode.D))
		{
			_playerMovement = MovementController.Movement.Right;
			_playerAnimator.SetBool("Walking", true);
		}

		if (CoinCount == _gm.LevelCoinCount)
			_gm.LoadScene(3);
	}


	void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.parent.tag.Equals("DestroyableGround"))
		{
			Destroy(collision.gameObject);
			AudioSource.PlayClipAtPoint(clip, new Vector3(0, 0, 0));
		}

		if (collision.transform.tag.Equals("Coin"))
		{
			Destroy(collision.gameObject);
			CoinCount++;
		}

		if (collision.transform.tag.Equals("Enemy"))
		{
			// Toggle GameOver Condition here
			Debug.Log("Game Over");
			var levelManager = GameObject.FindGameObjectWithTag("Level Manager").gameObject.GetComponent<GameManager>();
			levelManager.LoadScene(4);
		}
	}
}