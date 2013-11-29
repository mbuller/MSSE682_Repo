using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Service
{
    public partial class AuthenticationSvcSocketImpl : IAuthenticationSvc
    {
        //TcpClient tcpClient;
        //Socket socket;
        //IPEndPoint endPoint;
      //  public IUserSvc userSvc;
       
            
        
        public AuthenticationSvcSocketImpl()
        {
         //   userSvc = new UserSvcRepoImpl();
          //  tcpClient = new TcpClient();

            //socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //endPoint = new IPEndPoint(IPAddress.Parse("127.0.01"), 8081);
        }

        public bool AuthenticateUser(String UserName, String Password)
        {
            
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.01"), 9357);
                socket.Connect(ipEndPoint);
                NetworkStream stream = new NetworkStream(socket);
                BinaryWriter writer = new BinaryWriter(stream);
                BinaryReader reader = new BinaryReader(stream);
                writer.Write(UserName);
                writer.Write(Password);
                
                return reader.ReadBoolean();

            }
            catch(SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients
                //listener.Stop();
            }
            
            return false;
        }

        public bool RegisterUser(String UserName, String Password)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.01"), 9358);
                socket.Connect(ipEndPoint);
                NetworkStream stream = new NetworkStream(socket);
                BinaryWriter writer = new BinaryWriter(stream);
                BinaryReader reader = new BinaryReader(stream);
                writer.Write(UserName);
                writer.Write(Password);

                return reader.ReadBoolean();

            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (Exception e)
            {
                Console.WriteLine("general Exception: {0}", e);
            }
            finally
            {
                // close socket
                socket.Close();
            }

            return false;
        }
    }
}
