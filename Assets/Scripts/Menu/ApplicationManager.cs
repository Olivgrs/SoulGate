using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ApplicationManager1 : MonoBehaviour {
	
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
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }
}
