using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipPlayer : MonoBehaviour
{
    public float fallingForce;

    private Vector3[] direction;
    private Vector3[] sidePosition = new Vector3[6];
    private Vector3 size;
    private bool isFalling = false;

    private void Start()
    {
        size = GetComponent<MeshRenderer>().bounds.size / 2;
                
    }

    private int CalculatePositions(Vector3 playerPosition){
        direction = new Vector3[6]{
            transform.up * size.y,
            -transform.up * size.y,
            transform.right * size.x,
            -transform.right * size.x,
            transform.forward * size.z,
            -transform.forward * size.z
        };

        for (int i = 0; i< sidePosition.Length; i++){
            sidePosition[i] = direction[i] + transform.position;
        }

        int index = 0;
        float distance = (sidePosition[0] - playerPosition).sqrMagnitude;
        float newDistance;

        for(int i= 1; i < sidePosition.Length; i++){
            newDistance = (sidePosition[i] - playerPosition).sqrMagnitude;

            if (distance > newDistance){
                distance = newDistance;
                index = i;
            }
        }

        return index;
    }

    private float AngleOfSlope(int index){
        return Mathf.Abs(Vector3.Angle(direction[index],Vector3.up));
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            int index = CalculatePositions(other.transform.position);
            //Debug.Log(AngleOfSlope(index));
            if(AngleOfSlope(index) > 45){
                other.GetComponent<Rigidbody>().AddForce(-Vector3.up * fallingForce,ForceMode.Impulse);
            }
        }
    }
}
