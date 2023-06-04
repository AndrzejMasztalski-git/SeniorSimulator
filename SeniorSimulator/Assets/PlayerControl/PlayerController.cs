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
    Animator animator;

    [SerializeField] GameObject mainCam;
    [SerializeField] Transform cameraFollowTarget;
    float xRotation;
    float yRotation;

    [Range(0f, 10f)] public float mouseSensitivity = 1f;


    public float walkSpeed = 2;
    public float runSpeed = 6;
    public float turnSmootTime = 0.2f;
    float turnSmoothVelocity;
    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;


    // Start is called before the first frame update
    void Start()
    {

        input = GetComponent<PlayerInputsManager>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 0;
        Vector3 inputDir = new Vector3(input.move.x, 0, input.move.y);
        float targetRotation = 0;
        if (input.move != Vector2.zero)
        {
            speed = moveSpeed;
            targetRotation = Quaternion.LookRotation(inputDir).eulerAngles.y + mainCam.transform.rotation.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, targetRotation, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 20 * Time.deltaTime);
        }
        animator.SetFloat("speedPercent", input.move.magnitude);
        Vector3 targetDirection = Quaternion.Euler(0, targetRotation, 0) * Vector3.forward;
        controller.Move(targetDirection * speed * Time.deltaTime);


        // Poruszanie siê, walk i run, smooth animacje i obrót, ale nie dziala z reszt¹, Andrzej bedziesz podtrzebny:

        //Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //Vector2 inputDir = input.normalized;

        //if (inputDir != Vector2.zero)
        //{
        //    float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
        //    transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmootTime);
        //}

        //bool running = Input.GetKey(KeyCode.LeftShift);
        //float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
        //currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);
        //transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

        //float animationSpeedPercent = ((running) ? 1 : .5f) * inputDir.magnitude;

        //animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);

    }

    private void LateUpdate()
    {
        CameraRotation();
    }

    void CameraRotation()
    {
        xRotation += input.look.y / 4;
        yRotation += input.look.x / 4;
        xRotation = Mathf.Clamp(xRotation, -70, 30);

        Quaternion rotation = Quaternion.Euler(-xRotation, yRotation, 0);
        cameraFollowTarget.rotation = rotation;
    }
}
