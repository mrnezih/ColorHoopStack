using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject selectedObject;
    GameObject selectedStand;
    Circle _circle;
    public bool thereIsMovement;
    public int targetStandNumber;
    int completedStandNumber;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out RaycastHit hit,100))
            {
                if (hit.collider!=null && hit.collider.CompareTag("Stand"))
                {
                    if(selectedObject!=null && selectedStand!=hit.collider.gameObject)
                    {//Bir çember gönderme iþlemi.


                    }
                    else
                    {
                        Stand _stand = hit.collider.GetComponent<Stand>();
                        selectedObject = _stand.giveTheTopCircle();
                        _circle=selectedObject.GetComponent<Circle>();
                        thereIsMovement = true;

                        if(_circle.canItMove)
                        {
                            _circle.Move("chose", null, null,_circle._standBelongs.GetComponent<Stand>().movementPosition);

                            selectedStand = _circle._standBelongs;
                        }

                    }
                }
            }
        }



    }
}
