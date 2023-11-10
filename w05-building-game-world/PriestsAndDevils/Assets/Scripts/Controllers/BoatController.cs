using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : IObjectController
{
    
    public bool onLeftside;
    IUserAction userAction;
    public int[] seat;
    public Boat boatModel;

    public BoatController(){
        userAction = SSDirector.GetInstance().CurrentSceneController as IUserAction;
        seat = new int[2];
        Reset();
    }

    public void Reset(){
        onLeftside = true;
        for(int i = 0; i < seat.Length; i++){
            seat[i] = -1;
        }
    }

    public int embark(int roleID){
        for(int i = 0; i < seat.Length; i++){
            if(seat[i] == -1){
                seat[i] = roleID;
                return i;
            }
        }
        return -1;
    }

    public int getEmptySeat(){
        for(int i = 0; i < seat.Length; i++){
            if(seat[i] == -1){
                return i;
            }
        }
        return -1;
    }

    public bool isEmpty()
    {
        for (int i = 0; i < seat.Length; i++)
        {
            if (seat[i] != -1) {
                return false;
            }
        }
        return true;
    }

    public void disembark(int roleID){
        for(int i = 0; i < seat.Length; i++){
            if(seat[i] == roleID){
                seat[i] = -1;
                return;
            }
        }
    }

    public void CreateModel(){
        boatModel = new Boat(Position.boatLeftPos);
        boatModel.boat.GetComponent<Click>().setClickAction(this);
    }

    public void DealClick(){
        userAction.MoveBoat();
    }

    public GameObject GetModelGameObject(){
        return boatModel.boat;
    }

}
