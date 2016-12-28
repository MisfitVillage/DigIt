using UnityEngine;

public class PauseManager : MonoBehaviour
{
	private bool _paused;
	private GameObject _pauseMenu;

	void Awake()
	{
		_paused = false;
		_pauseMenu = GameObject.Find("Paused");
		_pauseMenu.SetActive(false);
	}

	void OnMouseDown()
	{
		TogglePause();
	}


	public void TogglePause()
	{
		_paused = !_paused;
		_pauseMenu.SetActive(_paused);
		Time.timeScale = _paused ? 0f : 1f;
	}
}