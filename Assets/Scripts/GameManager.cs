using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public int LevelCoinCount;

	void Start()
	{
		Application.targetFrameRate = 60;
		Time.timeScale = 1;
	}


	public void LoadScene(int sceneBuildIndex)
	{
		SceneManager.LoadScene(sceneBuildIndex);
	}
}