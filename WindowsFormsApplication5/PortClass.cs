using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientApplication
{
    class PortClass
    {
        Socket client;
        IPEndPoint clientIpEndPoint;
        IPEndPoint cloudIPEndPoint;
        EndPoint cloudEndPoint;

        byte[] buffer;
        byte[] receivedPacket;
        byte[] packet;
        string myIpAddress;
        int myPort;

        string cloudIpAddress;
        int cloudPort;

        Form1 form;


        /*
        * Konstruktor - wymaga podania zmiennych pobranych z pliku konfiguracyjnego
        */
        public PortClass(string myIpAddress, int myPort, string cloudIpAddress, int cloudPort, Form1 cos)
        {
            InitializeData(myIpAddress, myPort, cloudIpAddress, cloudPort, cos);
            InitializeSocket();
        }

        /*
        * Metoda odpowiedzialna za przypisanie danych do lokalnych zmiennych.
        */
        private void InitializeData(string myIpAddress, int myPort, string cloudIpAddress, int cloudPort, Form1 cos)
        {
            this.myIpAddress = myIpAddress;
            this.myPort = myPort;
            this.cloudIpAddress = cloudIpAddress;
            this.cloudPort = cloudPort;

            this.form = cos;
        }

        /*
        * Metoda odpowiedzialna za inicjalizację nasłuchiwania na przychodzące wiadomośći.
        */
        private void InitializeSocket()
        {
            //tworzymy gniazdo klienckie
            client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            clientIpEndPoint = new IPEndPoint((IPAddress.Parse(myIpAddress)), myPort);
            client.Bind(clientIpEndPoint);

            //tworzymy punkt końcowy chmury kablowej
            cloudIPEndPoint = new IPEndPoint((IPAddress.Parse(cloudIpAddress)), cloudPort);
            cloudEndPoint = (EndPoint)cloudIPEndPoint;

            //tworzymy bufor nasłuchujący
            buffer = new byte[1024];

            //rozpoczynamy nasłuchiwanie na przychodzące wiadomości
            client.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref cloudEndPoint, new AsyncCallback(ReceivedPacket), null);
        }

        /*
        * Metoda odpowiedzialna za inicjalizowanie wysyłania własnego pakietu przez węzeł kliencki.
        * - metoda publiczna, wywoływana przez inne klasy w celu nadania wiadomosćil;
        */
        public void SendMyPacket(byte[] myPacket)
        {
            //przypisujemy pakiet do zmiennej lokalnej
            packet = myPacket;

            //rozpoczynamy wysyłanie danych do chmury kablowej
            client.BeginSendTo(packet, 0, packet.Length, SocketFlags.None, cloudEndPoint, new AsyncCallback(SendPacket), null);
        }

        /*
        * Metoda odpowiedzialna za ukończenie wysyłania pakietu.
        * - tutaj generowany będzie log z wydarzenia;
        */
        public void SendPacket(IAsyncResult res)
        {
            //kończymy wysyłanie pakietu - funkcja zwraca rozmiar wysłanego pakietu
            int size = client.EndSendTo(res);

        }

        /*
        * Metoda odpowiedzialna za ukończenie odbierania pakietu.
        * - tutaj generowany będzie log z wydarzenia;
        * - tutaj przesyłamy otryzmany pakiet do wewnętrznej metody odpowiedzialnej za przetwarzanie
        */
        private void ReceivedPacket(IAsyncResult res)
        {
            //kończymy odbieranie pakietu - metoda zwraca rozmiar faktycznie otrzymanych danych
            int size = client.EndReceiveFrom(res, ref cloudEndPoint);

            //tworzymy tablicę zawierającą jedynie dane odebrane, czyli pakiet
            receivedPacket = new byte[size];
            Array.Copy(buffer, receivedPacket, receivedPacket.Length);

            //wyjmujemy ze zmienionego cloudEndPointa wartość adresu ip oraz portu nadawcy
            IPEndPoint receivedEndPoint = (IPEndPoint)cloudEndPoint;

            //generujemy logi
            //Console.WriteLine("Otrzymaliśmy pakiet od: " + receivedEndPoint.Address + " port " + receivedEndPoint.Port);
            //Console.WriteLine("Pakieto to: " + Encoding.UTF8.GetString(receivedPacket));

            //wysyłamy otrzymany pakiet do metody przetwarzającej
            ProcessReceivedPacket(receivedPacket);

            //czyścimy bufor
            buffer = new byte[1024];

            //rozpoczynamy nasłuchiwanie od nowa
            client.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref cloudEndPoint, new AsyncCallback(ReceivedPacket), null);

        }

        /*
        * Metoda odpowiedzialna za przetwarzanie odebranego pakietu.
        */
        private void ProcessReceivedPacket(byte[] receivedPacket)
        {
            //przesyłamy odbierany pakiet do innej klasy np przez zarzadcę, którego pewnie trzeba będzie dodać tutaj jego referncję,
            //trzeba jeszcze pomyśleć jak to tutaj zrobić aby ten otrzymany pakiet gdzies szedł w programie, gdzie on ma być docelowo ?
            //może trzeba dać tutaj delegata, ze jak przyjdzie taki pakiet to odpal funkcje u kogoś innego jakąs, pewnie to by było super

            form.ShowReceivedData(receivedPacket);
        }
    }
}