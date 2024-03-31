using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{
    public GameObject movementPosition;
    public GameObject[] sokets;
    public int theEmptySocket;
    public List<GameObject> _circles = new();
    [SerializeField] private GameManager _gameManager;

    public GameObject giveTheTopCircle()
    {
        return _circles[^1]; // En sonuncu elemaný seçmek için.
    }

}
