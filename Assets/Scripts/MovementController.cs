using UnityEngine;

public class MovementController : MonoBehaviour
{
	public static void Move(Transform objTransform, TouchController.Movement movementDir, Vector3 vertRot, Vector3 leftRot,
		float speed)
	{
		switch (movementDir)
		{
			case TouchController.Movement.Up:
				objTransform.transform.position += new Vector3(0, speed, 0);
				objTransform.transform.eulerAngles = vertRot;
				break;

			case TouchController.Movement.Down:
				objTransform.transform.position += new Vector3(0, -speed, 0);
				objTransform.transform.eulerAngles = -vertRot;
				break;

			case TouchController.Movement.Left:
				objTransform.transform.position += new Vector3(0, 0, -speed);
				objTransform.transform.eulerAngles = leftRot;
				break;

			case TouchController.Movement.Right:
				objTransform.transform.position += new Vector3(0, 0, speed);
				objTransform.transform.eulerAngles = Vector3.zero;
				break;
		}
	}


	public static void Move(Transform objTransform, TouchController.Movement movementDir, float speed)
	{
		switch (movementDir)
		{
			case TouchController.Movement.Up:
				objTransform.transform.position += new Vector3(0, speed, 0);
				break;

			case TouchController.Movement.Down:
				objTransform.transform.position += new Vector3(0, -speed, 0);
				break;

			case TouchController.Movement.Left:
				objTransform.transform.position += new Vector3(0, 0, -speed);
				break;

			case TouchController.Movement.Right:
				objTransform.transform.position += new Vector3(0, 0, speed);
				objTransform.transform.eulerAngles = Vector3.zero;
				break;
		}
	}
}