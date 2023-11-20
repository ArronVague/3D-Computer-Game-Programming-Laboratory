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
        usedArrow.Add(newArrow);
        return newArrow;
    }

    public void FreeArrow1(GameObject arrow1)
    {
        for (int i = 0; i < usedArrow.Count; i++)
        {
            if (usedArrow[i] == arrow1)
            {
                usedArrow.Remove(arrow1);
                arrow1.SetActive(true);
                freeArrow.Add(arrow1);
            }
        }
        return;
    }

    void Start()
    {
        sceneController = (FirstController)SSDirector.getInstance().currentSceneController;
        sceneController.arrowfactory = this;
        arrowTemplate = Instantiate(Resources.Load("Prefabs/Arrow")) as GameObject;
        arrowTemplate.SetActive(false);
        arrowTemplate.transform.localEulerAngles = new Vector3(90, 0, 0);
        freeArrow.Add(sceneController.Arrow);
    }

    void Update()
    {

    }
}