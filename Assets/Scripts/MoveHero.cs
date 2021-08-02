using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHero : MonoBehaviour
{
    [SerializeField]
    [Range(0.01f, 0.1f)]
    public float impulseToHero = 0.0001f;

    [SerializeField]
    [Range(0, 10)]
    public float speedRotation = 2.0f;

    [SerializeField]
    [Range(0, 10)]
    public float dragEnvironment = 2.0f;

    private Quaternion horizontalInput;
    private float verticalInput;

    Vector3 directionVectorHero;

    float leftConstraint = Screen.width;
    float rightConstraint = Screen.width;
    float bottomConstraint = Screen.height;
    float topConstraint = Screen.height;
    float buffer = 1f;
    Camera cam;
    float distanceZ;

    public bool pressQ = false;
    public bool pressE = false;

    void Start()
    {
        cam = Camera.main;
        distanceZ = Mathf.Abs(cam.transform.position.z + transform.position.z);

        leftConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        rightConstraint = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;
        bottomConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y;
        topConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, distanceZ)).y;

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) == true)
        {
            pressQ = true;
            pressE = false;
        }

        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            pressE = true;
            pressQ = false;

        }
    }
private void FixedUpdate()
    {
        

        verticalInput = Input.GetAxis("Vertical");
        if (verticalInput <= 0)
        {
            verticalInput = 0;
        }

        horizontalInput = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * -speedRotation, new Vector3(0, 0, 1f));

        if (Input.GetKey(KeyCode.W) == true)
        {
            directionVectorHero += transform.up * dragEnvironment * impulseToHero * verticalInput;
        }

        transform.position = Vector3.Lerp(transform.position, directionVectorHero , Time.deltaTime);
        transform.rotation *= horizontalInput;
        
        // no borders with save impulse hero
        if (transform.position.x < leftConstraint - buffer)
        {
            directionVectorHero -= transform.position;
            transform.position = new Vector3(rightConstraint + buffer, transform.position.y, transform.position.z);
            directionVectorHero += transform.position;
        }
        if (transform.position.x > rightConstraint + buffer)
        {
            directionVectorHero -= transform.position;
            transform.position = new Vector3(leftConstraint - buffer, transform.position.y, transform.position.z);
            directionVectorHero += transform.position;
        }
        if (transform.position.y < bottomConstraint - buffer)
        {
            directionVectorHero -= transform.position;
            transform.position = new Vector3(transform.position.x, topConstraint + buffer, transform.position.z);
            directionVectorHero += transform.position;
        }
        if (transform.position.y > topConstraint + buffer)
        {
            directionVectorHero -= transform.position;
            transform.position = new Vector3(transform.position.x, bottomConstraint - buffer, transform.position.z);
            directionVectorHero += transform.position;
        }

    }

   
}
