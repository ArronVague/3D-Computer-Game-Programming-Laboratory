# lab11-模型与动画2

第一人称射箭游戏

- [ ] 基础分：有博客；
- [ ] 1-3分钟视频：视频呈现游戏主要游玩过程；
- [x] 地形：使用地形组件，上面有草、树；
- [x] 天空盒：使用天空盒，天空可随玩家位置 或 时间变化 或 按特定按键切换天空盒；
- [x] 固定靶：有一个以上固定的靶标；
- [x] 运动靶：有一个以上运动靶标，运动轨迹，速度使用动画控制；
- [x] 射击位：地图上应标记若干射击位，仅在射击位附近可以拉弓射击，每个位置有 n 次机会；
- [x] 驽弓动画：支持蓄力半拉弓，然后 hold，择机 shoot；
- [x] 游走：玩家的驽弓可在地图上游走，不能碰上树和靶标等障碍；
- [x]  碰撞与计分：在射击位，射中靶标的相应分数，规则自定。

CCActionManager.playArrow控制箭发射的初始力，play控制的是箭发射出去后的飞行轨迹。这里并不需要，用rigidbody。

使用说明

Main Camera挂载UserGUI.cs，添加组件Skybox()。

将预制件FPSController拖入Hierarchy，并挂载FirstController.cs。

FPSController子组件FirstPersonCharacter挂载SkyboxController。

添加预制件Target，并挂载

参考文献

射箭打靶

[【Unity3D】射箭打靶游戏（简单工厂+物理引擎编程）](https://www.cnblogs.com/xieyuanzhen-Feather/p/6666586.html)（主要参考）

[Unity3D学习之射箭小游戏](https://blog.csdn.net/Kiloveyousmile/article/details/69491549)