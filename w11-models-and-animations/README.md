# lab11-模型与动画2



- [ ] 博客

- [ ] 1-3分钟视频
- [x] 使用地形组件，有草、树
- [x] 天空盒（预计使用E键与场景互动）
- [x] 一个以上固定靶
- [x] 一个以上运动靶，轨迹、速度由动画控制
- [x] 射击位
- [x] 弩弓动画：蓄力半拉弓，hold，shoot
- [x] 游走：不能碰
- [x] 射中靶标

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