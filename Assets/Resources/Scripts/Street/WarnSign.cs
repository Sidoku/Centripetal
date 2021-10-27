using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarnSign : MonoBehaviour
{
    public Transform destinationPoint;
    
    public Transform[] InstantiatePoints;
    public int moveSpeed;
    public GameObject[] ObstacleObjects;
    public int obstacleNumber;
    private GameObject tempObstacles;
    private bool startInstantiateObstacles;
    private MessageTest _messageTest;
    
    // Start is called before the first frame update
    void Start()
    {
        _messageTest = FindObjectOfType<MessageTest>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_messageTest.isPlayer == 1 && !startInstantiateObstacles)
        {
            // StartCoroutine(InstantiateObstacles());
            // InstantiatePoints()
            InstantiateObstacles();
        }

        if (startInstantiateObstacles)
        {
            tempObstacles.transform.position = Vector2.MoveTowards(tempObstacles.transform.position, destinationPoint.position, Random.Range(20,30) * Time.deltaTime);
            if (Vector2.Distance(tempObstacles.transform.position,destinationPoint.position) < 1f)
            {
                Destroy(tempObstacles);
                startInstantiateObstacles = false;
            }
        }

        if (obstacleNumber == 5)
        {
            // Debug.Log("11111");
        }

        
    }
    private void InstantiateObstacles()
    {
        int pointID = Random.Range(0, 3);
        int objectID = Random.Range(0, 2);
        tempObstacles = Instantiate(ObstacleObjects[objectID],InstantiatePoints[pointID]);
        obstacleNumber++;
        startInstantiateObstacles = true;
    }
}
