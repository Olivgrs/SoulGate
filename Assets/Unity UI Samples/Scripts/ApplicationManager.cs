using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ApplicationManager : MonoBehaviour {
	
	public GameObject Canva;
	public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

	public void LoadFirstLevel()
    {
		Canva.SetActive(false);
        SceneManager.LoadScene("SolarSystem", LoadSceneMode.Additive);
    }


    public void LoadSecondLevel()
    {
		Canva.SetActive(false);
        SceneManager.LoadScene("SinglePlanet", LoadSceneMode.Additive);
    }
}
