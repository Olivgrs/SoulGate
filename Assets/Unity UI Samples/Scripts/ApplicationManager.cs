using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ApplicationManager : MonoBehaviour {

	public GameObject Canva;
	public GameObject SFScene;
	public GameObject EventSys;
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
		Destroy(EventSys);
		if(SFScene != null)
			SFScene.SetActive(false);
        SceneManager.LoadScene("Game");
    }

	public void LoadCredit()
    {
        SceneManager.LoadScene("Credit");
    }

    public void LoadMenu()
    {
		Canva.SetActive(false);
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }
}
