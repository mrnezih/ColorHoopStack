using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{
    public GameObject movementPosition;
    public GameObject[] sockets; 
    public int theEmptySocket; 
    public List<GameObject> _circles = new();
    [SerializeField] private GameManager _gameManager;

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
}
