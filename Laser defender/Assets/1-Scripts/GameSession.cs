using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession: MonoBehaviour
{
    private int score = 0;
    private void Awake() {
        SetupSingleton();
    }

    private void SetupSingleton() {
        int gameSessions = FindObjectsOfType( GetType() ).Length;
        if( gameSessions > 1 ) {
            Destroy( gameObject );
        } else {
            DontDestroyOnLoad( gameObject );
        }
    }

    public int GetScore() {
        return score;
    }

    public void AddScore(int score) {
        this.score += score;
    }

    public void ResetScore() {
        score = 0;
    }

    public void ResetGame() {
        Destroy(gameObject);
    }
}
