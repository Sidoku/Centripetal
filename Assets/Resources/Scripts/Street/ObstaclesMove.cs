using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesMove : MonoBehaviour
{
    // public Transform destinationPoint;
    // public Transform[] InstantiatePoints;
    // public int moveSpeed;
    // public GameObject[] ObstacleObjects;
    // private GameObject[] tempObstacles = new GameObject[10];
    // private bool startInstantiateObstacles;
    // private MessageTest _messageTest;
    //
    // // Start is called before the first frame update
    // void Start()
    // {
    //     _messageTest = FindObjectOfType<MessageTest>();
    //     // ObstacleObjects[0] = Resources.Load("Prefabs/WarningSign") as GameObject;
    // }
    //
    // // Update is called once per frame
    // void Update()
    // {
    //     if (_messageTest.isPlayer == 1 && !startInstantiateObstacles)
    //     {
    //         // StartCoroutine(InstantiateObstacles());
    //         // InstantiatePoints()
    //         InstantiateObstacles(1);
    //     }
    //
    //     if (startInstantiateObstacles)
    //     {
    //         tempObstacles.transform.position = Vector2.MoveTowards(tempObstacles.transform.position, destinationPoint.position, moveSpeed * Time.deltaTime);
    //     }
    // }
    //
    // // IEnumerator InstantiateObstacles()
    // // {
    // //     yield return new WaitForSeconds(1f);
    // //     var tempObstacle = Instantiate(ObstacleObjects[0], InstantiatePoints[0]);
    // //     tempObstacle.transform.position = Vector2.MoveTowards(tempObstacle.transform.position, destinationPoint.position, moveSpeed * Time.deltaTime);
    // //     Debug.Log("hahahahahah");
    // // }
    //
    // private void InstantiateObstacles(int id)
    // {
    //     // startInstantiateObstacles = false;
    //     switch (id)
    //     {
    //         case 1:
    //             tempObstacles = Instantiate(ObstacleObjects[0],InstantiatePoints[0]);
    //             startInstantiateObstacles = true;
    //             break;
    //         case 2:
    //             break;
    //     }
    //     // int instantiateNumber = 0;
    //     // tempObstacles[0] = Instantiate(ObstacleObjects[0],InstantiatePoints[0]);
    //     // instantiateNumber++;
    //     // if (instantiateNumber == 1)
    //     // {
    //     //     //
    //     //     startInstantiateObstacles = true;
    //     // }
    // }
}