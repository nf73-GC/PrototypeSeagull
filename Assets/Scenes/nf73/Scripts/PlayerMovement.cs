using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using static UnityEditor.SceneView;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jump_force = 500.0f;

    [SerializeField] public GameObject cam;
    private float xRotation = 0f;
    private float yRotation = 0f;
    float sensitivity = 0.5f;

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
    public void CameraMove(InputAction.CallbackContext context)
    {
        Vector2 cameraMove = context.ReadValue<Vector2>();

        yRotation += cameraMove.x * sensitivity / 2;
        xRotation -= cameraMove.y * sensitivity / 2;

        const float minRotX = -90.0f;
        const float maxRotX = 90.0f;
        xRotation = Mathf.Clamp(xRotation, minRotX, maxRotX);

        transform.localRotation = Quaternion.Euler(0, yRotation, 0f);

        const float minDist = 2.0f;
        const float maxDist = 15.0f;

        float ratio = (xRotation - minRotX) / (maxRotX - minRotX);
        float distFromCam = minDist + (maxDist - minDist) * ratio;
        Debug.Log(distFromCam);
        Quaternion camRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        Vector3 camPosition = transform.position +transform.forward * 5.0f - camRotation * Vector3.forward * distFromCam;

        cam.transform.position = camPosition;
        cam.transform.rotation = camRotation;
    }

    private void OnEnable()
    {
        actions.Player.Enable();

        actions.Player.Jump.performed += Jump;

        actions.Player.CameraMovement.performed += CameraMove;
        Cursor.lockState = CursorLockMode.Locked;
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
            //transform.Rotate(new Vector3(0, 20.0f * moveVal.x * Time.deltaTime, 0));

            Vector3 t = (transform.forward * moveVal.z + transform.right * moveVal.x) * Time.deltaTime;
            transform.position += t;
        }
    }
    private void FixedUpdate()
    {

    }
}
