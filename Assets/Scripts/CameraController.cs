using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform far;
    [SerializeField] Transform middle;
    [SerializeField] float minHeight;
    [SerializeField] float maxHeight;
    [SerializeField] float minLeft;
    [SerializeField] float maxRight;
    private float lastPos;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position.x;   
    }

    // Update is called once per frame
    void Update()
    {
        //*****camera following player*****
        
        //transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);

        //float clampY = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
        //transform.position = new Vector3(transform.position.x, clampY, transform.position.z);

        transform.position = new Vector3(Mathf.Clamp(player.position.x, minLeft, maxRight), Mathf.Clamp(player.position.y,minHeight,maxHeight),transform.position.z);


        //****below is to move backgrounds****
        float amountToMoveX = transform.position.x - lastPos;
        far.position = far.position + new Vector3(amountToMoveX, 0f, 0f);
        middle.position = middle.position + new Vector3(amountToMoveX * 0.5f, 0f, 0f);
        lastPos = transform.position.x;


    }
}
