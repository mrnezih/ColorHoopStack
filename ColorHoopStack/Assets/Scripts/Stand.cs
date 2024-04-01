using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Stand : MonoBehaviour
{
    public GameObject movementPosition;
    public GameObject[] sockets; 
    public int theEmptySocket; 
    public List<GameObject> _circles = new();
    [SerializeField] private GameManager _gameManager;
    
    int numberOfCircleCompletions;

    public GameObject GiveTheTopCircle()
    {
        return _circles[^1]; // En sonuncu elemaný seçmek için.
    }

    public GameObject GiveAvailableSocket()
    {
        return sockets[theEmptySocket];
    }

    public void SocketReplacementOperations(GameObject DeletingObje)
    { 
        _circles.Remove(DeletingObje);
        if (_circles.Count != 0 ) 
        {
            theEmptySocket--;
            _circles[^1].GetComponent<Circle>().canItMove = true;
        }
        else
        {
            theEmptySocket = 0;
        }
    }

    public void CheckTheCircles()
    {
        if(_circles.Count==4)
        {
            string color = _circles[0].GetComponent<Circle>().color;

            foreach (var item in _circles)
            {
                if(color == item.GetComponent<Circle>().color)
                {
                    numberOfCircleCompletions++;
                }
            }
            if (numberOfCircleCompletions == 4)
            {
                _gameManager.StandCompleted();
                CompletedStandOperations();

            }
            else
            {
                numberOfCircleCompletions = 0;
            }
        }
    }

    void CompletedStandOperations()
    {
        foreach (var item in _circles)
        {
            item.GetComponent<Circle>().canItMove = false; //çember kitleme
            
            //Color32 color = item.GetComponent<MeshRenderer>().material.GetColor("_color");
            //color.a = 150;
            //item.GetComponent<MeshRenderer>().material.SetColor("_color", color);//çemberin rengini deðiþtirme tamamlanýnca
            gameObject.tag = "CompletedStand";
        }
    }
}
