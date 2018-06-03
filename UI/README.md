视频地址：[UI场景][1]

&nbsp;&nbsp;对话框的弹出与消失用动画机实现：

![动画机][2]

其中，Bubble为对话框变大的动画，big为对话框保持大状态的动画，DeleteBubble为对话框消失的动画。

“big”触发时，对话框变大，然后保持大的状态；“small”触发时，对话框消失，回到“New State”，等待下一次“big”的触发。


  [1]: http://t.cn/R1Q5xTZ?m=4247001082870687&u=1802733303
  [2]: https://wx3.sinaimg.cn/mw690/6b7386f7ly1fryiiw9kn7j20j10d3q3z.jpg
