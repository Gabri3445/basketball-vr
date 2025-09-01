using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class BasketBallManager : MonoBehaviour
{
    public PointUI pointUI;
    [FormerlySerializedAs("_player")] public Player player;
    public bool isGameActive = true;
    private int _points;

    // ReSharper disable once MemberCanBePrivate.Global
    public static BasketBallManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        isGameActive = true;
        pointUI = FindAnyObjectByType<PointUI>();
        player = FindAnyObjectByType<Player>();
        pointUI.pointText.text = _points.ToString();
    }

    public void AddPoint()
    {
        switch (player.actualZone)
        {
            case Zone.OnePoint:
                _points++;
                break;
            case Zone.TwoPoints:
                _points += 2;
                break;
            case Zone.ThreePoints:
                _points += 3;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        pointUI.pointText.text = _points.ToString();
    }

    public void RemovePoint()
    {
        if (_points <= 0) return;
        _points--;
        pointUI.pointText.text = _points.ToString();
    }

    public IEnumerator StartReset()
    {
        isGameActive = false;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}