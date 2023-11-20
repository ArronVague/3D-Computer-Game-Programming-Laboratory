using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

namespace Com.Mygame
{
    public interface ISceneController
    {
        void LoadResources();
        float getWindforce();
    }

    public interface IUserAction
    {
        void ShowDetail();
        void StartGame();
        void hit(Vector3 dir);
    }

}
