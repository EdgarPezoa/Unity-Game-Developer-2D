using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private Sprite[] blockSprites;
    [SerializeField] private AudioClip destroySound;
    [SerializeField] private GameObject destroyParticles;

    private LevelLogic level;
    private GameSession gameStatus;
    private int timesHit;
    private int maxHits;

    void Start()
    {
        gameStatus = FindObjectOfType<GameSession>();
        CountBreakableBlocks();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Block") {
            PlayDestroySound();
            AddScore();
            timesHit++;
            if(timesHit >= (blockSprites.Length + 1)) {
                DisplayParticles();
                
                DestroyBlock();
            } else {
                ChangeBlockDamage();
            }
        }
    }

    private void ChangeBlockDamage() {
        int currentSprite = ( timesHit - 1 );
        if( blockSprites[ currentSprite ] ) {
            GetComponent<SpriteRenderer>().sprite = blockSprites[ currentSprite ];

        } else {
            Debug.Log( gameObject.name + " | Mising sprite block sprite number: "+ currentSprite );
        }
    }
    
    private void DestroyBlock() {
        level.BlockDestroyed();
        Destroy( gameObject );
    }
    private void AddScore() {
        gameStatus.AddToScore();
        gameStatus.AddMultiple();
    }
    private void PlayDestroySound() {
        AudioSource.PlayClipAtPoint( destroySound , Camera.main.transform.position );
    }
    private void DisplayParticles() {
        GameObject particles =  Instantiate( destroyParticles, transform.position, transform.rotation );
        Destroy( particles, 2f);
    }

    private void CountBreakableBlocks() {
        level = FindObjectOfType<LevelLogic>();
        if( tag == "Block" ) {
            level.CountBrekableBlocks();
        }
    }
}
