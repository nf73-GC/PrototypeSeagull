using System.Linq;
using UnityEngine;

public class inventory : MonoBehaviour
{
    public GameObject[] objects;

    void Start()
    {
        GameObject t = new GameObject("Fish");

        for(int i = 0; i < 5; ++i)
        {
            objects.Append(t);
        }
    }

    void Update()
    {
        
    }
}
