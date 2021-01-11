using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    private GameSession gameStatus;
    private void Start() {
        gameStatus = FindObjectOfType<GameSession>();
    }
    public void LoadNextScene(){
        Cursor.visible = true;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void PlayAgain()
    {
        gameStatus.DestroyMyself();
        SceneManager.LoadScene(0);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
