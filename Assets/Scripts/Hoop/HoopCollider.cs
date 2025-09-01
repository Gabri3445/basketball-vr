using System;
using UnityEngine;

public class HoopCollider : MonoBehaviour
{
    public HoopManager hoopManager;
    public HoopColliderNumber hoopColliderNumber;

    public void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Ball")) return;
        switch (hoopColliderNumber)
        {
            case HoopColliderNumber.First:
#if UNITY_EDITOR
                Debug.Log("First Collider Hit");
#endif
                hoopManager.OnFirstTriggerEnter(other);
                break;
            case HoopColliderNumber.Second:
#if UNITY_EDITOR
                Debug.Log("Second Collider Hit");
#endif
                hoopManager.OnSecondTriggerEnter(other);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}