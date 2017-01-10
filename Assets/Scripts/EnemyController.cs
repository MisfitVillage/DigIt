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
				_enemyMovement = GetRandomDirection();

			MovementController.Move(gameObject.transform, _enemyMovement, _upRot, _downRot, _leftRot, _rightRot,
				_enemyMovementSpeed);
		}

		else
			_enemyMovement = GetRandomDirection();
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


	MovementController.Movement GetRandomDirection()
	{
		var allowedMovement = new[]
		{
			MovementController.Movement.Up,
			MovementController.Movement.Down,
			MovementController.Movement.Left,
			MovementController.Movement.Right
		};

		int r = Random.Range(0, allowedMovement.Length);
		return allowedMovement[r];
	}


	void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.parent.tag.Equals("Player"))
			return;

		_enemyMovement = GetRandomDirection();
	}


	void OnCollisionStay(Collision collision)
	{
		if (collision.transform.parent.tag.Equals("Player"))
			return;

		_enemyMovement = GetRandomDirection();
	}
}