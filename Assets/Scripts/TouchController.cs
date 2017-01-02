using UnityEngine;

public class TouchController : MonoBehaviour
{
	// This function detects if the user swiped up on the screen and
	// returns a boolean value accordingly
	public static bool SwipedUp()
	{
		foreach (var touch in Input.touches)
		{
			if (touch.deltaPosition.sqrMagnitude != 0f)
			{
				// Get position delta for touch
				Vector2 deltaPos = touch.deltaPosition;

				// Calculate absolute values for x and y deltas.
				// If y < x && y < 0f, means the user is swiping down, so return true.
				if (Mathf.Abs(deltaPos.x) < Mathf.Abs(deltaPos.y))
				{
					return deltaPos.y > 20f;
				}
			}
		}

		return false;
	}


	// This function detects if the user swiped down on the screen and
	// returns a boolean value accordingly
	public static bool SwipedDown()
	{
		foreach (var touch in Input.touches)
		{
			if (touch.deltaPosition.sqrMagnitude != 0f)
			{
				// Get position delta for touch
				Vector2 deltaPos = touch.deltaPosition;

				// Calculate absolute values for x and y deltas.
				// If y < x && y < 0f, means the user is swiping down, so return true.
				if (Mathf.Abs(deltaPos.x) < Mathf.Abs(deltaPos.y))
				{
					return deltaPos.y < -20f;
				}
			}
		}

		return false;
	}


	// This function detects if the user swiped left on the screen and
	// returns a boolean value accordingly
	public static bool SwipedLeft()
	{
		foreach (var touch in Input.touches)
		{
			if (touch.deltaPosition.sqrMagnitude != 0f)
			{
				Vector2 deltaPos = touch.deltaPosition;
				return deltaPos.x < -20f;
			}
		}

		return false;
	}


	// This function detects if the user swiped right on the screen and
	// returns a boolean value accordingly
	public static bool SwipedRight()
	{
		foreach (var touch in Input.touches)
		{
			if (touch.deltaPosition.sqrMagnitude != 0f)
			{
				Vector2 deltaPos = touch.deltaPosition;
				return deltaPos.x > 20f;
			}
		}

		return false;
	}
}