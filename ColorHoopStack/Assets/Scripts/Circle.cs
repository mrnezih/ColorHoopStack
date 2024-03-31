using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public GameObject _standBelongs;
    public GameObject _belongsCircleSocket;
    public bool canItMove;
    public string color;
    public GameManager _gameManager;


    GameObject movementPosition;
    GameObject standBelongs;

    bool chosen, changePose, socketSit, backToSocket;

    public void Move(string process, GameObject stand = null, GameObject socket=null,GameObject destinationObject=null)
    {
        switch(process)
        {
            case "chose":
                movementPosition = destinationObject;
                chosen = true;
                break;
            
            case "change_pose":

                break;

            case "socket_sit":

                break;

            case "back_to_socket":

                break;
        }
    }

    void Update()
    {
        if (chosen)
        {
            transform.position = Vector3.Lerp(transform.position, movementPosition.transform.position, .2f);
            if(Vector3.Distance(transform.position, movementPosition.transform.position)<.10)
            {
                chosen = false;
            }
        }
    }
}
