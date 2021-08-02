using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OurObject : MonoBehaviour
{
    MeshRenderer _meshRenderer;
    MeshFilter _meshFilter;

    SpriteRenderer _spriteRenderer;
    public Sprite _ourSprite;
    public Mesh _ourMesh;


    public MoveHero Hero;

    public OurObject[] _ourObjects;
    void Start()
    {

        Hero = GameObject.FindObjectOfType<MoveHero>();
        if (Hero.pressQ == true) //2D REbuild
        {
            _meshRenderer = (GetComponent<MeshRenderer>());
            Destroy(_meshRenderer);
            _meshFilter = (GetComponent<MeshFilter>());
            Destroy(_meshFilter);
            _spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
            _spriteRenderer.sprite = _ourSprite;
        }

        if (Hero.pressE == true)
        {
            _spriteRenderer = (GetComponent<SpriteRenderer>());
            Destroy(_spriteRenderer);
            _meshRenderer = gameObject.AddComponent<MeshRenderer>();
            _meshFilter = gameObject.AddComponent<MeshFilter>();
            _meshFilter.mesh = _ourMesh;
        }
    }

    void Update()
    {
        if (Hero.pressQ == true) //3D REbuild
        {
            _meshRenderer = (GetComponent<MeshRenderer>());
            Destroy(_meshRenderer);
            _meshFilter = (GetComponent<MeshFilter>());
            Destroy(_meshFilter);
            _spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
            _spriteRenderer.sprite = _ourSprite;
        }

        if (Hero.pressE == true)
        {
            _spriteRenderer = (GetComponent<SpriteRenderer>());
            Destroy(_spriteRenderer);
            _meshRenderer = gameObject.AddComponent<MeshRenderer>();
            _meshFilter = gameObject.AddComponent<MeshFilter>();
            _meshFilter.mesh = _ourMesh;
        }
    }
}
