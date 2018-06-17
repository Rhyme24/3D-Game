&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;视频地址：[视频地址][1]

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;状态图：

![状态图][2]

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;其中，每个状态记录了位于右岸的牧师与恶魔数量，P代表牧师，D代表恶魔，B代表船在右边。改变状态的动作有五个：PP（两个牧师过河）、PD（一个牧师和一个恶魔过河）、DD（两个恶魔过河）、P（一个牧师过河）、D（一个恶魔过河）。

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;在程序中用三个变量来表示游戏状态：

```C#
public bool boat_is_right = true; //记录船的位置
public int right_devil_count; //记录右岸恶魔数量
public int right_priest_count; //记录右岸牧师数量
```


  [1]: http://t.cn/RBHEdzW?m=4251916739937351&u=1802733303
  [2]: https://wx4.sinaimg.cn/mw690/6b7386f7gy1fse86nldgpj20nb0h2q6c.jpg
  [3]: https://wx4.sinaimg.cn/mw690/6b7386f7gy1fse86nldgpj20nb0h2q6c.jpg
