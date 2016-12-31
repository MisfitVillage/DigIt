using UnityEngine;

public class ResumeManager : MonoBehaviour
{
	private PauseManager _pauseManagerRef;

	void Awake()
	{
		_pauseManagerRef = GameObject.Find("PauseButton").GetComponent<PauseManager>();
	}

	void OnMouseDown()
	{
		if (_pauseManagerRef)
			_pauseManagerRef.TogglePause();
	}
}