using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusMove : MonoBehaviour
{
    public Transform[] points;
    public int moveSpeed;

    private int i;

    private SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position,points[i].position) < 0.01f)
        {
            i = i == 0 ? 1 : 0;
            sprite.flipX = i != 1;
        }
       
    }
}
