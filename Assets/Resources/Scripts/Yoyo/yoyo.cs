using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class yoyo : MonoBehaviour
{
    public Transform YoYo;
    public GameObject tempYoyo;
    public float maxDistance;

    public Transform middlePoint;

    public bool isClicked, isBeyondDistance = false;

    public Camera Camera;

    public float clickTime;

    private int yoyoNumber = 0;

    private Vector2 playerPoint;

    Vector3 mousePosition, targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        YoYo.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));
        YoYo.transform.position = targetPosition;
        playerPoint = transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            isClicked = true;
            if (isBeyondDistance)
            {
                ShowYoyo();
            }
            else
            {
                YoYo.gameObject.SetActive(true);
                Instantiate(YoYo, mousePosition, Quaternion.identity);
                ShowYoyo();
            }
            
        }

        if (isClicked && Input.GetMouseButtonUp(0))
        {
            isClicked = false;
        }
    }

    void ShowYoyo()
    {
        if (isClicked)
        {
            Vector3 worldPoint = Input.mousePosition;
            worldPoint.z = Mathf.Abs(Camera.transform.position.z);
            Vector3 mouseWorldPosition = Camera.ScreenToWorldPoint(worldPoint);
            mouseWorldPosition.z = 0;
            CalculateMaxYoyoPoint(mouseWorldPosition);
            // CalculateMaxYoyoPoint(targetPosition);
            // Test(tempYoyo,mouseWorldPosition);
        }

    }

    void CalculateMaxYoyoPoint(Vector2 mousePoint)
    {
        float distance = Mathf.Abs(Vector2.Distance(playerPoint, mousePoint));
        float k = (mousePoint.y - playerPoint.y) / (mousePoint.x - playerPoint.x);
        float b = playerPoint.y - k * playerPoint.x;
        List<Vector2> vec = new List<Vector2>();
        if (distance > 8)
        {
            for (float i = playerPoint.x; i < mousePoint.x; i++)
            {
                for (float j = transform.position.y; j < mousePoint.y; j++)
                {
                    Vector2 midPoint = new Vector2(i, j);
                    if (Mathf.Abs(Vector2.Distance(transform.position, midPoint)) >= 8
                        && Mathf.Abs(Vector2.Distance(transform.position, midPoint)) <= 8.1f)
                    {
                        vec.Add(midPoint);
                    }
                }
            }

            foreach (var point in vec)
            {
                Vector3 a2A1 = playerPoint - mousePoint;
                Vector3 a2B = point - mousePoint;

                Vector3 normal = Vector3.Cross(a2A1, a2B);
                Vector3 a2A1Temp = Vector3.Cross(a2A1, normal).normalized;

                var sb = Mathf.Abs(Vector3.Dot(a2B, a2A1Temp));
                if (sb < 1f)
                {
                    Instantiate(tempYoyo, point, Quaternion.identity);
                    isBeyondDistance = true;
                }

                isBeyondDistance = false;
            }

            vec.Clear();
        }
        else
        {
            Instantiateyoyo(mousePoint);
        }
    }

    bool IsInALine()
    {
        
        return true;
    }


    /// <summary>
    /// if the yoyo is in limit rope boundary, instantiate it
    /// </summary>
    /// <param name="mousePoint"></param>
    void Instantiateyoyo(Vector2 mousePoint)
    {
        Instantiate(tempYoyo, mousePoint,Quaternion.identity);
        // YoYo.gameObject.SetActive(true);
        // var newYoyo = Instantiate(YoYo, targetPosition, Quaternion.identity);
        // newYoyo.transform.position = mousePosition;
        // newYoyo.gameObject.SetActive(true);
    }

    /// <summary>
    /// when the mouse is not click longer, destroy yoyo
    /// </summary>
    void DestroyYoyo()
    {
        // tempYoyo.transform
    }
    
}
