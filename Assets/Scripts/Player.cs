using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [FormerlySerializedAs("ActualZone")] public Zone actualZone;
    private Zone _currentZone;

    private void Awake()
    {
        _currentZone = Zone.ThreePoints;
        actualZone = Zone.ThreePoints;
    }

    private void FixedUpdate()
    {
#if UNITY_EDITOR
        Debug.Log(_currentZone);
#endif
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Zone")) return;
        var pointsZone = other.GetComponent<PointsZone>();
        _currentZone = pointsZone.zone;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Zone")) return;
        if (_currentZone == Zone.OnePoint) _currentZone = Zone.TwoPoints;
        if (_currentZone == Zone.TwoPoints) _currentZone = Zone.ThreePoints;
    }

    public void OnBallRelease()
    {
        actualZone = _currentZone;
    }
}