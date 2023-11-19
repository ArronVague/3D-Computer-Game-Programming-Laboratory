using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowFactory : MonoBehaviour
{
    private static ArrowFactory _instance;
    private List<GameObject> freeArrow;
    private List<GameObject> usedArrow;
    private GameObject arrowTemplate;

    public FirstController sceneController { get; set; }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = Singleton<ArrowFactory>.Instance;
            _instance.usedArrow = new List<GameObject>();
            _instance.freeArrow = new List<GameObject>();
        }        
    }

    public GameObject GetArrow1()
    {
        GameObject newArrow;
        if (freeArrow.Count == 0)
        {
            newArrow = GameObject.Instantiate(Resources.Load("Prefabs/Arrow")) as GameObject;
        }
        else
        {
            newArrow = freeArrow[0];
            freeArrow.Remove(freeArrow[0]);
        }

        newArrow.transform.position = arrowTemplate.transform.position;
        newArrow.transform.localEulerAngles = new Vector3(90, 0, 0);
    }
}