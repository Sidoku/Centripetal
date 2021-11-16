using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrapplingGun : MonoBehaviour
{

    InputMaster controls;

    [Header("Scripts Ref:")]
    public GrapplingRope grappleRope;

    public bool isGrappled; //check if player really grapple the point, if is grappled, activate the grapple point animation
    [Header("Layers Settings:")]
    [SerializeField] private bool grappleToAll = false;
    [SerializeField] private int grappableLayerNumber = 9;

    [Header("Main Camera:")]
    public Camera m_camera;

    [Header("Transform Ref:")]
    public Transform gunHolder;
    public Transform gunPivot;
    public Transform firePoint;
    public Vector2 DestinationPoint;

    [Header("Physics Ref:")]
    public SpringJoint2D m_springJoint2D;
    public Rigidbody2D m_rigidbody;

    [Header("Rotation:")]
    [SerializeField] private bool rotateOverTime = true;
    [Range(0, 60)] [SerializeField] private float rotationSpeed = 4;

    [Header("Distance:")]
    [SerializeField] private bool hasMaxDistance = false;
    [SerializeField] private float maxDistnace = 20;

    private enum LaunchType
    {
        Transform_Launch,
        Physics_Launch
    }

    [Header("Launching:")]
    [SerializeField] private bool launchToPoint = true;
    [SerializeField] private LaunchType launchType = LaunchType.Physics_Launch;
    [SerializeField] private float launchSpeed = 1;

    [Header("No Launch To Point")]
    [SerializeField] private bool autoConfigureDistance = false;
    [SerializeField] private float targetDistance = 3;
    [SerializeField] private float targetFrequncy = 1;

    [HideInInspector] public Vector2 grapplePoint;
    [HideInInspector] public Vector2 grappleDistanceVector;

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    private void Awake()
    {
        controls = new InputMaster();
   
    }

    private void Start()
    {
        grappleRope.enabled = false;
        m_springJoint2D.enabled = false;
    }

    private void Update()
    {

        //Check for isGrappled to be activated when player pulls the trigger for grappling

        controls.Player.Hook.performed += ctx => isGrappled = true;
        controls.Player.Hook.canceled += ctx => isGrappled = false;

        if (Input.GetKey(KeyCode.Mouse0) || isGrappled == true)
        {
            SetGrapplePoint();
        }
        else if (Input.GetKey(KeyCode.Mouse0) || isGrappled == true)
        {
            if (grappleRope.enabled)
            {
                RotateGun(grapplePoint, false);
            }
            else
            {
                Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
                RotateGun(mousePos, true);
            }

            if (launchToPoint && grappleRope.isGrappling)
            {
                if (launchType == LaunchType.Transform_Launch)
                {
                    Vector2 firePointDistnace = firePoint.position - gunHolder.localPosition;
                    Vector2 targetPos = grapplePoint - firePointDistnace;
                    gunHolder.position = Vector2.Lerp(gunHolder.position, targetPos, Time.deltaTime * launchSpeed);
                }
            }
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0) || isGrappled == false)
        {
            grappleRope.enabled = false;
            m_springJoint2D.enabled = false;
<<<<<<< HEAD
<<<<<<< HEAD
            // m_rigidbody.gravityScale = 1;
=======
            //m_rigidbody.gravityScale = 1;
>>>>>>> Matt
=======
            //m_rigidbody.gravityScale = 1;
>>>>>>> Matt
        }
        else
        {
            Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
            RotateGun(mousePos, true);
        }
    }

    void RotateGun(Vector3 lookPoint, bool allowRotationOverTime)
    {
        Vector3 distanceVector = lookPoint - gunPivot.position;

        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        if (rotateOverTime && allowRotationOverTime)
        {
            gunPivot.rotation = Quaternion.Lerp(gunPivot.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * rotationSpeed);
        }
        else
        {
            gunPivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    // void SetGrapplePoint()
    // {
    //     Vector2 distanceVector = m_camera.ScreenToWorldPoint(Input.mousePosition) - gunPivot.position;
    //     if (Physics2D.Raycast(firePoint.position, distanceVector.normalized))
    //     {
    //         RaycastHit2D _hit = Physics2D.Raycast(firePoint.position, distanceVector.normalized);
    //         if (_hit.transform.gameObject.layer == grappableLayerNumber || grappleToAll)
    //         {
    //             
    //             if (Vector2.Distance(_hit.point, firePoint.position) <= maxDistnace || !hasMaxDistance)
    //             {
    //                 // grapplePoint = _hit.point;
    //                 grapplePoint = DestinationPoint;
    //                 Debug.Log(grapplePoint);
    //                 grappleDistanceVector = grapplePoint - (Vector2)gunPivot.position;
    //                 if (grapplePoint.x == 0f || grapplePoint.y == 0f)
    //                 {
    //                     return;
    //                 }
    //                 grappleRope.enabled = true;
    //             }
    //         }
    //     }
    // }
    
    void SetGrapplePoint()
    {
        foreach (var points in GameController.Instance.grapplePoints)
        {
            if (Vector2.Distance(transform.position,points.position) < 10f)
            {
                // points.gameObject.GetComponent<Animator>().SetTrigger("isGrappled");
                grapplePoint = points.position;
                //             Debug.Log(grapplePoint);
                grappleDistanceVector = grapplePoint - (Vector2)gunPivot.position;
                if (grapplePoint.x == 0f || grapplePoint.y == 0f)
                {
                    return;
                }
                grappleRope.enabled = true;
              //  isGrappled = true;
            }
        }
        // Vector2 distanceVector = m_camera.ScreenToWorldPoint(Input.mousePosition) - gunPivot.position;
        // if (Physics2D.Raycast(firePoint.position, distanceVector.normalized))
        // {
        //     RaycastHit2D _hit = Physics2D.Raycast(firePoint.position, distanceVector.normalized);
        //     if (_hit.transform.gameObject.layer == grappableLayerNumber || grappleToAll)
        //     {
        //         
        //         if (Vector2.Distance(_hit.point, firePoint.position) <= maxDistnace || !hasMaxDistance)
        //         {
        //             // grapplePoint = _hit.point;
        //             grapplePoint = DestinationPoint;
        //             Debug.Log(grapplePoint);
        //             grappleDistanceVector = grapplePoint - (Vector2)gunPivot.position;
        //             if (grapplePoint.x == 0f || grapplePoint.y == 0f)
        //             {
        //                 return;
        //             }
        //             grappleRope.enabled = true;
        //         }
        //     }
        // }
    }
    
    

    public void Grapple()
    {
        m_springJoint2D.autoConfigureDistance = false;
        if (!launchToPoint && !autoConfigureDistance)
        {
            m_springJoint2D.distance = targetDistance;
            m_springJoint2D.frequency = targetFrequncy;
        }
        if (!launchToPoint)
        {
            if (autoConfigureDistance)
            {
                m_springJoint2D.autoConfigureDistance = true;
                m_springJoint2D.frequency = 0;
            }

            m_springJoint2D.connectedAnchor = grapplePoint;
            m_springJoint2D.enabled = true;
        }
        else
        {
            switch (launchType)
            {
                case LaunchType.Physics_Launch:
                    m_springJoint2D.connectedAnchor = grapplePoint;

                    Vector2 distanceVector = firePoint.position - gunHolder.position;

                    m_springJoint2D.distance = distanceVector.magnitude;
                    m_springJoint2D.frequency = launchSpeed;
                    m_springJoint2D.enabled = true;
                    break;
                case LaunchType.Transform_Launch:
                    m_rigidbody.gravityScale = 0;
                    m_rigidbody.velocity = Vector2.zero;
                    break;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (firePoint != null && hasMaxDistance)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(firePoint.position, maxDistnace);
        }
    }

}