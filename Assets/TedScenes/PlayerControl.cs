using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] public GameObject  camera;

        private float xRotation = 0f;
        private float yRotation = 0f;

        public ActionMap   actions;
        public Vector2 moveInput;
        public float speed;
         float sensitivity = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        actions = new ActionMap();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveInput == Vector2.zero)
            return;
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(moveDirection * speed * Time.deltaTime);

    }
    public void CameraMove(InputAction.CallbackContext context)
    {
        Vector2 cameraMove = context.ReadValue<Vector2>();

        yRotation += cameraMove.x * sensitivity /2;
        xRotation -= cameraMove.y * sensitivity / 2; 

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(0, yRotation, 0f);
        camera.transform.localRotation = Quaternion.Euler(xRotation,0, 0f);

    }
    public void ForwardMovement(InputAction.CallbackContext context)
    {
        moveInput.y = 1;
    }
    public void BackwardMovement(InputAction.CallbackContext context)
    {
        moveInput.y = -1;
    }
    public void LeftMovement(InputAction.CallbackContext context)
    {
        moveInput.x = -1;
    }
    public void RightMovement(InputAction.CallbackContext context)
    {
        moveInput.x = 1;
    }

    public void CancelForwardMovement(InputAction.CallbackContext context)
    {
        if (actions.Player.MoveBackward.IsPressed())
            moveInput.y = -1;
        else
            moveInput.y = 0;
    }
    public void CancelBackwardMovement(InputAction.CallbackContext context)
    {
        if (actions.Player.MoveForward.IsPressed())
            moveInput.y = 1;
        else
            moveInput.y = 0;
    }
    public void CancelLeftMovement(InputAction.CallbackContext context)
    {
        if (actions.Player.MoveToRight.IsPressed())
            moveInput.x = 1;
        else
            moveInput.x = 0;
    }
    public void CancelRightMovement(InputAction.CallbackContext context)
    {
        if (actions.Player.MoveToLeft.IsPressed())
            moveInput.x = -1;
        else
            moveInput.x = 0;
    }

    private void OnEnable()
    {
        actions.Player.Enable();

        actions.Player.MoveForward.performed  += ForwardMovement;
        actions.Player.MoveForward.canceled += CancelForwardMovement;

        actions.Player.MoveBackward.performed += BackwardMovement;
        actions.Player.MoveBackward.canceled += CancelBackwardMovement;

        actions.Player.MoveToLeft.performed += LeftMovement;
        actions.Player.MoveToLeft.canceled += CancelLeftMovement;

        actions.Player.MoveToRight.performed += RightMovement;
        actions.Player.MoveToRight.canceled += CancelRightMovement;

        actions.Player.CameraMovement.performed += CameraMove;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        actions.Player.MoveForward.performed -= ForwardMovement;
        actions.Player.MoveForward.canceled -= CancelForwardMovement;

        actions.Player.MoveBackward.performed -= BackwardMovement;
        actions.Player.MoveBackward.canceled -= CancelBackwardMovement;

        actions.Player.MoveToLeft.performed -= LeftMovement;
        actions.Player.MoveToLeft.canceled -= CancelLeftMovement;

        actions.Player.MoveToRight.performed -= RightMovement;
        actions.Player.MoveToRight.canceled -= CancelRightMovement;

        actions.Player.CameraMovement.performed -= CameraMove;
    }
}
