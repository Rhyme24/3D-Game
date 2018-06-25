&nbsp;&nbsp;视频地址：[多人聊天室][1]

&nbsp;&nbsp;游戏中有两个场景：Offline和Online。分别管理游戏连接前、后的界面。

![场景][2]

&nbsp;&nbsp;NetworkManager对象中放置了两个组件。Network Manager HUD实现了游戏连接前的GUI；Network Manager 用于网络管理，在该组件中确定游戏连接前后的场景以及玩家预制。

![NetworkManager][3]

&nbsp;&nbsp;在玩家预制中添加Network Identity组件，设置为只允许本地客户端控制。

![此处输入图片的描述][4]


  [1]: http://t.cn/RrM2L2K?m=4254870544221752&u=1802733303
  [2]: https://wx2.sinaimg.cn/mw690/6b7386f7ly1fsnvdlz3xuj20aj05974d.jpg
  [3]: https://wx3.sinaimg.cn/mw690/6b7386f7ly1fsnvhuff7lj20ah0l6gnp.jpg
  [4]: https://wx3.sinaimg.cn/mw690/6b7386f7ly1fsnvs1v20kj20ay0233yk.jpg
