using UnityEngine;

public class QuitManager : MonoBehaviour
{
	void OnMouseDown()
	{
		var levelManager = GameObject.FindGameObjectWithTag("Level Manager").gameObject.GetComponent<GameManager>();

		if (levelManager)
			levelManager.LoadScene(0);
	}
}