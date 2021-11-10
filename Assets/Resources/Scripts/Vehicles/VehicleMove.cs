using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class VehicleMove : MonoBehaviour
{
    [Header("Bus")]
    public Transform startPoint;

    public Transform destinationPoint;
    
    public int moveSpeed;

    public bool isReachedDestinationPoint;

    // private List<GameObject> vechicle = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        var go = GameObject.Find("Cars");
        startPoint = go.transform.Find("BusPos0");
        destinationPoint = go.transform.Find("BusPos1");
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destinationPoint.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position,destinationPoint.position) < 0.5f)
        {
            isReachedDestinationPoint = true;
            // StartCoroutine(DestroyGameObjectLate());
        }
            
        // if (isReachedDestinationPoint)
        // {
        //     // Instantiate(vehicles, startPoint);
        //     GameObject tempBus = Instantiate(Resources.Load("Prefabs/Bus") as GameObject, startPoint);
        //     tempBus.transform.parent = GameObject.Find("Cars").transform;
        //     isReachedDestinationPoint = false;
        // }
        
       
    }

    IEnumerator DestroyGameObjectLate()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
