using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject selectedObject;
    GameObject selectedStand;
    Circle _circle;
    public bool thereIsMovement;
    public int destinationStandNumber;
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
                    {//Bir �ember g�nderme i�lemi.

                        Stand _stand=hit.collider.GetComponent<Stand>();

                        if(_stand._circles.Count !=4 && _stand._circles.Count!=0) // stand�n max ve min de�eri
                        {
                            if (_circle.color == _stand._circles[^1].GetComponent<Circle>().color) //Renk kontrol
                            {
                                //�ember g�nderilerme
                                selectedStand.GetComponent<Stand>().SocketReplacementOperations(selectedObject);
                                _circle.Move("change_pose", hit.collider.gameObject, _stand.GiveAvailableSocket(), _stand.movementPosition);
                                _stand.theEmptySocket++;
                                _stand._circles.Add(selectedObject);
                                _stand.CheckTheCircles();
                                selectedObject = null;
                                selectedStand = null;
                            }
                            else
                            {
                                //geri oturma
                                _circle.Move("back_to_socket");
                                selectedObject = null;
                                selectedStand = null;
                            }
                            
                        }
                        else if(_stand._circles.Count == 0)
                        {
                            selectedStand.GetComponent<Stand>().SocketReplacementOperations(selectedObject);
                            _circle.Move("change_pose", hit.collider.gameObject, _stand.GiveAvailableSocket(), _stand.movementPosition);
                            _stand.theEmptySocket++;
                            _stand._circles.Add(selectedObject);
                            _stand.CheckTheCircles();
                            selectedObject = null;
                            selectedStand = null;
                        }
                        else //dolu olunca g�ndermeme
                        {
                            //geri oturma
                            _circle.Move("back_to_socket");
                            selectedObject = null;
                            selectedStand = null;
                        }




                    }
                    else if(selectedStand ==hit.collider.gameObject)
                    {
                        _circle.Move("back_to_socket");
                        selectedObject = null;
                        selectedStand = null;
                    }


                    else
                    {
                        Stand _stand = hit.collider.GetComponent<Stand>();
                        selectedObject = _stand.GiveTheTopCircle();
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

    public void StandCompleted()
    {
        completedStandNumber++;
        if (completedStandNumber== destinationStandNumber)
        {
            Debug.Log("Kazand�n"); // Kazand�n panelini ��akraca��m m�zik falan.
        }
    }
}
