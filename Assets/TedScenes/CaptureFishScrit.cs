using Unity.VisualScripting;
using UnityEngine;

public class CaptureFishScrit : MonoBehaviour
{
    bool fishInMouth = false;
    GameObject fishBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool HasFish()
        { return fishInMouth; }
   
    public void SetFishToAnchor(GameObject Body)
    {
        fishBody = Body;
        transform.SetParent(Body.transform);
    }
}
