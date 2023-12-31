***重要提示：AI生成内容 - 本文档由ChatGPT-4从英文版本翻译而来。***

# Revertible 可还原
方便定义具有**可还原属性**的类。

- [Revertible 可还原](#revertible-可还原)
  - [功能](#功能)
  - [用例](#用例)
  - [工作原理](#工作原理)
    - [状态图 / 时间线](#状态图--时间线)
  - [UML类图](#uml类图)
  - [示例代码](#示例代码)

## 功能
- **[可还原]** 属性：标记类中的属性为可还原。
- **SaveRevertibleProperties()**：保存可还原属性的当前值。
- **RevertRevertibleProperties()**：将可还原属性恢复到已保存的值（如果有）。
- **HasModifiedRevertibleProperties**（布尔值）：表示任何可还原属性的值是否已更改。

## 用例
非常适合于需要简单还原所有更改值的场景，如用户修改的设置，无需将更改保存到模型或文件中。

## 工作原理
### 状态图 / 时间线
在实例化扩展了**BaseRevertible**并包含了用**[Revertible]** 注释的属性的类型后，您可以保存可还原属性的当前状态，以便在需要时还原它们。

如下图所示，在状态5，当调用还原方法时，值将被还原/设置回状态3（t2 == t1）时保存的值。

**注意：**没有**[Revertible]**注释的属性将始终被忽略。

![状态图](Timeline.drawio.png)

## UML类图
要使您的类可还原，只需扩展**BaseRevertible**并使用**[Revertible]**属性注释您希望可还原的属性：

![UML类图](Klassendiagramm.png)

## 示例代码
以下是使类可还原的简单示例：
```cs
使用 Revertible；

// 将[Revertible]分配给类是可选的，
// 除非您需要在类外部访问 IRevertible 方法。
[Revertible]
public class RevertibleClass : BaseRevertible
{
    // 只需将[Revertible]分配给您希望保存和还原的属性。
    [Revertible]
    public bool Enabled { get; set; }

    [Revertible]
    public int ID { get; set; }

    [Revertible]
    public string Name { get; set; }

    [Revertible]
    public object SomeObject { get; set; }

    // 未注释[Revertible]的属性将被忽略
    public double NonRevertibleDoubleProperty { get; set; }
    public char NonRevertibleCharProperty { get; set; }
}

/*** 保存和还原值 ***/
// 
private RevertibleClass _revertibleField = new RevertibleClass();

private void SomeMethod()
{
    _revertibleField.Enabled = true;
    _revertibleField.Name = "John Doe";

    // 保存可还原属性的当前状态：
    _revertibleField.SaveRevertibleProperties();

    // 一些其他代码...
    _revertibleField.Enabled = false;
    _revertibleField.Name = "Something else!";

    // 还原可还原属性的值：
    _revertibleField.RevertRevertibleProperties();
    // 现在：Enabled == true 和 Name == "John Doe"。
}
```
