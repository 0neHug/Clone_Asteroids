using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollisionRegister : MonoBehaviour
{
    public BackgroundUI onBackground;

    public MoveMeteorite[] _meteorites;
    public MoveUfo[] _ufo;

    public MoveBullet[] _bullets;
    public GameObject _hero;


    public GameObject meteoriteMediumPrefab;

    public Text _text;
    
    public int score = 0;

    void Start()
    {
        score = 0;
        Time.timeScale = 1;
    }


    void Update()
    {
        _meteorites = GameObject.FindObjectsOfType<MoveMeteorite>();
        _ufo = GameObject.FindObjectsOfType<MoveUfo>();
        _bullets = GameObject.FindObjectsOfType<MoveBullet>();


        for (int i = 0; i < _meteorites.Length; i++)
        {
            for (int j = 0; j < _bullets.Length; j++)
            {
                if ((_meteorites[i].transform.position - _bullets[j].transform.position).magnitude < _meteorites[i].colisionDestance)
                {
                    Destroy(_bullets[j].gameObject);
                    Destroy(_meteorites[i].gameObject);
                    SetScore(50);

                    if (_meteorites[i].colisionDestance > 0.6f && _bullets[j].speedObject != 0)
                    {
                        Vector3 RandomCircleSpawn = Random.insideUnitCircle;
                        Instantiate(meteoriteMediumPrefab, _meteorites[i].gameObject.transform.position, meteoriteMediumPrefab.transform.rotation);
                        Instantiate(meteoriteMediumPrefab, _meteorites[i].gameObject.transform.position, meteoriteMediumPrefab.transform.rotation);
                        Instantiate(meteoriteMediumPrefab, _meteorites[i].gameObject.transform.position, meteoriteMediumPrefab.transform.rotation);
                        Instantiate(meteoriteMediumPrefab, _meteorites[i].gameObject.transform.position, meteoriteMediumPrefab.transform.rotation);
                        SetScore(100);
                    }
                }
                
            }
            if ((_meteorites[i].transform.position - _hero.transform.position).magnitude < _meteorites[i].colisionDestance)
            {
                
                onBackground.Setup();
                Time.timeScale = 0;
            }
        }
        
        for (int i = 0; i < _ufo.Length; i++)
        {
            for (int j = 0; j < _bullets.Length; j++)
            {
                if ((_ufo[i].transform.position - _bullets[j].transform.position).magnitude < _ufo[i].colisionDestance)
                {
                    Destroy(_bullets[j].gameObject);
                    Destroy(_ufo[i].gameObject);
                    SetScore(200);
                }
                
            }
            if ((_ufo[i].transform.position - _hero.transform.position).magnitude < _ufo[i].colisionDestance)
            {
                onBackground.Setup();
                Time.timeScale = 0;
            }
        }
    }

    public void SetScore(int plusScore)
    {
        score += plusScore;
        _text.text = "Score:"+score.ToString();
    }
}

