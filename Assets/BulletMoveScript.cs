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
        // Code to target bullet in random direction
        transform.position = transform.position + (new Vector3(Random.Range(-40, 0),Random.Range(-10, 10), 0) * moveSpeed) * Time.deltaTime;

        // Destroy the bullet once it's outta the fuckin screen
        if(transform.position.x < deadZone){
            Destroy(gameObject);
        }
    }

}
