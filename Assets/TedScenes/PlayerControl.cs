using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] public Camera  cam;
        public ActionMap   actions;
        public Vector2 moveInput;
        public float speed;
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
        transform.Translate(moveInput.x,0,moveInput.y);

    }

    public void ForwardMovement(InputAction.CallbackContext context)
    {
        moveInput.y = Time.deltaTime * speed;
    }
    public void BackwardMovement(InputAction.CallbackContext context)
    {
        moveInput.y = - Time.deltaTime * speed;
    }
    public void LeftMovement(InputAction.CallbackContext context)
    {
        moveInput.x = Time.deltaTime * speed;
    }
    public void RightMovement(InputAction.CallbackContext context)
    {
        moveInput.x = - Time.deltaTime * speed;
    }

    public void CancelForwardMovement(InputAction.CallbackContext context)
    {
        if (actions.Player.MoveBackward.IsPressed())
            return;
        moveInput.y = 0;
    }
    public void CancelBackwardMovement(InputAction.CallbackContext context)
    {
        if (actions.Player.MoveForward.IsPressed())
            return;
        moveInput.y = 0;
    }
    public void CancelLeftMovement(InputAction.CallbackContext context)
    {
        if (actions.Player.MoveToRight.IsPressed())
            return;
        moveInput.x = 0;
    }
    public void CancelRightMovement(InputAction.CallbackContext context)
    {
        if (actions.Player.MoveToLeft.IsPressed())
            return;
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
    }
}
