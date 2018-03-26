**1.解释 游戏对象（GameObjects） 和 资源（Assets）的区别与联系。**
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;答：游戏对象是一种容器，开发者可以通过在其中增加组件来将其打造成预期的模样，资源包括代码、预设等，可用来规定游戏对象的样式和行为。资源包括游戏对象，也能作用于游戏对象。


----------

**2.下载几个游戏案例，分别总结资源、对象组织的结构（指资源的目录组织结构与游戏对象树的层次结构）**
答：
2D Game Kit：
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;资源结构：将所有资源分成八大类。Art中放所需图片，动画等，负责界面样式；Audio中放音频文件；Documentation放游戏制作教程等文件；Prefabs中放预置；Scenes中放了各种已搭好的完整游戏界面；Scripts中放代码，用于debug等后台处理；TutorialInfo中放使用说明；Utilities负责逻辑与事件管理。
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;对象结构：将游戏对象分成四大类。GameUtilities中放游戏控制对象；UI负责交互，包括事件触发后出现的游戏对象；Characters中放了玩家操控的游戏对象，；LevelArt主要包括背景对象，用来设置界面布局。

Roll-A-Ball：
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;资源结构：将所有资源分为两个部分，一部分为游戏内部资源，包括预置、脚本等；另一部分为游戏外部资源，包括游戏图标和使用说明等。
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;对象结构：将游戏对象分成八个部分。其中Player，Walls，Pick Ups，Canvas和Ground为游戏界面中渲染出的实物对象；EventSystem为事件对象，用以规定其他游戏对象的行为；Diewctional Light和Main Camera则起到管理玩家界面视角的作用。


----------
**3.编写一个代码，使用 debug 语句来验证 MonoBehaviour 基本行为触发的条件
基本行为包括 Awake() Start() Update() FixedUpdate() LateUpdate()**

验证 MonoBehaviour 基本行为代码如下：

    void Start () {
        Debug.Log("Hello Start!");
	}

    void Awake()
    {
        Debug.Log("Hello Awake!");
    }

    // Update is called once per frame
    void Update () {
        Debug.Log("Hello Update!");
	}

    void FixedUpdate()
    {
        Debug.Log("Hello FixedUpdate!");
    }

    void LateUpdate()
    {
        Debug.Log("Hello LateUpdate!");
    }
运行得以下结果：
![基本行为][1]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;其中，Awake（）函数在所有对象被初始化之后调用；Start（）函数仅在Update（）函数第一次被调用前调用；当MonoBehaviour启用时，其Update（）函数和FixedUpdate（）函数在每一帧被调用，但两者帧长不同；LateUpdate（）函数在所有Update（）函数调用后被调用。


----------
**4.查找脚本手册，了解 GameObject，Transform，Component 对象**

**（1）分别翻译官方对三个对象的描述（Description）**
GameObject：Unity场景中所有实体的基类。
Transform：物体的位置、旋转和比例。
Component：所有附属于游戏对象的基类。

**（2）描述下图中 table 对象（实体）的属性、table 的 Transform 的属性、 table 的部件
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;·本题目要求是把可视化图形编程界面与 Unity API 对应起来，当你在 Inspector 面板上每一个内容，应该知道对应 API。
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;·例如：table 的对象是 GameObject，第一个选择框是 activeSelf 属性。**
![此处输入图片的描述][2]


table的属性有activSelf、Cube（Mesh Filter）、Box Collider和Mesh Renderer；
table 的 Transform 的属性有Position、Rotation和Scale；
table 的部件有chair1，chair2，chair3和chair4。

**（3）用 UML 图描述 三者的关系（请使用 UMLet 14.1.1 stand-alone版本出图）**
![此处输入图片的描述][3]


----------
**5.整理相关学习资料，编写简单代码验证以下技术的实现：**

 - 查找对象
 - 添加子对象
 - 遍历对象树
 - 清除所有子对象
 

代码如下：

     public GameObject chair;
    
    // Use this for initialization
    void Start () {
        //查找对象
        chair = GameObject.Find("chair1");
        Debug.Log("I find " + chair.name + "!");

        //添加子对象
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = "chair4";
        cube.transform.position = new Vector3(-2, 0, 0);
        cube.transform.parent = this.transform;

        //遍历对象树
        Object[] objList = FindObjectsOfType(typeof(Transform));
        int i;
        for(i = 0;i < objList.Length;i++)
        {
            Debug.Log("traverse: " + objList[i].name);
        }

        //清除所有子对象
        for (i = 0; i < this.transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;运行前，游戏对象树如下图所示：
  ![此处输入图片的描述][4]
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;运行后，可见对象chair1被查找到，对象chair4被增加到table中，对象树得到遍历，最后table中的子对象被全部删除。
  ![此处输入图片的描述][5]
  

----------
**6.资源预设（Prefabs）与 对象克隆 (clone)**

**（1）预设（Prefabs）有什么好处？**
预设的好处：可以使多个对象整体化，方便多次使用与克隆。

**（2）预设与对象克隆 (clone or copy or Instantiate of Unity Object) 关系？**
对象克隆是实例化的预设。

**（3）制作 table 预制，写一段代码将 table 预制资源实例化成游戏对象**
制作好的预设如下，放入Assets的Resources文件夹中
![此处输入图片的描述][6]

实例化代码如下：

    void Start () {
        //将 table 预制资源实例化成游戏对象
        GameObject table = (GameObject)Instantiate(Resources.Load("table"));
        table.transform.parent = this.transform;
    }
![此处输入图片的描述][7]
  运行后container中克隆出实例化的table游戏对象。
  


----------
**尝试解释组合模式（Composite Pattern / 一种设计模式）。使用 BroadcastMessage() 方法
向子对象发送消息**
组合模式：将对象组合成树形结构以表示“部分-整体”的层次结构。
父对象代码如下：

    void Start () {
        //向子对象发送消息
        BroadcastMessage("ApplyMessage", "hello");   
    }

子对象代码如下：

    void ApplyMessage(string message)
    {
        Debug.Log(message + " " + this.transform.name);
    }
 
 运行后得到如下结果，各子对象接收广播并进行相应的处理。  
![此处输入图片的描述][8]


  [1]: https://wx4.sinaimg.cn/mw690/6b7386f7ly1fpoz3nn0xqj216j0hqgnk.jpg
  [2]: https://pmlpml.github.io/unity3d-learning/images/ch02/ch02-homework.png
  [3]: https://wx2.sinaimg.cn/mw690/6b7386f7ly1fpp1scwjeej208e0baq2y.jpg
  [4]: https://wx3.sinaimg.cn/mw690/6b7386f7ly1fpp4dpr3nwj21hc0swn5i.jpg
  [5]: https://wx2.sinaimg.cn/mw690/6b7386f7ly1fpp4dpm7p6j21hc0swjxw.jpg
  [6]: https://wx3.sinaimg.cn/mw690/6b7386f7ly1fpp64e6rb3j216j085jry.jpg
  [7]: https://wx1.sinaimg.cn/mw690/6b7386f7ly1fpp6cpktf2j21hc0sw7bc.jpg
  [8]: https://wx2.sinaimg.cn/mw690/6b7386f7ly1fpp9kt5cd7j21hc0sw444.jpg