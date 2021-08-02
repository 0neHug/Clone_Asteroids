using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHero : MonoBehaviour
{

    [SerializeField]
    [Range(0.1f, 5.0f)]
    public float coolDownSpawnBullet;
    [SerializeField]
    [Range(0.1f, 5.0f)]
    public float coolDownSpawnLaser;

    [SerializeField]
    [Range(1.0f, 5.0f)]
    public float lasetAttackTime = 3.0f;


    [SerializeField]
    [Range(1.0f, 20.0f)]
    public float lasetReloadTime = 10.0f;

    [SerializeField]
    [Range(0, 10)]
    public float trackerToHeroDistance = 4.48f;

    public GameObject BulletPrefab;
    public GameObject LaserPrefab;

    public GameObject laserTracker;

    bool canLaserAttack;
    bool canLaserReload = false;
    void Start()
    {

        laserTracker.SetActive(false);
        StartCoroutine(NewBullet());
    }

    private IEnumerator NewBullet()
    {
        if (Input.GetKey(KeyCode.Space) == true)
        {
            Instantiate(BulletPrefab, transform.position + transform.up / 5, transform.rotation);
            yield return new WaitForSeconds(coolDownSpawnBullet);
        }
        if (Input.GetKeyDown(KeyCode.X) == true && canLaserReload == false)
        {
            canLaserAttack = true;
            StartCoroutine(LaserAttack());
        }
            if (canLaserAttack == true)
            {
            
                laserTracker.transform.position = transform.up * trackerToHeroDistance + transform.position;
                laserTracker.transform.rotation = transform.rotation;
                laserTracker.SetActive(true);
                for (int i = 0; i <= 25; i++)
                {
                    Instantiate(LaserPrefab, transform.position + transform.up * i/3, transform.rotation);
                    yield return new WaitForSeconds(coolDownSpawnLaser);
                }
            
            }
            else
            {
                laserTracker.SetActive(false);
            }

        yield return null;
        NewSpawnBullet();
    }

    void NewSpawnBullet()
    {
        StartCoroutine(NewBullet());
    }


    private IEnumerator LaserAttack()
    {
        
        yield return new WaitForSeconds(lasetAttackTime);
        StartCoroutine(LaserReload());

    }

    private IEnumerator LaserReload()
    {
        canLaserAttack = false;
        canLaserReload = true;
         yield return new WaitForSeconds(lasetReloadTime);
        canLaserReload = false;
    }


}
