using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4;
    private PlayerInputsManager input;
    CharacterController controller;
    Animator animator;

    [SerializeField] GameObject mainCam;
    [SerializeField] Transform cameraFollowTarget;
    float xRotation;
    float yRotation;

    [Range(0f, 10f)] public float mouseSensitivity = 1f;


    public float walkSpeed = 2;
    public float runSpeed = 6;
    public float turnSmootTime = 0.2f;
    public float jumpHeight = 1;

    [Range(0,1)]
    public float airControlPercent;

    float turnSmoothVelocity;
    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;

    float gravity = -12f;
    float velocityY;

    private bool isJumping;
    private bool isGrounded;
    private float originalStepOffset;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;
    [SerializeField]
    private float jumpButtonGracePeriod;
    [SerializeField]
    private float jumpSpeed;
    private bool isMouseDown;


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


        if (Input.GetKeyDown(KeyCode.T))
        {
            animator.SetBool("AttackTrigger", true);
        }
        else
        {
            animator.SetBool("AttackTrigger", false);
        }



        float speed = 0;
        Vector3 inputDir = new Vector3(input.move.x, 0, input.move.y);
        float targetRotation = 0;

        moveSpeed += Physics.gravity.y * Time.deltaTime;
        if (controller.isGrounded)
        {
            lastGroundedTime= Time.time;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpButtonPressedTime= Time.time;
            if (controller.isGrounded)
        {
            float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
            velocityY = jumpVelocity;
        }
        }
        if(Time.time - lastGroundedTime <= jumpButtonGracePeriod)
        {
            controller.stepOffset = originalStepOffset;
            moveSpeed = -0.5f;
            animator.SetBool("IsGrounded", true);
            isGrounded= true;
            animator.SetBool("IsJumping", false);
            isJumping = false;
            animator.SetBool("IsLanding", false);

            if(Time.time - jumpButtonPressedTime <=jumpButtonGracePeriod)
            {
                moveSpeed = jumpSpeed;
                animator.SetBool("IsJumping", true);
                isJumping= true;
                jumpButtonPressedTime = null;
                lastGroundedTime = null;
            }
        }
        else
        {
            controller.stepOffset = 0;
            animator.SetBool("IsGrounded", false);
            isGrounded= false;

            if((isJumping && currentSpeed < 0) || currentSpeed < -2)
            {
                animator.SetBool("IsLanding", true);
                
            }
        }

        if (input.move != Vector2.zero)
        {
            animator.SetBool("IsMoving", true);
            speed = moveSpeed;
            targetRotation = Quaternion.LookRotation(inputDir).eulerAngles.y + mainCam.transform.rotation.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, targetRotation, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 20 * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        bool running = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);
        //transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

        velocityY += Time.deltaTime * gravity;
        Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);
        currentSpeed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;
        if (controller.isGrounded)
        {
            velocityY = 0;
        }


        float animationSpeedPercent = ((running) ? currentSpeed / runSpeed : currentSpeed / walkSpeed * .5f);
        animator.SetFloat("speedPercent",animationSpeedPercent, speedSmoothTime, Time.deltaTime);
        

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
