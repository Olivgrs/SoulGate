using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{

    #region StateVariable
    private PlayerBaseState _currentState;
    private PlayerStateFactory _states;

    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    #endregion StateVariable

    #region Animation
    private Animator _animator;
    public Animator Animator { get { return _animator; } set { _animator = value; } }
    #endregion

    #region Movement

    public Camera _camera;
    public Camera Camera { get { return _camera; } set { _camera = value; } }

    #endregion

    #region pdv
    public int pdv = 10;
    #endregion

    
    void Awake()
    {
        InitializeState();
    }

    void Start() { }

    void Update()
    {

        UpdateState();
    }

    private void InitializeState()
    {
        _states = new PlayerStateFactory(this);
        _currentState = _states.Idle();
        _currentState.EnterState();
    }

    private void UpdateState()
    {
        _currentState.UpdateState();
    }

}