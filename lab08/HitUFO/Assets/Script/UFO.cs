using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO
{
    int id;
    public bool isOver;
    public GameObject ufoObject;
    private UFOFactory myFactory;

    public UFO(UFOFactory factory, int id)
    {
        this.myFactory = factory;
        this.id = id;
        this.isOver = false;

        ufoObject = GameObject.Instantiate(Resources.Load("Prefabs/UFO", typeof(GameObject))) as GameObject;
        ufoObject.AddComponent<Click>();
        ufoObject.GetComponent<Click>().SetDepend(this);
        ufoObject.AddComponent<MoveOut>();
    }

    public void SetUFOActive(bool active)
    {
        ufoObject.SetActive(active);
    }

    public void Fly(Color c, float scale, Vector3 pos, Vector3 force)
    {
        ufoObject.SetActive(true);
        ufoObject.GetComponent<Renderer>().material.color = c;
        ufoObject.transform.localScale = ufoObject.transform.localScale * scale;
        ufoObject.transform.position = pos;
        if (!ufoObject.GetComponent<Rigidbody>())
        {
            ufoObject.AddComponent<Rigidbody>();
        }
        // 对UFO施加冲量力
        ufoObject.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
    }

    public void Click()
    {
        this.isOver = true;
        myFactory.ClickUFO(this.id);
    }

    public void Fail()
    {
        this.isOver = true;
        myFactory.FailUFO(this.id);
    }
}