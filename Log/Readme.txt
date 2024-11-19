使用:
1.菜单页找到 ‘Tools/DebugerConfig’ 打开配置窗口.
2.初始无配置文件,点击‘创建’.
	读取路径配置于DebugerConfigLoader类中,使用Resources读取.
3.选择正确的文件路径,文件名及后缀无需修改.
4.在窗口中进行配置操作,配置完成后应当点击‘计算遮罩并保存’.
	不支持删除操作,如果需要删除,找到创建的DebugerConfig资源,手动删除。
5.将Log/Demo下的DebugerDemo.cs拖到场景上进行案例使用.

说明:
1.Debuger是一个静态工具类
	调用DebugerComponent及其及子类,可以按需求修改。
2.DebugerConfigLoader类,配置了从Resources中读取配置的路径,非必要不用动.
3.Component
	实现了两个组件类,其由Debuger调用
	1) DebugerComponent
		当调用Log方法时即刻输出。
		用于编辑器模式/主线程运行时。
	2) QueueDebugerComponent
		当调用Log方法时被加入一个队列,等待调用LogOut方法后一次输出。
		用于发布运行时/非主线程运行时。
4.写日志
	写日志文件的功能未给予实现。
	应当在Debuger上使用QueueDebugerComponent按项目实现,或者写一个Component的子类。

命名:
    MaskFlag: 遮罩标记 数个'位掩码'|运算得到值.
    BitMask: 位掩码 例如1<<2操作后得到的值.
    ShiftAmount: 操作量 例如1<<2操作中的2.

尾注:
	输出int值二进制字符串: Convert.ToString(int, 2).PadLeft(32, '0')