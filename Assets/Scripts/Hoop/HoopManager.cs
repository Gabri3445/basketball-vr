using UnityEngine;

public class HoopManager : MonoBehaviour
{
    private BasketBallManager _basketballManager;
    private bool _firstTriggerHit;

    private void Start()
    {
        _basketballManager = BasketBallManager.instance;
    }

    public void OnFirstTriggerEnter(Collider _)
    {
        _firstTriggerHit = true;
    }

    public void OnSecondTriggerEnter(Collider _)
    {
        if (!_basketballManager.isGameActive) return;
        if (!_firstTriggerHit)
            _basketballManager.RemovePoint();
        //Violation
        else
            _basketballManager.AddPoint();

        StartCoroutine(_basketballManager.StartReset());
    }
}