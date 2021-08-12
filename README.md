# DisplaySharp
Minimal display lib for C# based on libdrm  
基于libdrm的精简C#图形库  

[![NuGet version (DisplaySharp)](https://img.shields.io/nuget/v/DisplaySharp.svg?style=flat)](https://www.nuget.org/packages/DisplaySharp/)

## What is this 是什么
This is a graphic lib for C# to do basic graphic things, like drawing rectangles or display a Bitmap on screen.  
这是为C#设计的基础图形库，比如说可以绘制矩形，或是将一张Bitmap显示在屏幕上。

## Setup 安装
First, you should install libdrm (and ofcource [dotnet5 runtime](https://docs.microsoft.com/dotnet/core/install/linux)) on your linux system:  
首先，在你的linux系统中安装libdrm(当然也要安装[dotnet环境](https://docs.microsoft.com/dotnet/core/install/linux)):
```
apt install libdrm-dev
```
  
Then make sure you have your build tools:  
然后确保你安装了构建工具:
```
apt install make gcc
```

For using Bitmap related features, you also need libgdiplus:  
要使用Bitmap相关功能，你还需要libgdiplus:
```
apt install libgdiplus
```

You have git installed, don't you?    你应该装了git对吧?

Clone the native part of the lib , build and install it:  
克隆本项目的native部分，构建并安装它:
```
git clone https://github.com/MicrostormSoft/DisplaySharp-Native.git
cd DisplaySharp-Native
make
make install
```

Then just import the nuget package of this repo into your dotnet project. Done.  
然后把这个项目的nuget包导入到你的.net项目里，就完成了。

## How to use 如何使用
```csharp
static void Main(string[] args)
{
    var canvas = new Canvas("/dev/dri/card0");//open your display device
    Bitmap picture = (Bitmap)Bitmap.FromFile("test.png");//read a picture as bitmap
    canvas.DrawBitmap(picture);//draw it onto the screen
    canvas.DrawRectangle(new Rectangle(100, 100, 50, 50), Color.Blue, fill: false);
      //draw a rectangle wire frame at Point(100,100) Size(50,50) in blue
    Console.ReadLine();
    canvas.Clear(Color.White);//clear the screen
    Console.ReadLine();
}
```
