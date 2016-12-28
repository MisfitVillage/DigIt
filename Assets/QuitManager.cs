using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitManager : MonoBehaviour
{
	void OnMouseDown()
	{
		SceneManager.LoadScene(0);
	}
}