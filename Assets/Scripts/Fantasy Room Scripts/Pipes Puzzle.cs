using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public class PipesPuzzle : MonoBehaviour{
    public GameObject hotSword;
    public GameObject swordPuzzle;
    public GameObject fire;

    public AudioClip extinguishSound;
    public Pipe startPipe;
    public Pipe endPipe;
    private List<Pipe> pipes = new();
    
    private HashSet<Pipe> connectedPipes = new();

    public static PipesPuzzle instance;

    private void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    private void Start(){
        pipes.AddRange(GetComponentsInChildren<Pipe>());
        
    }

    public void CheckPuzzle(){
        connectedPipes.Clear();
        IteratePipes(startPipe);
        Debug.Log(connectedPipes.Contains(endPipe));
        if(connectedPipes.Contains(endPipe)){
            print("Win found");
            HandleWin();
        }
    }

    private void IteratePipes(Pipe curr){
        if(curr == null || connectedPipes.Contains(curr)) return;

        connectedPipes.Add(curr);
        foreach(Transform port in curr.portTransforms){
            Collider[] hits = Physics.OverlapSphere(port.position, 0.1f);

            foreach(var hit in hits){
                if(hit.CompareTag("Pipe Opening") && hit.transform.parent != curr.transform){
                    Pipe neighbor = hit.GetComponentInParent<Pipe>();
                    if(neighbor != null && neighbor != curr){
                        IteratePipes(neighbor);
                    }
                }
            }
        }
    }

    private void HandleWin(){ 
        StartCoroutine(ExtinguishFire());
        hotSword.SetActive(false);
        swordPuzzle.SetActive(true);

        foreach(Pipe p in pipes){
            p.ChangeState(PipeState.LOCKED);
        }
    }

    private IEnumerator ExtinguishFire(){
        AudioSource fireAudio = fire.GetComponent<AudioSource>();
        fireAudio.Stop();
        fireAudio.PlayOneShot(extinguishSound);
        yield return new WaitForSeconds(2f);
        fire.SetActive(false);
    }
}
