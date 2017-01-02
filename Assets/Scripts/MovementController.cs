using UnityEngine;

public class MovementController : MonoBehaviour
{
	// Enum to set perpetual movement
	public enum Movement
	{
		Up,
		Down,
		Left,
		Right,
		Stationary
	}


	// Receives a Movement direction and returns its Vector3 direction
	public static Vector3 MovementToVector3(Movement movement)
	{
		if (movement == Movement.Up)
			return Vector3.up;

		if (movement == Movement.Down)
			return Vector3.down;

		if (movement == Movement.Left)
			return Vector3.forward;

		if (movement == Movement.Right)
			return Vector3.back;

		return Vector3.zero;
	}


	// Moves an object and applies rotation
	public static void Move(Transform objTransform, Movement movementDir, Vector3 upRot, Vector3 downRot,
		Vector3 leftRot, Vector3 rightRot, float speed)
	{
		// I hate Quaternions, so screw that noise.
		switch (movementDir)
		{
			case Movement.Up:
				objTransform.transform.position += new Vector3(0, speed, 0);
				objTransform.transform.eulerAngles = upRot;
				break;

			case Movement.Down:
				objTransform.transform.position += new Vector3(0, -speed, 0);
				objTransform.transform.eulerAngles = downRot;
				break;

			case Movement.Left:
				objTransform.transform.position += new Vector3(0, 0, -speed);
				objTransform.transform.eulerAngles = leftRot;
				break;

			case Movement.Right:
				objTransform.transform.position += new Vector3(0, 0, speed);
				objTransform.transform.eulerAngles = rightRot;
				break;
		}
	}
}