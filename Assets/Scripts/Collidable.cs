using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];

    protected virtual void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.offset = new Vector2(0.01f, 0.0f);

    }
    protected virtual void Update() {
        //For collision work
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++) {
            if (hits[i] == null) 
                continue;
            

            //Debug.Log(hits[i].name);

            OnCollide(hits[i]);
            
            //clean up the array
            hits[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D coll) {
        Debug.Log(coll.name);
    }

}
