using UnityEngine;

/* Moving the Enemy:
 * Up / Down - Changing Z-Axis value (Up +Z, Down -Z)
 * Left / Right - Change X-Axis value (Left -X, Right +X)
 */

public class EnemyController : MonoBehaviour
{
	[SerializeField] private Transform _target;
	[SerializeField] private float _enemyMovSpeed;


	void Awake()
	{
	}


	void Update()
	{
	}
}