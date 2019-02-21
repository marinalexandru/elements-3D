using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject target;
    private float offsetZ;
    private float offsetY;

    // Use this for initialization
    void Start()
    {
        offsetY = this.transform.position.y;
        offsetZ = this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 destination = new Vector3
        {
            z = target.transform.position.z + offsetZ,
            x = target.transform.position.x,
            y = target.transform.position.y + offsetY
        };
        this.transform.position = destination;
    }
}
