using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMotion : MonoBehaviour {

    private Transform viewCharacter;
    private Vector3 startPosition;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float animationDuration = 2.0f;
    private Vector3 animationPosition = new Vector3(0, 3, 5);

    private void Start () {


        viewCharacter = GameObject.FindGameObjectWithTag("Player").transform;
        startPosition = transform.position - viewCharacter.position;
	}
	
	
	private void Update () {

      moveVector = viewCharacter.position + startPosition;

        moveVector.x = 0;

        moveVector.y = Mathf.Clamp(moveVector.y, 1, 3);

        if(transition > 1.0f)
       {
            transform.position = moveVector;
       }
       else
       {
            transform.position = Vector3.Lerp(moveVector + animationPosition, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(viewCharacter.position + Vector3.up);
        }
        

    }
}
