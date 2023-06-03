using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4;
    private PlayerInputsManager input;
    private CharacterController controller;
    private Animator animator;

    [SerializeField] GameObject mainCam;
    [SerializeField] Transform cameraFollowTarget;
    float xRotation;
    float yRotation;

    [Range(0f, 10f)] public float mouseSensitivity = 1f;

    // Start is called before the first frame update
    void Start()
    {
       
        input = GetComponent<PlayerInputsManager>();
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 0;
        Vector3 inputDir = new Vector3(input.move.x, 0, input.move.y);
        float targetRotation = 0;
       if(input.move != Vector2.zero)
        {
            speed = moveSpeed;
            targetRotation = Quaternion.LookRotation(inputDir).eulerAngles.y + mainCam.transform.rotation.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, targetRotation, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 20 * Time.deltaTime);
        }
        animator.SetFloat("speed", input.move.magnitude);
        Vector3 targetDirection = Quaternion.Euler(0,targetRotation,0) * Vector3.forward;
        controller.Move(targetDirection * speed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        CameraRotation();
    }

    void CameraRotation()
    {
        xRotation += input.look.y/4;
        yRotation += input.look.x/4;
        xRotation = Mathf.Clamp(xRotation, -70, 30);

        Quaternion rotation = Quaternion.Euler(-xRotation, yRotation, 0);
        cameraFollowTarget.rotation = rotation;
    }
}
