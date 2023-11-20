using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play : SSAction
{
    int count = 0;
    bool enableEmie = true;
    Vector3 force;

    public FirstController sceneController = (FirstController)SSDirector.getInstance().currentSceneController;
    
    public static play GetSSAction()
    {
        play action = ScriptableObject.CreateInstance<play>();
        return action;
    }

    public override void Start()
    {
        force = new Vector3(0, 0.3f, 2);
    }

    public override void Update()
    {
        gameobject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameobject.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
    }

    public void Destroy()
    {
        this.destroy = true;
        this.callback.SSActionEvent(this);
        Destroy(gameobject.GetComponent<BoxCollider>());
    }
}