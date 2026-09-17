using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jump_force = 500.0f;

    private Rigidbody rb;


    public ActionMap actions;

    private void Awake()
    {
        actions = new ActionMap();
    }
    
    private void Jump(InputAction.CallbackContext context)
    {
        rb.AddForce(new Vector3(0, jump_force, 0));
    }
    private void OnEnable()
    {
        actions.Player.Enable();

        actions.Player.Jump.performed += Jump;
    }

    private void OnDisable()
    {
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
