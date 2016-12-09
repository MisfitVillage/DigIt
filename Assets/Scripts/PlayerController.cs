using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// Player Components

	// Player Environment Variables
	public float PlayerSpeed;
	public Vector3 MovingVerticallyRot;
	public Vector3 IdleStanceRot;
	public Vector3 MovingLeftRot;


	void Start()
	{
	}


	void Update()
	{
		if (TouchController.SwipedUp() || Input.GetKey(KeyCode.W))
		{
			transform.position += new Vector3(0, PlayerSpeed, 0);
			transform.eulerAngles = MovingVerticallyRot;
		}

		else if (TouchController.SwipedDown() || Input.GetKey(KeyCode.S))
		{
			transform.position += new Vector3(0, -PlayerSpeed, 0);
			transform.eulerAngles = -MovingVerticallyRot;
		}

		else if (TouchController.SwipedLeft() || Input.GetKey(KeyCode.A))
		{
			transform.position += new Vector3(0, 0, -PlayerSpeed);
			transform.eulerAngles = MovingLeftRot;
		}

		else if (TouchController.SwipedRight() || Input.GetKey(KeyCode.D))
		{
			transform.position += new Vector3(0, 0, PlayerSpeed);
			transform.eulerAngles = Vector3.zero;
		}

		else
		{
			transform.eulerAngles = IdleStanceRot;
		}
	}


	void OnCollisionEnter(Collision collision)
	{
		if (!collision.transform.parent.tag.Equals("DestroyableGround")) return;
		Destroy(collision.gameObject);
	}
}