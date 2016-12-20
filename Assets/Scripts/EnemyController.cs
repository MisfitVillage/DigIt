using UnityEngine;

/* Moving the Enemy:
 * Moving Up / Down - Changing Z-Axis value (Up +Z, Down -Z)
 * Moving Left / Right - Change X-Axis value (Left -X, Right +X)
 */

public class EnemyController : MonoBehaviour
{
	/* This byte array holds the enemy allowed movement as such:
	 * [0] = Up
    * [1] = Down
	 * [2] = Left
	 * [3] = Right
	 *
	 * If the value in each of these positions is true it represents that the enemy CAN move in that direction
	 * If it's false, on the other hand, the enemy cannot move in that direction
	 */
	private bool[] _enemyMovement;

	public float EnemyMovementSpeed; // Assigned in Editor

	void Awake()
	{
		_enemyMovement = new bool[4]; // New byte array, with all 4 positions init at 0
	}


	void Update()
	{
		// Make the enemy move to a random direction (that it's allowed to)
		MoveEnemy(GetRandomAllowedDirection());

		// Test in what directions the enemy will be able to move in the next frame
		TestAllowedDirections();
	}

	// TODO: This.
	void TestAllowedDirections()
	{
		// Raycast Up, Down, Left and Right
		var hitUp = Physics.Raycast(transform.position, new Vector3(0, 0, 1));
		_enemyMovement[0] = !hitUp;

		var hitDown = Physics.Raycast(transform.position, new Vector3(0, 0, -1));
		_enemyMovement[1] = !hitDown;

		var hitLeft = Physics.Raycast(transform.position, new Vector3(-1, 0, 0));
		_enemyMovement[2] = !hitLeft;

		var hitRight = Physics.Raycast(transform.position, new Vector3(1, 0, 0));
		_enemyMovement[3] = !hitRight;

		Debug.DrawRay(transform.position, new Vector3(0, 0, 1), Color.cyan);
		Debug.DrawRay(transform.position, new Vector3(0, 0, -1), Color.cyan);
		Debug.DrawRay(transform.position, new Vector3(-1, 0, 0), Color.cyan);
		Debug.DrawRay(transform.position, new Vector3(1, 0, 0), Color.cyan);
	}


	// Returns a random direction for the enemy to move to
	int GetRandomAllowedDirection()
	{
		var allowedDirections = new int[_enemyMovement.Length];
		for (var i = 0; i < _enemyMovement.Length; i++)
		{
			if (_enemyMovement[i])
			{
				allowedDirections[i] = i;
			}
		}

		int r = Random.Range(0, allowedDirections.Length);
		return allowedDirections[r];
	}


	void MoveEnemy(int direction)
	{
		switch (direction)
		{
			case 0: // Up
				transform.Translate(new Vector3(0, 0, EnemyMovementSpeed));
				break;

			case 1: // Down
				transform.Translate(new Vector3(0, 0, -EnemyMovementSpeed));
				break;

			case 2: // Left
				transform.Translate(new Vector3(EnemyMovementSpeed, 0, 0));
				break;

			case 3: // Right
				transform.Translate(new Vector3(-EnemyMovementSpeed, 0, 0));
				break;
		}
	}
}