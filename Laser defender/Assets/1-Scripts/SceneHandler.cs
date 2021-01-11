using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] private float delaySceneInSeconds = 2f;

    private IEnumerator DelayGameOver() {
        yield return new WaitForSeconds( delaySceneInSeconds );
        SceneManager.LoadScene( "Game Over" );
    }

    public void LoadGameOver() {
        StartCoroutine( DelayGameOver() );
    }

    public void LoadGameScene() {
        FindObjectOfType<GameSession>().ResetScore();
        SceneManager.LoadScene( "Game" );
    }

    public void LoadStartMenu() {
        FindObjectOfType<GameSession>().ResetScore();
        SceneManager.LoadScene(0);
    }

    public void QuiGame() {
        Application.Quit();
    }
}
