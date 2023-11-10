using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position
{
    public static Vector3 boatLeftPos = new Vector3(-3.5f, -1, 12);
    
    public static Vector3 boatRightPos = new Vector3(3.5f, -1, 12);

    public static Vector3[] roleLeftPos = new Vector3[6]{new Vector3(-11, 0, 12), 
                                                         new Vector3(-10, 0, 12),
                                                         new Vector3(-9, 0, 12),
                                                         new Vector3(-8, 0, 12),
                                                         new Vector3(-7, 0, 12),
                                                         new Vector3(-6, 0, 12)};

    public static Vector3[] roleRightPos = new Vector3[6]{new Vector3(6, 0, 12), 
                                                          new Vector3(7, 0, 12),
                                                          new Vector3(8, 0, 12),
                                                          new Vector3(9, 0, 12),
                                                          new Vector3(10, 0, 12),
                                                          new Vector3(11, 0, 12)};

    public static Vector3[] landInitPos = new Vector3[2]{new Vector3(-8, -1, 12), 
                                                         new Vector3(8, -1, 12)};

    public static Vector3[] seatLeftPos = new Vector3[2]{new Vector3(-4.5f, 0, 12), 
                                                         new Vector3(-2.5f, 0, 12)};

    public static Vector3[] seatRightPos = new Vector3[2]{new Vector3(2.5f, 0, 12), 
                                                          new Vector3(4.5f, 0, 12)};
}
