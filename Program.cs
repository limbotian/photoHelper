using System;
using System.Collections.Generic;
using System.IO;
//dotnet publish -c Release -r win10-x64
//dotnet-warp
namespace photoHelper
{
    class Program
    {
        private static String path = "./images/";
        private static List<String> imgs = new List<String>();

        static void Main(string[] args)
        {
            Console.WriteLine("程序开始！！！！！！");
            eachFiles(path);
            Console.WriteLine("程序结束！！！！！！");
            Console.Write("按任意键退出...");
            Console.ReadKey(true);
        }

        static void eachFiles(string path)
        {
            DirectoryInfo folder = new DirectoryInfo(path);

            foreach (FileInfo file in folder.GetFiles("*"))
            {
                if (imgs.Contains(file.Name))
                {
                    Console.WriteLine("字典中已存在 删除文件 :" + file.Name);
                    file.Delete();
                }else{
                    Console.WriteLine("字典中不存在 添加至字典 :" + file.Name);
                    imgs.Add(file.Name);
                }
            }
            foreach (DirectoryInfo file in folder.GetDirectories("*"))
            {
                Console.WriteLine("遍历子文件夹" + file.FullName);
                eachFiles(file.FullName);
            }
        }
    }
}
