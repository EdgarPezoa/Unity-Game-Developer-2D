using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [Header( "Player" )]
    [SerializeField] private GameObject deathParticleFabric;
    [SerializeField] private float deathParticleDuration = 1f;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float padding = 0.5f;
    [SerializeField] private float health = 100f;

    [Header( "Proyectile" )]
    [SerializeField] private GameObject laserFabric;
    [SerializeField] private float proyectileSpeed = 10f;
    [SerializeField] private float proyectileShootPeriod = 0.1f;

    [Header( "Audio" )]
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] [Range(0f, 1f)] private float shootSoundVolume = 0.3f;
    [SerializeField] [Range( 0f , 1f )] private float deathSoundVolume = 1f;

    Coroutine ShootCoroutine;
    float xMin;
    float xMax;
    float yMin;
    float yMax;    

    // Start is called before the first frame update
    void Start(){
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update(){
        Move();
        Shoot();
    }

    private void OnTriggerEnter2D( Collider2D collision ) {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if( !damageDealer ) { return; }
        ProcessHit( damageDealer );
        Destroy( damageDealer.gameObject );
    }

    private void Shoot() {
        if(Input.GetButtonDown("Fire1")) {
            ShootCoroutine = StartCoroutine( FireContinously() );
        }
        if(Input.GetButtonUp("Fire1")) {
            StopCoroutine( ShootCoroutine );
        }
    }
    private IEnumerator FireContinously() {
        while(true) {
            GameObject laser = Instantiate( laserFabric , transform.position , Quaternion.identity );
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2( 0 , proyectileSpeed );
            AudioSource.PlayClipAtPoint( shootSound , Camera.main.transform.position, shootSoundVolume );
            yield return new WaitForSeconds(proyectileShootPeriod);
        }
    }

    private void Move() {
        float deltaX = Input.GetAxis( "Horizontal" ) * Time.deltaTime * moveSpeed;
        float deltaY = Input.GetAxis( "Vertical" ) * Time.deltaTime * moveSpeed;
        float newXPos = Mathf.Clamp( ( transform.position.x + deltaX ) , xMin , xMax );
        float newYPos = Mathf.Clamp( ( transform.position.y + deltaY ) , yMin , yMax );
        transform.position = new Vector2( newXPos, newYPos );
    }

    private void SetUpMoveBoundaries() {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint( new Vector3( 0 , 0 , 0 ) ).x + padding;
        xMax = gameCamera.ViewportToWorldPoint( new Vector3( 1 , 0 , 0 ) ).x - padding;

        yMin = gameCamera.ViewportToWorldPoint( new Vector3( 0 , 0 , 0 ) ).y + padding;
        yMax = gameCamera.ViewportToWorldPoint( new Vector3( 0 , 1 , 0 ) ).y - padding;
    }

    private void ProcessHit( DamageDealer damageDealer ) {
        health -= damageDealer.GetDamage();
        if( health <= 0 ) {
            Die();
        }
    }

    private void Die() {
        FindObjectOfType<SceneHandler>().LoadGameOver();
        GameObject deathParticle = Instantiate( deathParticleFabric , transform.position , Quaternion.identity );
        AudioSource.PlayClipAtPoint( deathSound , Camera.main.transform.position, deathSoundVolume );
        Destroy( deathParticle.gameObject , deathParticleDuration );
        Destroy( gameObject );
    }

    public float GetHealth() {
        return health;
    }
}
