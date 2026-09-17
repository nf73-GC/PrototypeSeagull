using Unity.VisualScripting;
using UnityEngine;

public class CaptureFishScrit : MonoBehaviour
{
   public bool fishInMouth = false;
   public GameObject fishBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!fishInMouth )
        {
            fishBody.gameObject.SetActive(false);
            
        }
        if (fishBody == null)
            return;
        else
        {
            fishInMouth = true;
            fishBody.transform.position = transform.position;
            fishBody.transform.rotation = transform.rotation;
        }
    }

    public bool HasFish()
        { return fishInMouth; }
   
    public void SetFishToAnchor(GameObject Body)
    {
        fishBody = Body;

    }
}
