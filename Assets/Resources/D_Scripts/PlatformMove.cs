using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public Transform[] points;
    public int moveSpeed;

    public int i;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position,points[i].position) < 0.01f)
        {
            i = i == 0 ? 1 : 0;
        }
       
    }
    
}
