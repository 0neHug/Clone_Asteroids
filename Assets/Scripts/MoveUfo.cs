using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUfo : MonoBehaviour
{
    public float speedObject = 0.4f;
    public float colisionDestance;

    private GameObject HeroPos;
    void Start()
    {
        HeroPos = GameObject.Find("Hero");
    }
    void Update()
    {
        
    }
    void FixedUpdate()
    {
         transform.position = Vector3.MoveTowards(transform.position, HeroPos.transform.position, Time.deltaTime * speedObject);
        
    }
}
