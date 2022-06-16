using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformMoovment : MonoBehaviour
{
    public float speed = 0.1f;
    private float time;
    public float Seed = 1;
    void Start()
    {
     time=Seed;
    }
    
    void Update()
    {
        if(time%2>=1)
        {
         transform.Translate(Vector2.up * speed * Time.deltaTime);
            time += Time.deltaTime;
        }
        else if(time % 2 <= 1)
        {
         transform.Translate(Vector2.down * speed * Time.deltaTime);
            time += Time.deltaTime;
        }
        else if(time<=0)
        {
            time = 2;
        }
    }
}