using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusController : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    public GameObject busPrefab;

    [SerializeField]
    private List<GameObject> tempBus;
    private int instantiateNumber;
    // Start is called before the first frame update
    void Start()
    {
        tempBus = new List<GameObject>();
        StartCoroutine(InstantiateBus());
    }

    // Update is called once per frame
    void Update()
    {
        if (tempBus.Count > 0)
        {
            for (int i = 0; i < tempBus.Count; i++)
            {
                tempBus[i].transform.position = Vector2.MoveTowards(tempBus[i].transform.position, endPoint.transform.position, 10 * Time.deltaTime);
                if (Vector2.Distance(tempBus[i].transform.position,endPoint.transform.position) < 0.5f)
                {
                    var clone = tempBus[i];
                    tempBus.RemoveAt(i);
                    Destroy(clone);
                }
            }
            // foreach (var bus in tempBus)
            // {
            //     bus.transform.position = Vector2.MoveTowards(bus.transform.position, endPoint.transform.position, 10 * Time.deltaTime);
            //     if (Vector2.Distance(bus.transform.position,endPoint.transform.position) < 0.5f)
            //     {
            //         Destroy(bus);
            //         tempBus.Remove(bus);
            //     }
            // }
        }
        
    }

    IEnumerator InstantiateBus()
    {
        var bus = Instantiate(busPrefab, startPoint);
        tempBus.Add(bus);
        yield return new WaitForSeconds(10f);
        StartCoroutine(InstantiateBus());
    }
}
