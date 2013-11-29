using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using DAL;
using Business;
using Service;

namespace AuthenticationServerConsole
{

    public class MultiThreadingAuthenticateChild
    {
        private Socket authenticateSocket = null;

        public MultiThreadingAuthenticateChild(Socket _socket)
        {
            authenticateSocket = _socket;
        }
    
        public void MultiThreadingAuthenticateChildMethod()
        {
            Int32 _port = 9357;
            bool authenticated = false;

            try
            {
                Console.WriteLine(_port + " (child authentication): connection established...");
                // get a stream to read/write
                //NetworkStream stream = tcpClient.GetStream();
                NetworkStream stream = new NetworkStream(authenticateSocket);

                // read the data sent by the client.
                BinaryReader reader = new BinaryReader(stream);
                BinaryWriter writer = new BinaryWriter(stream);
                string loginUN = reader.ReadString();
                string loginPW = reader.ReadString();
                Console.WriteLine(_port + " (child authentication): credentials... " + loginUN + "...");


                User user1 = new UserMgr().RetrieveUser("UserName", loginUN);

                if (user1 != null)
                {
                    if (user1.UserName == loginUN)
                    {
                        if (user1.Password == loginPW)
                        {
                            authenticated = true;
                        }
                    }
                }
                if (authenticated)
                    Console.WriteLine(_port + " (child authentication): access granted for " + loginUN + "...");
                else
                    Console.WriteLine(_port + " (child authentication): acces denied for " + loginUN + "...");
                writer.Write(authenticated);
            }

            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
            finally
            {
                // close socket
                authenticateSocket.Close();
            }
        }
    }
    
    
    
    public class ThreadingAuthenticate
    {

        public ThreadingAuthenticate()
        { }
        
        
        public void ThreadingAuthenticateMethod()
        {
        
            TcpListener listener = null;
            try
            {
               // IUserSvc userSvc = new UserSvcRepoImpl();
                
               // Int32 port = 9357;
                Int32 _port = 9357;
                IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
                listener = new TcpListener(ipAddr, _port);
                // Start listening for incoming client requests
                listener.Start();
                while (true)
                {
                   
                    Console.WriteLine(_port + " (main authentication): Waiting for a connection...");
                   // TcpClient tcpClient = listener.AcceptTcpClient();
                    Socket socket = listener.AcceptSocket();
                    MultiThreadingAuthenticateChild authenticateChildThread = new MultiThreadingAuthenticateChild(socket);
                    Thread childThread = new Thread(new ThreadStart(authenticateChildThread.MultiThreadingAuthenticateChildMethod));
                    childThread.Start();
                   
                }
                    
            }
            
            // process the credentials and return a true / false
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
            finally
            {
                // Stop listening for new clients
                listener.Stop();
              
            }
        
        }

    }

    public class MultiThreadingRegisterChild
    {
        private Socket registerSocket = null;

        public MultiThreadingRegisterChild(Socket _socket)
        {
            registerSocket = _socket;
        }

        public void MultiThreadingRegisterChildMethod()
        {
            Int32 _port = 9357;

            //initize registeredUser to false and if a user is registered, it will be set to true. 
            //This is returned to client to indicate if user is registered
            bool registeredUser = false;

            try
            {

                Console.WriteLine(_port + " (child registration): connection established...");

                // get a stream to read/write
                //NetworkStream stream = tcpClient.GetStream();
                NetworkStream stream = new NetworkStream(registerSocket);

                // read the data sent by the client.
                BinaryReader reader = new BinaryReader(stream);
                BinaryWriter writer = new BinaryWriter(stream);
                string incommingUN = reader.ReadString();
                string incommingPW = reader.ReadString();
                Console.WriteLine(_port + " (child registration): credentials received for " + incommingUN + "...");

                //retrieve a user with set username...
                User checkUserName = new UserMgr().RetrieveUser("UserName", incommingUN);

                //if checkUserName is null, then no user was found iwth the requested username
                //and therefore can be used to create a new user
                if (checkUserName == null)
                {
                    User user1 = new User(incommingUN, incommingPW);
                    new UserMgr().CreateUser(user1);

                    //set registeredUser to true since this wil be returned back to the client
                    registeredUser = true;

                }
                if (registeredUser)
                    Console.WriteLine(_port + " (child registration): Registration successful for " + incommingUN + "...");
                else
                    Console.WriteLine(_port + " (child registration): Registration failed for " + incommingUN + "...");

                //return to the client whether we retistered a new user or not
                writer.Write(registeredUser);
            }

            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
            finally
            {
                // close socket
                registerSocket.Close();
            }

        }
    }

    public class ThreadingRegister
    {
        private Socket _socket = null;

        public ThreadingRegister()
        { }
        


        //thread for registering a new user
        public void ThreadingRegisterMethod()
        {

            
            TcpListener listener = null;
            try
            {

                Int32 _port = 9358;
                IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
                listener = new TcpListener(ipAddr, _port);
                // Start listening for incoming client requests
                listener.Start();
                while (true)
                {


                    Console.WriteLine(_port + " (main registration): Waiting for a connection...");
                    //TcpClient tcpClient = listener.AcceptTcpClient();
                    Socket socket = listener.AcceptSocket();
                    MultiThreadingRegisterChild registerChildThread = new MultiThreadingRegisterChild(socket);
                    Thread childThread = new Thread(new ThreadStart(registerChildThread.MultiThreadingRegisterChildMethod));
                    childThread.Start();
                   
                }
            }

            // process the credentials and return a true / false
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients
                listener.Stop();
            }

        }
    }

    public class Listener
    {

        static void Main(string[] args)
        {
            
            //Create thread for authenticating a user
            ThreadingAuthenticate threadingAuthinticate = new ThreadingAuthenticate();
            //authenticateThreading.init(9357);
            Thread authenticateThread = new Thread(new ThreadStart(threadingAuthinticate.ThreadingAuthenticateMethod));
            authenticateThread.Name = String.Format("Authenticate Main Thread ");
            
            //start authenticate thread
            Console.WriteLine("starting " + authenticateThread.Name);
            authenticateThread.Start();
                
            //create thread for registering a user
            ThreadingRegister threadingRegister = new ThreadingRegister();
            //registerThreading.init(9358);
            Thread registerThread = new Thread(new ThreadStart(threadingRegister.ThreadingRegisterMethod));
            registerThread.Name = String.Format("Register Main Thread ");
            
            //start register thread
            Console.WriteLine("starting " + registerThread.Name);
            registerThread.Start();

        }
    }


}

    

