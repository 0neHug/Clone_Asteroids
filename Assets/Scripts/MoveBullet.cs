using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public float speedObject = 0.3f;
    public float lifeTimeBullet = 3f;
    public Vector3 directionVector;

    float leftConstraint = Screen.width;
    float rightConstraint = Screen.width;
    float bottomConstraint = Screen.height;
    float topConstraint = Screen.height;
    float buffer = 1.0f;
    Camera cam;
    float distanceZ;


    void Start()
    {
            StartCoroutine(lifeBullet());

            directionVector = this.transform.up;
            
            cam = Camera.main;
            distanceZ = Mathf.Abs(cam.transform.position.z + transform.position.z);

            leftConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
            rightConstraint = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;
            bottomConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y;
            topConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, distanceZ)).y;
    }
    private IEnumerator lifeBullet()
    {
        yield return new WaitForSeconds(lifeTimeBullet);
        Destroy(gameObject);
    }
    
    void FixedUpdate()
    {

        transform.position = Vector3.Lerp(transform.position, transform.position + directionVector, Time.deltaTime * speedObject);

            // no border position
            if (transform.position.x < leftConstraint - buffer)
            {
                transform.position = new Vector3(rightConstraint + buffer, transform.position.y, transform.position.z);
            }
            if (transform.position.x > rightConstraint + buffer)
            {
                transform.position = new Vector3(leftConstraint - buffer, transform.position.y, transform.position.z);
            }
            if (transform.position.y < bottomConstraint - buffer)
            {
                transform.position = new Vector3(transform.position.x, topConstraint + buffer, transform.position.z);
            }
            if (transform.position.y > topConstraint + buffer)
            {
                transform.position = new Vector3(transform.position.x, bottomConstraint - buffer, transform.position.z);
            }
        
    }
}
