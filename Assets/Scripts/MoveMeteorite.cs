using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMeteorite : MonoBehaviour
{
    public float speedObject = 0.3f;
    public Vector3 directionVector;
    public float colisionDestance;
    public GameObject meteoriteMediumPrefab;
    void Start()
    {  
        directionVector = Random.insideUnitCircle; 
        
    }

    private void Update()
    {       
        //borders to destroy
        if (Mathf.Abs(transform.position.x) > 15 || Mathf.Abs(transform.position.y) > 11) Destroy(gameObject);  
    }
    void FixedUpdate()
    { 
        transform.position = Vector3.Lerp(transform.position, transform.position + directionVector, Time.deltaTime * speedObject);
    }
}
