using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    [SerializeField]
    private string gameOverScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameOver();
    }

    public void GameOver()
    {
        Cursor.visible = true;
        SceneManager.LoadScene(gameOverScene);
    }
}
