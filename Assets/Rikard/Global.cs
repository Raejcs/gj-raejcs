using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Global {
	// State of the changing game objects
	public static SOType type = 0;
	public static float rotationSpeed = 0.03f;

	public static void restartCurrentScene()
	{
		int scene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(scene, LoadSceneMode.Single);
	}
}
