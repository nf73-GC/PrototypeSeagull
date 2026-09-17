using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 100.0f;

    private Rigidbody rb;


    public ActionMap actions;

    private void MoveInDir(InputAction.CallbackContext context)
    {
        Vector3 t = context.ReadValue<Vector3>();
        rb.AddForce(t);
    }

    private void Awake()
    {
        actions = new ActionMap();
    }

    private void OnEnable()
    {
        actions.Player.Enable();

        actions.Player.MoveForward.performed += MoveInDir;
    }

    private void OnDisable()
    {
        actions.Player.MoveForward.performed -= MoveInDir;

        actions.Player.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVal = actions.Player.MoveValue.ReadValue<Vector3>();

        moveVal.Normalize();
        moveVal *= speed;

        if(moveVal != Vector3.zero)
        {
            transform.Rotate(new Vector3(0, 10.0f * moveVal.x * Time.deltaTime, 0));

            Vector3 t = transform.forward * moveVal.z * Time.deltaTime;
            Debug.Log(t);

            transform.position += t;
        }
    }
    private void FixedUpdate()
    {

    }
}
