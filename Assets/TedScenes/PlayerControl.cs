using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] public Camera  cam;
        public ActionMap   actions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        actions = GetComponent<ActionMap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Movement(InputAction.CallbackContext context)
    {

    }
    private void OnEnable()
    {
        actions.Player.MoveBackward.performed += Movement;
        actions.Player.MoveForward.performed  += Movement;
        actions.Player.MoveToLeft.performed += Movement;
        actions.Player.MoveToRight.performed += Movement;
    }
    private void OnDisable()
    {
        
    }
}
