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
    GameObject standWillGo;

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
                standWillGo = stand;
                _belongsCircleSocket = socket;
                movementPosition = destinationObject;
                changePose = true;
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

        if (changePose)
        {
            transform.position = Vector3.Lerp(transform.position, movementPosition.transform.position, .2f);
            if (Vector3.Distance(transform.position, movementPosition.transform.position) < .10)
            {
                changePose = false;
                socketSit = true;
            }
        }

        if (socketSit)
        {
            transform.position = Vector3.Lerp(transform.position, _belongsCircleSocket.transform.position, .2f);
            if (Vector3.Distance(transform.position, _belongsCircleSocket.transform.position) < .10)
            {
                transform.position = _belongsCircleSocket.transform.position;
                socketSit = false;

                _standBelongs = standWillGo;

                if(_standBelongs.GetComponent<Stand>()._circles.Count>1)
                {
                    _standBelongs.GetComponent<Stand>()._circles[^2].GetComponent<Circle>().canItMove = false;
                }
                _gameManager.thereIsMovement = false;
            }
        }
    }
}
