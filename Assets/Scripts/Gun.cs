using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float offset;
    public GameObject ammo;
    public Transform shotDir;
    private float timeShot;
    public float ReloudTime;
    private bool facingRite = true;
    public int AmmoCol = 10;
    public int ammo_mag = 30;
    public int mag_size = 30;
    private int ammo_InMag = 0;
    private int All =0;
    private int ammo_InMagS;


    void Start()
    {
    }
    void Update()
    {
        All = ammo_InMag + AmmoCol;
        ammo_InMagS = ammo_InMag;
        if (Input.GetKeyDown(KeyCode.R) && AmmoCol>0)
        {
            if(All/mag_size>= 1)
                ammo_InMag = mag_size;
                AmmoCol = AmmoCol - ammo_InMag+ammo_InMagS;
            if(All/mag_size<1)
            {
                ammo_InMag = All;
                AmmoCol -= ammo_InMag;
                if(AmmoCol<0)
                {
                    AmmoCol = 0;
                }
            }
        }
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ%180 +offset);
        if (facingRite == true && difference.x < 0)
        {
            facingRite = !facingRite;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            Scaler.y *= -1;
            transform.localScale = Scaler;
        }
        else if (facingRite == false && difference.x > 0)
        {
            facingRite = !facingRite;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            Scaler.y *= -1;
            transform.localScale = Scaler;
        }
        if (timeShot <= 0)
        {
            if (Input.GetMouseButtonDown(0) && ammo_InMag>0)
            {
                Instantiate(ammo, shotDir.position, transform.rotation);
                timeShot = ReloudTime;
                ammo_InMag--;
                Debug.Log("саны пидор");
            }
        }
        else
        {
            timeShot -= Time.deltaTime;
        }
    }
    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 30), ammo_InMag + "/" + AmmoCol);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ammo_mag")
        {
            AmmoCol = ammo_mag+ AmmoCol;
            Destroy(other.gameObject);
        }
    }
}