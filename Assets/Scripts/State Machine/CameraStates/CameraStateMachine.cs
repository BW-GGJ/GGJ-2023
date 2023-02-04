using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStateMachine : StateMachine
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _player;
    [SerializeField] private float speed;

    public static CameraStateMachine instance;

    private Vector2 Point;

    private void Awake()
    {
        if (!instance) instance = this;
    }

    private void Start()
    {
        State = new GotoState(this);
        StartCoroutine(State.Start());
    }

    private void Update()
    {
        StartCoroutine(State.Update());
    }

    public void SetPlayerFollow(GameObject Player = null) 
    {
        if (!Player && ! _player) 
        {
            Debug.Log("No player to follow!");
            return;
        }
        if (Player) 
        {
            _player = Player;
        }
        Debug.Log("Starting follow!");
        StartCoroutine(State.FollowPlayer());
    }
    public void SetFollowPoint(Vector2 point) 
    {
        SetPoint(point);
        StartCoroutine(State.GotoPoint());
    }

    public GameObject GetCamera()
    {
        return _camera;
    }
    public GameObject GetPlayer()
    {
        return _player;
    }
    public Vector2 GetPoint()
    {
        return Point;
    }
    public void SetPoint(Vector2 newPoint) 
    {
        Point = newPoint;
    }
    public float GetSpeed() 
    {
        return speed;
    }
}
