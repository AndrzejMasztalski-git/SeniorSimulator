using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    //Random Walking NPC 3D By René Pol 26-11-2022//
    //Set duration of walking//
    public float WalkingTime;
    //Set Speed of walking//
    public float Speed;
    //Is object rotating or not//
    public bool Rotating;
    //1 clockwise and 2 counter clockwise//
    public int RotateDir;
    //Set Limits to walk x and z axis//
    public float MaxX, MinX, MaxZ, MinZ;
    //When using define animator//
    Animator Anim;
    //Get the animator set walking time between 5 and 8 set rotating to false and rotate direction to 1 or 2//
    void Start()
    {
        Anim = GetComponent<Animator>();
        WalkingTime = Random.Range(2, 4);
        Rotating = false;
        RotateDir = Random.Range(1, 2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.Rotate(0, -180, 0);
        }
    }

    void Update()
    {
        if (transform.position.x > MaxX | transform.position.x < MinX | transform.position.z > MaxZ | transform.position.z
        < MinZ)
        {
            transform.Rotate(0, -180, 0);
        }
        if (Rotating == true && RotateDir == 1)
        {
            Anim.SetFloat("speedPercent", WalkingTime);
            WalkingTime -= Time.deltaTime;
            transform.Rotate(0, 15 * Speed * Time.deltaTime, 0);
            if (WalkingTime <= 0)
            {
                Rotating = false;
                WalkingTime = Random.Range(2, 4);
            }
        }
        if (Rotating == true && RotateDir == 2)
        {
            WalkingTime -= Time.deltaTime;
            transform.Rotate(0, -15 * Speed * Time.deltaTime, 0);
            Anim.SetFloat("speedPercent", WalkingTime);
            if (WalkingTime <= 0)
            {
                Rotating = false;
                WalkingTime = Random.Range(2, 4);
            }
        }
        if (Rotating == false)
        {
            Anim.SetFloat("speedPercent", WalkingTime);
            WalkingTime -= Time.deltaTime;
            transform.Translate(Vector3.back * Speed * Time.deltaTime);
            if (WalkingTime <= 0)
            {
                RotateDir = Random.Range(1, 2);
                Rotating = true;
                WalkingTime = Random.Range(2, 4);
            }
        }
    }
}
