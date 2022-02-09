using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Singleton

    public static GameController Instance;

    private void Awake()
    {
        Instance = this;
        selectedGOInstance = new Queue<GameObject>();
        allGOInstance = new List<GameObject>();
    }

    #endregion

    public Queue<GameObject> selectedGOInstance;

    [SerializeField]
    public List<GameObject> allGOInstance;
}
