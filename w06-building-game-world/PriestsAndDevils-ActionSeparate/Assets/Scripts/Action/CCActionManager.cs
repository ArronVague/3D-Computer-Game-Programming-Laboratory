using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CCActionManager
{
    public CCMoveAction moveBoatAction;
    public CCMoveAction moveRoleAction;

    public FirstController controller;

    public CCActionManager()
    {
        controller = SSDirector.GetInstance().CurrentSceneController as FirstController;
        controller.actionManager = this;

        moveBoatAction = new CCMoveAction();
        moveRoleAction = new CCMoveAction();
    }

    public bool IsMoving()
    {
        return moveRoleAction.IsMoving() || moveBoatAction.IsMoving();
    }

    //点击角色时执行
    public void MoveRole(BoatController BoatCtrl, RoleController RoleCtrl, int destination, int seat)
    {
        Vector3 finalPos;
        if (destination == FirstController.RIGHTLAND)
        {
            finalPos = Position.roleRightPos[seat];
        }
        else if (destination == FirstController.LEFTLAND)
        {
            finalPos = Position.roleLeftPos[seat];
        }
        else
        {
            if (BoatCtrl.onLeftside)
            {
                finalPos = Position.seatLeftPos[seat];
            }
            else
            {
                finalPos = Position.seatRightPos[seat];
            }
        }
        moveRoleAction.MoveSequence(RoleCtrl.GetModelGameObject(), finalPos);
    }

    //点击船时执行
    public void MoveBoat(BoatController BoatCtrl, int destination)
    {
        if (destination == FirstController.RIGHTLAND)
        {
            moveBoatAction.MoveTo(BoatCtrl.GetModelGameObject(), Position.boatRightPos);
            for (int i = 0; i < BoatCtrl.seat.Length; i++)
            {
                if (BoatCtrl.seat[i] != -1)
                {
                    RoleController r = controller.RoleCtrl[controller.IDToNumber(BoatCtrl.seat[i])];
                    moveRoleAction.MoveTo(r.GetModelGameObject(), Position.seatRightPos[i]);
                }
            }
        }
        else
        {
            moveBoatAction.MoveTo(BoatCtrl.GetModelGameObject(), Position.boatLeftPos);
            for (int i = 0; i < BoatCtrl.seat.Length; i++)
            {
                if (BoatCtrl.seat[i] != -1)
                {
                    RoleController r = controller.RoleCtrl[controller.IDToNumber(BoatCtrl.seat[i])];
                    moveRoleAction.MoveTo(r.GetModelGameObject(), Position.seatLeftPos[i]);
                }
            }
        }
    }
}