using System.Collections.Generic;
using UnityEngine;

/* Moving the Enemy:
 * Up / Down - Changing Z-Axis value (Up +Z, Down -Z) - Vector3.up, Vector3.down
 * Left / Right - Change X-Axis value (Left -X, Right +X) - Vector3.forward, Vector3.back
 */

public class EnemyController : MonoBehaviour
{
	private MovementController.Movement _enemyMovement;

	[SerializeField] private float _enemyMovementSpeed;
	[SerializeField] private Vector3 _upRot;
	[SerializeField] private Vector3 _downRot;
	[SerializeField] private Vector3 _leftRot;
	[SerializeField] private Vector3 _rightRot;

	void Awake()
	{
		_enemyMovement = MovementController.Movement.Stationary;
	}


	void FixedUpdate()
	{
		if (_enemyMovement != MovementController.Movement.Stationary)
		{
			if (CheckIfHit())
				_enemyMovement = GetNewDirection();

			MovementController.Move(gameObject.transform, _enemyMovement, _upRot, _downRot, _leftRot, _rightRot,
				_enemyMovementSpeed);
		}

		else
			_enemyMovement = GetNewDirection();
	}


	// Checks if the enemy's going to hit a block soon with the direction its going
	bool CheckIfHit()
	{
		// Get the unit vector associated with the movement
		var movementVector = MovementController.MovementToVector3(_enemyMovement);

		// Raycast the direction
		var hit = Physics.Raycast(transform.position, movementVector, 1f);

		return hit;
	}


	// Returns a direction that the enemy can move towards
	MovementController.Movement GetNewDirection()
	{
		var allowedMovement = new List<MovementController.Movement>();

		var hitUp = Physics.Raycast(transform.position, Vector3.up, 1f);
		if (!hitUp)
			allowedMovement.Add(MovementController.Movement.Up);

		var hitDown = Physics.Raycast(transform.position, Vector3.down, 1f);
		if (!hitDown)
			allowedMovement.Add(MovementController.Movement.Down);

		var hitForward = Physics.Raycast(transform.position, Vector3.forward, 1f);
		if (!hitForward)
			allowedMovement.Add(MovementController.Movement.Left);

		var hitBack = Physics.Raycast(transform.position, Vector3.back, 1f);
		if (!hitBack)
			allowedMovement.Add(MovementController.Movement.Right);

		if (allowedMovement.Count == 0)
			return MovementController.Movement.Stationary;

		int r = Random.Range(0, allowedMovement.Count);
		return allowedMovement[r];
	}
}