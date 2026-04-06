using UnityEngine;
using System.Collections.Generic;
using System;

public class PipesPuzzle : MonoBehaviour
{
    private Pipe startPipe;
    private Pipe endPipe;
    private List<Pipe> pipes;
    
    private HashSet<Pipe> connectedPipes = new();

    public static PipesPuzzle instance;

    private void Start(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    public void CheckPuzzle(){
        connectedPipes.Clear();
        IteratePipes(startPipe);
        if(connectedPipes.Contains(endPipe)){
            HandleWin();
        }
    }

    private void IteratePipes(Pipe curr){
        if(curr == null || connectedPipes.Contains(curr)) return;

        connectedPipes.Add(curr);
        foreach(Transform port in curr.portTransforms){
            Collider[] hits = Physics.OverlapSphere(port.position, 0.05f);
            foreach(var hit in hits){
                if(hit.CompareTag("PipePort") && hit.transform.parent != curr.transform){
                    Pipe neighbor = hit.GetComponentInParent<Pipe>();
                    if(neighbor != null){
                        IteratePipes(neighbor);
                    }
                }
            }
        }

    }

    private void HandleWin(){
        Debug.Log("Puzzle completed!");
    }
}
