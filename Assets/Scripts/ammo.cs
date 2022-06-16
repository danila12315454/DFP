using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo : MonoBehaviour
{
    public float speed;
    public float destroyTime;
    public int Damage=2;
    void Start()
    {
        Invoke("DestroyAmmo", destroyTime);
    }

    
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    void DestroyAmmo()
    {
      Destroy(gameObject);
    }
    private  void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            Destroy(collision.gameObject);
        }
        Animi animi = collision.GetComponent<Animi>();
            if(animi != null)
        {
            animi.TakeDamage(Damage);
        }
        Destroy(gameObject);
    }
}
