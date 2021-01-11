using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [Header( "Enemy" )]
    [SerializeField] GameObject deathParticleFabric;
    [SerializeField] private float deathParticleDuration = 1f;
    [SerializeField] private float health = 100;

    [Header( "Proyectile" )]
    [SerializeField] GameObject laserFabric;
    [SerializeField] private float shootCounter = 0;
    [SerializeField] private float proyectileSpeed = 10f;
    [SerializeField] private float minTimeBetweenShoots = 0.2f;
    [SerializeField] private float maxTimeBetweenShoots = 3f;
    

    [Header( "Audio" )]
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private float shootSoundVolume = 0.3f;
    [SerializeField] private float deathSoundVolume = 1f;

    [Header( "Score" )]
    [SerializeField] private int scoreValue = 100;

    // Start is called before the first frame update
    void Start(){
        GenerateShootCounter();
    }

    // Update is called once per frame
    void Update(){
        CountDownAndShoot();
    }

    private void OnTriggerEnter2D( Collider2D collision ) {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if(!damageDealer) { return; }
        ProcessHit( damageDealer );
        Destroy( damageDealer.gameObject );
    }

    private void ProcessHit(DamageDealer damageDealer) {
        health -= damageDealer.GetDamage();
        if( health <= 0 ) {
            Die();
        }
    }

    private void CountDownAndShoot() {
        shootCounter -= Time.deltaTime;
        if( shootCounter <= 0f) {
            Shoot();
            GenerateShootCounter();
        }
    }
    private void Shoot() {
        GameObject laser = Instantiate(laserFabric, transform.position, Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2( 0 , -(proyectileSpeed) );
        AudioSource.PlayClipAtPoint( shootSound , Camera.main.transform.position, shootSoundVolume );
    }

    private void GenerateShootCounter() {
        shootCounter = Random.Range( minTimeBetweenShoots , maxTimeBetweenShoots );
    }

    private void Die() {
        ScoreProcess();
        GameObject deathParticle = Instantiate( deathParticleFabric, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint( deathSound , Camera.main.transform.position, deathSoundVolume );
        Destroy( deathParticle.gameObject, deathParticleDuration );
        Destroy( gameObject );
    }

    private void ScoreProcess() {
        GameSession gameSession = FindObjectOfType<GameSession>();
        gameSession.AddScore( scoreValue );
    }
}
