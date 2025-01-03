using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] float turnSpeed = 90f;

     // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.GetComponent<Obstacle>() != null){
            Destroy(gameObject);
            return;
        }
        //check object collided is player
        if(other.gameObject.name != "Player"){
            return;
        }
        ;
        //add score
        GameManager.inst.IncrementScore();
        //destroy coin

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
