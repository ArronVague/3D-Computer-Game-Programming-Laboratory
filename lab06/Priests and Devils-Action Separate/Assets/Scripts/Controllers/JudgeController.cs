using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeController
{
    FirstController firstCtrl;

    public JudgeController()
    {
        firstCtrl = SSDirector.GetInstance().CurrentSceneController as FirstController;
    }

    //�ж���Ϸ״̬
    public int UpdateGameState()
    {
        if (firstCtrl.gameState != FirstController.PLAYING)
        {
            return firstCtrl.gameState;
        }
        //�ж��Ƿ�ʧ��
        int[,] rolePos = new int[2, 3] { { 0, 0, 0 }, { 0, 0, 0 } };
        foreach (RoleController r in firstCtrl.RoleCtrl)
        {
            rolePos[r.roleType, r.roleState]++;
        }
        if ((rolePos[0, 0] > 0 && rolePos[0, 0] < rolePos[1, 0]) ||
           (rolePos[0, 1] > 0 && rolePos[0, 1] < rolePos[1, 1]) ||
           (rolePos[0, 2] > 0 && rolePos[0, 2] < rolePos[1, 2]))
        {
            return FirstController.FAILED;
        }
        //�ж��Ƿ�ɹ�
        foreach (RoleController r in firstCtrl.RoleCtrl)
        {
            if (r.roleType == 0 && r.roleState != FirstController.RIGHTLAND)
            {
                return FirstController.PLAYING;
            }
        }
        return FirstController.WIN;
    }
}