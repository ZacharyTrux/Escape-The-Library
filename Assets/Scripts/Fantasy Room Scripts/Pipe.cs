using UnityEngine;
using System.Collections.Generic;
using System;
using State = PipeState;

public enum PipeState { IDLE, ROTATING, CHECKING, LOCKED }

public class Pipe : MonoBehaviour{
    public PipeState State { get; private set; }
    public bool isFixed = false;
    private Vector3 rotationAxis = Vector3.forward;
    private float rotationSpeed = 5f;

    private HashSet<KeyValuePair<PipeState, PipeState>> allowedTransitions;
    private Dictionary<State, Action> stateEnterMethods;
    private Dictionary<State, Action> stateStayMethods;
    private Dictionary<State, Action> stateExitMethods;


    private Quaternion curRot;
    private Quaternion targetRot;
    private float t;
    private InputSystem_Actions input;
    private int[] allowedRotations = {90, -90, 180, -180};

    public List<Transform> portTransforms = new();
    

    void Awake(){
        foreach(Transform child in GetComponentsInChildren<Transform>()){
            if(child.CompareTag("Pipe Opening")){
                portTransforms.Add(child);
            }
        }
    }

    void Start(){
        State = PipeState.IDLE;
        RandomizePosition();

        allowedTransitions = new(){
            new(State.IDLE, State.ROTATING),
            new(State.ROTATING, State.CHECKING),
            new(State.CHECKING, State.IDLE),
            new(State.CHECKING, State.LOCKED),
        };

        stateEnterMethods = new() {
            [State.IDLE] = StateEnter_Idle,
            [State.ROTATING] = StateEnter_Rotating,
            [State.CHECKING] = StateEnter_Checking,
            [State.LOCKED] = StateEnter_Locked,
        };

        stateStayMethods = new() {
            [State.IDLE] = StateStay_Idle,
            [State.ROTATING] = StateStay_Rotating,
            [State.CHECKING] = StateStay_Checking,
            [State.LOCKED] = StateStay_Locked,
        };

        stateExitMethods = new() {
            [State.IDLE] = StateExit_Idle,
            [State.ROTATING] = StateExit_Rotating,
            [State.CHECKING] = StateExit_Checking,
            [State.LOCKED] = StateExit_Locked,
        };
    }

    // Update is called once per frame
    void Update(){
        if (stateStayMethods.ContainsKey(State)) {
            stateStayMethods[State].Invoke();
        }
    }

    public void ChangeState(State newState){
        if(allowedTransitions.Contains(new(State, newState))){
            stateExitMethods[State].Invoke();
            State = newState;
            stateEnterMethods[State].Invoke();
        }
    }

    private void StateEnter_Idle(){}
    private void StateEnter_Rotating(){
        curRot = transform.rotation;
        targetRot = curRot * Quaternion.AngleAxis(90, rotationAxis);
        t = 0;
    }
    private void StateEnter_Checking(){
        PipesPuzzle.instance.CheckPuzzle();

        if(State == State.CHECKING){
            ChangeState(State.IDLE);
        }
    }
    private void StateEnter_Locked(){}

    private void StateStay_Idle(){}
    private void StateStay_Rotating(){
        t += Time.deltaTime * rotationSpeed;
        transform.rotation = Quaternion.Slerp(curRot, targetRot, t);
        if(t >= 1f){
            transform.rotation = targetRot;
            ChangeState(State.CHECKING);
        }
    }
    private void StateStay_Checking(){}
    private void StateStay_Locked(){}

    private void StateExit_Idle(){}
    private void StateExit_Rotating(){}
    private void StateExit_Checking(){}
    private void StateExit_Locked(){}

    private void Interact(){
        if(State == State.IDLE){
            ChangeState(State.ROTATING);
        }
    }

    public void RandomizePosition(){
        if(isFixed) return;

        int randomIndex = UnityEngine.Random.Range(0, allowedRotations.Length);
        transform.localRotation = Quaternion.Euler(0,0, allowedRotations[randomIndex]);
    }
}
