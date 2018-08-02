# MultiLanguageForXAML
针对WPF和UWP的通用多语言支持库

## 效果预览
* **WPF**

![steup](https://raw.githubusercontent.com/DaZiYuan/MultiLanguageForXAML/master/screenshots/WPF.gif)


* **UWP**

![steup](https://github.com/DaZiYuan/MultiLanguageForXAML/blob/master/screenshots/UWP.gif?raw=true)

## 用法

* **定义语言文件**
 ```json
  //zh.json
    {"txt": "一"}

//en.json
    {"txt": "one"}
 ```
* **初始化**
```csharp
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, "Languages");
            LanService.Init(new JsonDB(path), true);
```

* **XAML**
```XAML

<Window
    ...
    xmlns:lan="clr-namespace:MultiLanguageManager;assembly=MultiLanguageManager.WPF">
            <Button lan:Xaml.Key="txt" />
</Window/>

```
