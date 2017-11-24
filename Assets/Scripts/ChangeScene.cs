using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public void MENU_ACTION_GoToPage(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void MENU_ACTION_Exit()
    {
        Application.Quit();
    }
}
