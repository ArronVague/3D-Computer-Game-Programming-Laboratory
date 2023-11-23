using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play : SSAction
{
    public FirstController sceneController = (FirstController)SSDirector.getInstance().currentSceneController;
    
    public static play GetSSAction()
    {
        play action = ScriptableObject.CreateInstance<play>();
        return action;
    }

    public override void Start()
    {
    }

    public override void Update()
    {
    }

    public void Destroy()
    {
        this.destroy = true;
        this.callback.SSActionEvent(this);
        Destroy(gameobject.GetComponent<BoxCollider>());
    }
}