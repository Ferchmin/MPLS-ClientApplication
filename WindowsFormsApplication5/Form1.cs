﻿using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows.Forms;
using System.Xml;

namespace ClientApplication
{
    public partial class Form1 : Form
    {

        #region Private Variables
        private string cloudIpAddress;
        private int cloudPortNumber;
        private string localIpAddress;
        private int localPortNumber;
        private int label;
        //Table, which contains words from our message
        string[] words;
        //Identifier to words table
        private int idWords = 0;
        private int logId = 1;
        private int clientNumber;
        private string logRegisterFilepath;
        private int packetId = 1;
        private string word;
        int labelAmmount;
        int[] labelReceiver;
        byte[] packet;
       List<int> lstLabelReceiver = new List<int>();
       List<string> lstIpAdressReceiver = new List<string>();
       List<string> lstNicknames = new List<string>();
        //Generator, which is used to send data package continously with 4 seconds delay
        System.Timers.Timer GeneratorsTimer = new System.Timers.Timer();
        string nickname;
       PortClass pc;
       

        #endregion Private Variables

        #region Public Properties
        public string CloudIpAddress
        {
            get { return cloudIpAddress; }
            set {cloudIpAddress = value; }
        }
        public int CloudPortNumber
        {
            get { return cloudPortNumber; }
            set { cloudPortNumber = value; }
        }
        public string LocalIpAddress
        {
            get { return localIpAddress; }
            set { localIpAddress = value; }
        }
        public int LocalPortNumber
        {
            get { return localPortNumber; }
            set { localPortNumber = value; }
        }
        public int Label
        {
            get { return label; }
            set { label = value; }
        }
        public string[] Words
        {
            get { return words; }  
        }
        public string LogRegisterFilepath
        {
             get { return logRegisterFilepath; }
             
        }

        #endregion Public Properties

        #region Methods
        //Method, which writes log to a file
        private void WriteLogs(string logDescription)
        {


            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(logRegisterFilepath, true))
            {

                file.WriteLine(logId + " " + cloudIpAddress + " " + DateTime.Now.ToString("hh:mm:ss") + " " + logDescription);
                ++logId;
            }
        }
        #endregion Methods

        public Form1()
        {
        InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Method used to read Xmlfiles 
        private void btnLoadConfig_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.FileName = tbFilePath.Text;
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(ofd.FileName);
            }
            catch
            {
                MessageBox.Show("No such file or directory");
               
            }


            //Loading parametrese
            clientNumber = Int32.Parse(xDoc.SelectSingleNode("clientConfig/Data/clientNumber").InnerText);
            logRegisterFilepath = String.Format("LogsRegister{0}.txt", clientNumber);
            cloudIpAddress = xDoc.SelectSingleNode("clientConfig/Data/cloudIpAddress").InnerText;
            cloudPortNumber = Int32.Parse(xDoc.SelectSingleNode("clientConfig/Data/cloudPortNumber").InnerText);
            localIpAddress = xDoc.SelectSingleNode("clientConfig/Data/localIpAddress").InnerText;
            localPortNumber = Int32.Parse(xDoc.SelectSingleNode("clientConfig/Data/localPortNumber").InnerText);
            label = Int32.Parse(xDoc.SelectSingleNode("clientConfig/Data/label").InnerText);
            labelAmmount = Int32.Parse(xDoc.SelectSingleNode("clientConfig/Data/labelAmmount").InnerText);


            for (int i = 0; i < labelAmmount; i++)
            {
                string path = String.Format("clientConfig/Data/pair{0}/labelReceiver", i);
                int value = Int32.Parse(xDoc.SelectSingleNode(path).InnerText);

                lstLabelReceiver.Add(value);

            }
            for (int i = 0; i < labelAmmount; i++)
            {
               string path = String.Format("clientConfig/Data/pair{0}/ipAddressReceiver", i);
               string value = xDoc.SelectSingleNode(path).InnerText;
               cbSwitchReceiver.Items.Add(value);
               lstIpAdressReceiver.Add(value);
            }
            for (int i = 0; i < labelAmmount; i++)
            {
                string path = String.Format("clientConfig/Data/pair{0}/nickName", i);
                string value = xDoc.SelectSingleNode(path).InnerText;
                lstNicknames.Add(value);
            }

            pc = new PortClass(localIpAddress, localPortNumber, cloudIpAddress, cloudPortNumber, this);
            MessageBox.Show("Config has been loaded." + Environment.NewLine +  "Choose reciever in order to find proper label");
            WriteLogs("Client Application has been initialized");

        }
        //Button which switch labels
        private void btnLabelSwitch_Click(object sender, EventArgs e) 
        {
            for (int i = 0; i < labelAmmount; ++i)
            if (cbSwitchReceiver.Text == lstIpAdressReceiver[i])
            {
               label = lstLabelReceiver[i];
               MessageBox.Show(label.ToString());
                  
                }

        }

        private void btnEnableDataFlow_Click(object sender, EventArgs e)
        {
            // char[] delimiterChars = { ' ', ',', '.', ':' };
            string message = tbMessage.Text;
            // MessageBox.Show(word);
            int messageLength = message.Length;
            int[] mpls_label = { label };

            lstMessage.Items.Add("Our Department"  + ": " + message);
            ++packetId;

            MPLSPacket newPacket = new MPLSPacket();
            packet = newPacket.CreatePacket(1, 1, (ushort)label, localIpAddress, cbSwitchReceiver.Text, (ushort)messageLength, message);
            WriteLogs("Message has been sent. Message text: " + message);
        
             pc.SendMyPacket(packet);
        }




        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            { WriteLogs("Client Application has been shut down");
            }
            catch
            {

            }
        }


       public void ShowReceivedData(byte[] receivedPacket)
        {
            MPLSPacket test = new MPLSPacket(receivedPacket);

            test.ReadIpHeader();
            test.ReadDataHeader();
            test.ReadData();

            //ip adres zrodla -test.IpSource;
            //wiadomosc - test.Data;
           // string nickname;
            for  (int i = 0; i < labelAmmount; ++i)
            if (test.IpSource == lstIpAdressReceiver[i])
            nickname = lstNicknames[i];
                    

            string messageToDisplay = nickname + ": " + test.Data;
            this.Invoke(new MethodInvoker(delegate () { lstMessage.Items.Add(messageToDisplay); }));
            //wyswietlanie na kontrolkach
            WriteLogs("Recieved message from: " + nickname + ". Data: "  + test.Data);
        }

    }
    }

