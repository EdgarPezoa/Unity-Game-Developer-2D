using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {
    [Range( 0.5f , 1.5f )] [SerializeField] private float gameSpeed = 1f;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private float pointsPerBlock = 100f;
    [SerializeField] private float minMultiple = 1f;
    [SerializeField] private float maxMultiple = 3f;
    [SerializeField] private float rateMultiple = 0.5f;

    private float currentMultiple = 1f;
    private float currentPoints = 0f;

    private void Awake() {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if( gameStatusCount > 1 ) {
            gameObject.SetActive( false );
            Destroy( gameObject );
        } else {
            DontDestroyOnLoad( gameObject );
        }
    }

    private void Start() {
        scoreText.text = currentPoints.ToString();
    }
    void Update() {
        Time.timeScale = gameSpeed;
    }

    public float CurrentPoints { get { return currentPoints; } }

    public void AddToScore() {
        currentPoints += ( pointsPerBlock * currentMultiple );
        scoreText.text = currentPoints.ToString();
    }

    public void ResetMultiple() {
        currentMultiple = minMultiple;
    }

    public void AddMultiple() {
        currentMultiple += rateMultiple;
        if( currentMultiple >= maxMultiple ) {
            currentMultiple = maxMultiple;
        }
    }
    public void DestroyMyself() {
        Destroy(gameObject);
    }

}
