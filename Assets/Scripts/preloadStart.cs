using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class preloadStart : MonoBehaviour
{
    public float start_time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start_time <= 0)
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        start_time -= Time.deltaTime;
    }
}
