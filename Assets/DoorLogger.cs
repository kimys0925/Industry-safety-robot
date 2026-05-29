using UnityEngine;

public class DoorLogger : MonoBehaviour
{
    void Start()
    {
        Debug.Log("DoorLogger 시작!");
        Transform[] allTransforms = FindObjectsOfType<Transform>();
        foreach (var t in allTransforms)
        {
            if (t.name.ToLower().Contains("door"))
            {
                Debug.Log($"{t.name} 월드좌표: {t.position}");
            }
        }
    }
}