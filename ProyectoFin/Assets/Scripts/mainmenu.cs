using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    public int index;
    public void PlayGame()
    {
        SceneManager.LoadScene(index);//scene changer
    }
    public void SelectScene()
    {
        SceneManager.LoadScene(index+2);

    }
    public void QuitGame() {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
