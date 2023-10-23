using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneController, IUserAction
{
    public static int LEFTLAND = 0;
    public static int RIGHTLAND = 1;
    public static int BOAT = 2;

    public static int PRIEST = 0;
    public static int DEVIL = 1;

    public static int PLAYING = 0;
    public static int WIN = 1;
    public static int FAILED = 2;

    public CCActionManager actionManager;

    public BoatController BoatCtrl;
    public RoleController[] RoleCtrl = new RoleController[6];
    public LandController[] LandCtrl = new LandController[2];
    public JudgeController JudgeCtrl;

    public int[] rolesID = new int[6] { 0, 1, 2, 3, 4, 5 };
    public int gameState;

    void Awake() {
        SSDirector director = SSDirector.GetInstance();
        director.CurrentSceneController = this;
        director.CurrentSceneController.Initialize();
    }

    public void Initialize() {
        //如果有，则释放原有的GameObject
        for (int i = 0; i < 6; i++) {
            if (RoleCtrl[i] != null) {
                Destroy(RoleCtrl[i].GetModelGameObject());
            }
        }
        for (int i = 0; i < 2; i++) {
            if (LandCtrl[i] != null) {
                Destroy(LandCtrl[i].GetModelGameObject());
            }
        }
        if (BoatCtrl != null) {
            Destroy(BoatCtrl.GetModelGameObject());
        }
        // 加载控制器和模型
        BoatCtrl = new BoatController();
        BoatCtrl.CreateModel();

        for (int i = 0; i < 6; i++) {
            int roleType = (i < 3) ? PRIEST : DEVIL;
            RoleCtrl[i] = new RoleController(roleType, rolesID[i]);
            RoleCtrl[i].CreateModel();
        }
        LandCtrl[0] = new LandController(LEFTLAND, rolesID);
        LandCtrl[1] = new LandController(RIGHTLAND, rolesID);
        LandCtrl[0].CreateModel();
        LandCtrl[1].CreateModel();

        JudgeCtrl = new JudgeController();

        actionManager = new CCActionManager();

        //开始游戏
        gameState = PLAYING;
    }

    //将角色的ID转换成数组的下标
    public int IDToNumber(int ID) {
        for (int i = 0; i < 6; i++) {
            if (rolesID[i] == ID) {
                return i;
            }
        }
        return -1;
    }

    // 点击船时执行
    public void MoveBoat()
    {
        if (gameState != PLAYING || actionManager.IsMoving())
        {
            return;
        }
        gameState = JudgeCtrl.UpdateGameState();
        if (BoatCtrl.onLeftside)
        {
            actionManager.MoveBoat(BoatCtrl, RIGHTLAND);
        }
        else
        {
            actionManager.MoveBoat(BoatCtrl, LEFTLAND);
        }
        BoatCtrl.onLeftside = !BoatCtrl.onLeftside;
    }

    // 点击角色时执行
    public void MoveRole(int id)
    {
        int num = IDToNumber(id);
        if (gameState != PLAYING || actionManager.IsMoving()) return;
        int seat;
        switch (RoleCtrl[num].roleState)
        {
            case 0: // LEFTLAND
                if (!BoatCtrl.onLeftside) return;
                seat = BoatCtrl.embark(id);
                if (seat == -1) return;
                LandCtrl[0].LeaveLand(id);
                RoleCtrl[num].GoTo(BOAT);
                actionManager.MoveRole(BoatCtrl, RoleCtrl[num], BOAT, seat);
                break;
            case 1: // RIGHTLAND
                if (BoatCtrl.onLeftside) return;
                seat = BoatCtrl.embark(id);
                if (seat == -1) return;
                LandCtrl[1].LeaveLand(id);
                RoleCtrl[num].GoTo(BOAT);
                actionManager.MoveRole(BoatCtrl, RoleCtrl[num], BOAT, seat);
                break;
            case 2: //BOAT
                if (BoatCtrl.onLeftside)
                {
                    seat = LandCtrl[0].getEmptySeat();
                    BoatCtrl.disembark(id);
                    LandCtrl[0].GoOnLand(id);
                    RoleCtrl[num].GoTo(LEFTLAND);
                    actionManager.MoveRole(BoatCtrl, RoleCtrl[num], LEFTLAND, seat);
                }
                else
                {
                    seat = LandCtrl[1].getEmptySeat();
                    BoatCtrl.disembark(id);
                    LandCtrl[1].GoOnLand(id);
                    RoleCtrl[num].GoTo(RIGHTLAND);
                    actionManager.MoveRole(BoatCtrl, RoleCtrl[num], RIGHTLAND, seat);
                }
                break;
            default: break;
        }
    }

    //Reset按钮执行的功能
    public void Restart(){
        Initialize();
        gameState = PLAYING;
    }

    //获取游戏当前状态
    public int GetGameState(){
        return gameState;
    }
}
