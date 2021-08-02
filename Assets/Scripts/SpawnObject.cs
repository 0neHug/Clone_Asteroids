using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public Vector2 spawnPoint;
    public float coolDownSpawnObject = 2f;
    public float cameraHeight = Screen.height;
    public float cameraWidth = Screen.width;
    public GameObject ObjectPrefab;
    public Transform Hero;



    void Start()
    {
        StartCoroutine(NewObject());

    }
    void NewSpawnObject()
    {
        StartCoroutine(NewObject());
    }
    private IEnumerator NewObject()
    {
            spawnPoint = new Vector2(Random.Range(cameraWidth, cameraWidth - 1) * Random.Range(-1, 2), Random.Range(cameraHeight, cameraHeight - 1) * Random.Range(-1, 2));
            yield return new WaitForSeconds(coolDownSpawnObject);
            if (spawnPoint != new Vector2(0f, 0f))
            Instantiate(ObjectPrefab, spawnPoint, ObjectPrefab.transform.rotation);

            NewSpawnObject();
        
    }
}
