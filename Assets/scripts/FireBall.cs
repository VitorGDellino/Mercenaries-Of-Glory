using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour{

    public float damage = 30;
    public float fireBallSpeed = 5;
    private float reach = 2.0f;

    private Vector3 pos;
    private Transform myTransform;

    void Start(){
        myTransform = transform;
        pos = myTransform.position;
    }

    void Update(){
        myTransform.Translate(new Vector3(1,0,0) * fireBallSpeed * Time.deltaTime);
        if(myTransform.position.x >= pos.x + reach || myTransform.position.x <= pos.x - reach){
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        Destroy(gameObject);
    }
}