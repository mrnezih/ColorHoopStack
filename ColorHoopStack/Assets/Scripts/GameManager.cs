using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject selectedObject;
    GameObject selectedStand;
    Circle _circle;
    public bool thereIsMovement;
    public int destinationStandNumber;
    int completedStandNumber;

    public Text tapToStartText;
    public GameObject winPanel;


    private void Start()
    {
        Time.timeScale = 0;
        tapToStartText.enabled = true;
        winPanel.SetActive(false);
        
    }


    void Update()
    {
        //if (Input.touchCount >0)
        //{
        //    Time.timeScale = 1;
        //    tapToStartText.enabled = false;
        //}

        if(Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
            tapToStartText.enabled = false;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out RaycastHit hit,100))
            {
                if (hit.collider!=null && hit.collider.CompareTag("Stand"))
                {
                    if(selectedObject!=null && selectedStand!=hit.collider.gameObject)
                    {//Bir çember gönderme iþlemi.

                        Stand _stand=hit.collider.GetComponent<Stand>();

                        if(_stand._circles.Count !=4 && _stand._circles.Count!=0) // standýn max ve min deðeri
                        {
                            if (_circle.color == _stand._circles[^1].GetComponent<Circle>().color) //Renk kontrol
                            {
                                //Çember gönderilerme
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
                        else //dolu olunca göndermeme
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
        //int nextLevel = SceneManager.GetActiveScene().buildIndex;
        completedStandNumber++;
        if (completedStandNumber== destinationStandNumber)
        {
            Debug.Log("Kazandýn"); // Kazandýn paneli.

            Time.timeScale = 0;

            //nextLevel++;
            //SceneManager.LoadScene(nextLevel);

            winPanel.SetActive(true);
        }
     }

    public void LoadNextLevel()
    {
        Debug.Log("Next level loading...");
        //int nextLevel = SceneManager.GetActiveScene().buildIndex;
        //nextLevel++;
        //SceneManager.LoadScene(nextLevel);
    }

    public void ButonTiklandi()
    {
            Debug.Log("Butona týklandý!");
        // Butonun çalýþacaðý diðer kodlar buraya gelecek
    }





}
