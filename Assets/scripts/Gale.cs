using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gale : MonoBehaviour{
    private int damage = 30;
    private float galeSpeed = 5;

    private float reach = 4.0f;

    private Vector3 pos;

    private Transform myTransform;

    private Character player;

    void Awake(){
        this.player = GetComponent<Character>();
    }

    void Start(){
        myTransform = transform;
        pos = myTransform.position;
    }

    void Update(){
        myTransform.Translate(new Vector3(1,0,0) * galeSpeed * Time.deltaTime);
        if(myTransform.position.x >= pos.x + reach || myTransform.position.x <= pos.x - reach){
            Destroy(gameObject);
        }
    }
}