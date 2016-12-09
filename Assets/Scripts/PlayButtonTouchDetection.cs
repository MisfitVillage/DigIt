using UnityEngine;

public class PlayButtonTouchDetection : MonoBehaviour
{
	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
			var levelManager = GameObject.FindGameObjectWithTag("Level Manager").gameObject.GetComponent<GameManager>();
			levelManager.LoadScene(1);
		}
	}
}