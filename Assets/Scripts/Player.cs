using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        
    }

    void FixedUpdate()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        moveDelta = new Vector3(x, y, 0);

        //swap the player sprite
        if (moveDelta.x > 0) {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0) {
            transform .localScale = new Vector3(-1, 1 ,1);
        }

        //hit collision y
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if(hit.collider == null) {

            //move the player
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        // collision x
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null) {

            //move the player
            transform.Translate( moveDelta.x * Time.deltaTime, 0, 0);
        }


    }
}
