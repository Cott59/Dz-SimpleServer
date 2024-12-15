using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpleServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // localhost 127.0.0.1 10.1.100.164 188.226.58.226
            // ip сервера
            IPAddress ip = IPAddress.Parse("127.0.0.1");//95.26.72.198  "10.1.100.164"
            // port сервера
            int _port = 3000;
            // Конечная точка подключения
            IPEndPoint ep = new IPEndPoint(ip, _port);
            // Сокет: конечная точка подключения, семейство адресов, тип сокета и протокол
            Socket socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.IP);
            // Создаём принимающий сокет
            socket.Bind(ep);
            // 20 - размер очереди ожидающих обработки подключений
            socket.Listen(20);
            try
            {
                // бесконечный цикл прослушивания
                while (true)
                {
                    // Создание сокета для подключения и
                    // блокировка потока выполнения программы
                    Socket newSocket = socket.Accept();
                    string _clientIP = newSocket.RemoteEndPoint.ToString();
                    string _timeStamp = DateTime.Now.ToString();
                    var countDisk = DriveInfo.GetDrives();
                    hostData hd = new hostData();
                    var gg = hd.Getlist(); 
                    // ip удалённого подключения
                    Console.WriteLine($"{_timeStamp} {_clientIP}") ;
                    // Отправка ответа
                    newSocket.Send(Encoding.ASCII.GetBytes($"Now is {_timeStamp}, you IP = {_clientIP}, Counter Disk: {countDisk.Length} "));
                    foreach ( var g in gg )
                    {
                        newSocket.Send(Encoding.ASCII.GetBytes(g));
                    }
                    


                    // Завершаем установленное соединение и освобождаем ресурсы
                    newSocket.Shutdown(SocketShutdown.Both);
                    newSocket.Close();
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
