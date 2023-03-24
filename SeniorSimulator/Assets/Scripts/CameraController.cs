using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    
    public GameObject ballObject;
    public Vector3 distance;
    public float lookUp;
    public float lerpAmount;

    
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 100;
    }

    // Update is called once per frame
    void Update()
    {
        }


    private void LateUpdate()
    {
        transform.LookAt(ballObject.transform.position);
        transform.position = Vector3.Lerp(transform.position, ballObject.transform.position + distance, lerpAmount * Time.deltaTime);
        transform.Rotate(-lookUp, 0, 0);
    }
}
