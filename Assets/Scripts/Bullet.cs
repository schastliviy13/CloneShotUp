using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _transform;
    private float speed=15;
    private Vector3 direction;
    private float moveDistance;
    private float timeLife=2;
    private float curentTimeLife = 0;

    public void Awake()
    {
        _transform = GetComponent<Transform>();
    }
    public void Start()
    {
        direction = _transform.rotation.eulerAngles;
        moveDistance = speed * Time.deltaTime;
    }
    public void Update()
    {
        if (curentTimeLife<timeLife)
        {            
            _transform.position += -direction.normalized * moveDistance;
            curentTimeLife += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
