using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    private LogicManager logic;
    /*
    * Array of enemy positions in the screen
    */
    private Vector3[] enemyPositions = {
        new Vector3(26.78f, -10.82f, -0.1357524f),
        new Vector3(20.75f, 4.53f, 0),
        new Vector3(20.84f, 13.99f, 9)
    };

    // -------- VARIABLES ------------
    public GameObject bullet;
    public float spawnRate = 2;
    public float timer = 0;

    /*
    * This method is used to spawn the `bullet` object
    * The starting point of the bullet is from `enemyPositions`
    */
    void spawnBullet(){
        bullet.transform.position = enemyPositions[Random.Range(0,3)]; 
        Instantiate(bullet);
        bullet.SetActive(true);
        logic.reduceEnemyScore(1);
        // bullet.SetPosition()
    }


    /*
    * This method is used to spawn the bullet initially`
    */
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>(); 
        // AudioSource audio = GetComponent<AudioSource>();
        // audio.clip = logic.gamePlayBackgroundMusic;
        // audio.Play();
        spawnBullet();
    }

    // Update is called once per frame
    // This method controls the spawn rate of the bullet
    void Update()
    {
        logic.handleChangeCameraBackground();
        if(logic.isPlayerAlive){
            if(timer < spawnRate){
                timer = timer + Time.deltaTime;
            } else {
                spawnBullet();
                timer = 0;
            }
        }
        
    }
}
