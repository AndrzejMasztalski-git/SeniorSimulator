using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereController : MonoBehaviour
{
    [Header("Control Settings")]
    public float speed = 1f;
    public float maxAngularVelocity;
    private Rigidbody rb;
    private bool isRigidbody;
    // Start is called before the first frame update
    void Start()
    {
       
       if (isRigidbody = TryGetComponent<Rigidbody>(out rb))
        {
            
            rb.maxAngularVelocity = maxAngularVelocity;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        


    }

    private void FixedUpdate()
    {
        float Hdirection;
        float Vdirection;



        if (isRigidbody && (Hdirection = Input.GetAxis("Horizontal")) != 0)
        {
            rb.AddTorque(0, 0, -Hdirection * speed * Time.fixedDeltaTime);
        }

        if ((Vdirection = Input.GetAxis("Vertical")) != 0)
        {
            rb.AddTorque(Vdirection * speed * Time.fixedDeltaTime, 0, 0);
        }
    }
}
