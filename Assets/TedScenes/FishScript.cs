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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CaptureFishScrit cfs = other.gameObject.GetComponent<CaptureFishScrit>();

            if (!cfs.HasFish())
                return;
            else
            {
                Shadow.SetActive(false);
            }
        }
    }
}
