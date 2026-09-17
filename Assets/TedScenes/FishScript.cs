using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public GameObject Shadow;
    [SerializeField] public GameObject Body;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CaptureFishScrit cfs = collision.gameObject.GetComponent<CaptureFishScrit>();

            if (!cfs.HasFish())
                return;
            else
            {
                Shadow.SetActive(false);
            }
        }
    }
}
