using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonHandler : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flightStrength;
    public LogicManager logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>(); 

    }

    // Update is called once per frame
    void Update()
    {
        if(logic.isPlayerAlive){
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                myRigidbody.velocity = Vector2.up * flightStrength;
            }

            if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
                myRigidbody.velocity = Vector2.right * flightStrength;
            }

            if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
                myRigidbody.velocity = Vector2.left * flightStrength;
            }

            if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
                myRigidbody.velocity = Vector2.down * flightStrength;
            }

            if(myRigidbody.position.x < -35 || myRigidbody.position.y < -25 || myRigidbody.position.x > 35 || myRigidbody.position.y > 25){
                logic.handlePlayerDead();
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.reducePlayerScore();
    }
}
