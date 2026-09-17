using UnityEngine;
using UnityEngine.InputSystem;

public class StockFishScript : MonoBehaviour
{
    ActionMap actions;
    private GameObject player;
    [SerializeField] public GameObject Canvas;
    [SerializeField] public Transform camTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        actions = new ActionMap();
    }

    public void SetStockBody(InputAction.CallbackContext context)
    {
        if (player == null)
            return;
        else
        {
            player.GetComponentInChildren<CaptureFishScrit>().fishInMouth = false;
           
        }

    }
    private void OnEnable()
    {
        actions.Enable();
        actions.Player.Fish.performed += SetStockBody;
    }
    private void OnDisable()
    {
        actions.Player.Fish.performed -= SetStockBody;
    }
        // Update is called once per frame
        void Update()
    {
        
    }
     private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CaptureFishScrit cfs = other.gameObject.GetComponentInChildren<CaptureFishScrit>();

            if (!cfs.HasFish())
                return;

            player = cfs.gameObject;
            Canvas.SetActive(true);
            transform.LookAt(transform.position + camTransform.transform.rotation * Vector3.forward,
                             camTransform.transform.rotation * Vector3.up);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        player = null;
        Canvas.SetActive(false);
    }
}
