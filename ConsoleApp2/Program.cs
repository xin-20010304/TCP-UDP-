﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 1;
            UdpClient client = new UdpClient(11000);
            string receiveString = null;
            byte[] receiveData = null;
            //实例化一个远程端点，IP和端口可以随意指定，等调用client.Receive(ref remotePoint)时会将该端点改成真正发送端端点 
            IPEndPoint remotePoint = new IPEndPoint(IPAddress.Any, 0);
            Console.WriteLine("正在准备接收数据...");
            while (true)
            {
                receiveData = client.Receive(ref remotePoint);//接收数据 
                receiveString = Encoding.Default.GetString(receiveData);
                Console.WriteLine(receiveString);
                if (result == 50)
                {
                    break;
                }

                result++;
            }
            client.Close();//关闭连接
            Console.WriteLine("");
            Console.WriteLine("数据接收完毕，按任意键退出...");
            System.Console.ReadKey();
        }
    }
}
