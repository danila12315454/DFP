using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private AudioSource AudioS;
    private float time = 0;
    public float trekTime;
    void Start()
    {
        AudioS = GetComponent<AudioSource>();
        AudioS.Play();
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        if(time <=-trekTime)
        {
          AudioS.Play();
            time = 0;
        }else
        {
            time-= Time.deltaTime;
        }
        Debug.Log(time);    
    }
}
