// NavController.cs
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Geometry;

public class NavController : MonoBehaviour
{
    private ROSConnection ros;
    private float linearX = 0f;
    private float angularZ = 0f;

    public float linearScale = 1.0f;
    public float angularScale = 1.0f;

    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.Subscribe<TwistMsg>("/cmd_vel_nav", OnCmdVel);
    }

    void OnCmdVel(TwistMsg msg)
    {
        linearX = (float)msg.linear.x;
        angularZ = (float)msg.angular.z;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * linearX * linearScale * Time.deltaTime);
        transform.Rotate(Vector3.up * angularZ * angularScale * Mathf.Rad2Deg * Time.deltaTime);
    }
}