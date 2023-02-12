using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveScript : MonoBehaviour
{

    public float moveSpeed = 1;
    public float deadZone = -45;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // int num = Random.Range(0,2);
        // if(num == 0){
        //     transform.position = transform.position + (new Vector3(Random.Range(-40, 0),Random.Range(-50, -20), 0) * moveSpeed) * Time.deltaTime;
        // } else{
        //     transform.position = transform.position + (new Vector3(Random.Range(-40, 0),Random.Range(-50, 25), 0) * moveSpeed) * Time.deltaTime;
        // }
        transform.position = transform.position + (new Vector3(Random.Range(-50, 0),Random.Range(-50, 50), 0) * moveSpeed) * Time.deltaTime;

        // Code to target bullet in random direction

        // Destroy the bullet once it's outta the fuckin screen
        if(transform.position.x < deadZone){
            Destroy(gameObject);
        }
    }

}
