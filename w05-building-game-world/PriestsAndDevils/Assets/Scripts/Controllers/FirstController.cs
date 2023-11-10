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

    BoatController BoatCtrl;
    RoleController[] RoleCtrl = new RoleController[6];
    LandController[] LandCtrl = new LandController[2];
    MoveController MoveCtrl;

    int[] rolesID = new int[6] { 0, 1, 2, 3, 4, 5 };
    int gameState;

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
        MoveCtrl = new MoveController();
        //开始游戏
        gameState = PLAYING;
    }

    //将角色的ID转换成数组的下标
    int IDToNumber(int ID) {
        for (int i = 0; i < 6; i++) {
            if (rolesID[i] == ID) {
                return i;
            }
        }
        return -1;
    }

    //点击船时执行
    public void MoveBoat() {
        //Debug.Log("1");
        if (gameState != PLAYING || MoveCtrl.IsMoving() || BoatCtrl.isEmpty())
        {
/*            Debug.Log(gameState != PLAYING);
            Debug.Log(MoveCtrl.IsMoving());
            Debug.Log(BoatCtrl.isEmpty());
            Debug.Log("cannot move boat");*/
            return;
        }
        //Debug.Log("2");
        CheckAndSetGameState();
        //Debug.Log("3");
        if (BoatCtrl.onLeftside){
            MoveCtrl.SetMove(BoatCtrl.GetModelGameObject(), Position.boatRightPos);
            for(int i = 0; i < BoatCtrl.seat.Length; i++){
                if(BoatCtrl.seat[i] != -1){
                    RoleController r = RoleCtrl[IDToNumber(BoatCtrl.seat[i])];
                    MoveCtrl.SetMove(r.GetModelGameObject(), Position.seatRightPos[i]);
                }
            }
        }
        else{
            MoveCtrl.SetMove(BoatCtrl.GetModelGameObject(), Position.boatLeftPos);
            for(int i = 0; i < BoatCtrl.seat.Length; i++){
                if(BoatCtrl.seat[i] != -1){
                    RoleController r = RoleCtrl[IDToNumber(BoatCtrl.seat[i])];
                    MoveCtrl.SetMove(r.GetModelGameObject(), Position.seatLeftPos[i]);
                }
            } 
        }
        BoatCtrl.onLeftside = !BoatCtrl.onLeftside;
    }

    //点击角色时执行
    public void MoveRole(int id){
        int num = IDToNumber(id);
        if (gameState != PLAYING || MoveCtrl.IsMoving()) {
            return;
        }

        int seat;
        switch(RoleCtrl[num].roleState){
            case 0: // LEFTLAND
                if(!BoatCtrl.onLeftside) return;
                LandCtrl[0].LeaveLand(id);
                seat = BoatCtrl.embark(id);
                RoleCtrl[num].GoTo(BOAT);
                if(seat == -1) return;
                MoveCtrl.SetMove(RoleCtrl[num].GetModelGameObject(), Position.seatLeftPos[seat]);
                break;
            case 1: // RIGHTLAND
                if(BoatCtrl.onLeftside) return;
                LandCtrl[1].LeaveLand(id);
                seat = BoatCtrl.embark(id);
                RoleCtrl[num].GoTo(BOAT);
                if(seat == -1) return;
                MoveCtrl.SetMove(RoleCtrl[num].GetModelGameObject(), Position.seatRightPos[seat]);
                break;
            case 2: //BOAT
                if(BoatCtrl.onLeftside){
                    seat = LandCtrl[0].getEmptySeat();
                    BoatCtrl.disembark(id);
                    LandCtrl[0].GoOnLand(id);
                    RoleCtrl[num].GoTo(LEFTLAND);
                    MoveCtrl.SetMove(RoleCtrl[num].GetModelGameObject(), Position.roleLeftPos[seat]);
                }
                else{
                    seat = LandCtrl[1].getEmptySeat();
                    BoatCtrl.disembark(id);
                    LandCtrl[1].GoOnLand(id);
                    RoleCtrl[num].GoTo(RIGHTLAND);
                    MoveCtrl.SetMove(RoleCtrl[num].GetModelGameObject(), Position.roleRightPos[seat]);
                }
                break;
            default: break;
        }
    }

    //判断游戏状态
    public void CheckAndSetGameState(){
        if(gameState != PLAYING) return;
        //判断是否失败
        int[,] rolePos = new int[2, 3]{{0, 0, 0}, {0, 0, 0}};
        foreach(RoleController r in RoleCtrl){
            rolePos[r.roleType, r.roleState]++;
        }
        if((rolePos[0,0]>0 && rolePos[0,0]<rolePos[1,0]) || 
           (rolePos[0,1]>0 && rolePos[0,1]<rolePos[1,1]) || 
           (rolePos[0,2]>0 && rolePos[0,2] < rolePos[1,2])){
            gameState = FAILED;
            return;
        }  
        //判断是否成功
        foreach(RoleController r in RoleCtrl){
            if(r.roleType == 0 && r.roleState != RIGHTLAND){
                return;
            }
        }
        gameState = WIN;
        return;
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
