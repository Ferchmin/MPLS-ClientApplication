using System;
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
       private  string localIpAddress;
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
        List<int> lstLabelReceiver = new List<int>();
        List<string> lstIpAdressReceiver = new List<string>();
        //Generator, which is used to send data package continously with 4 seconds delay
        System.Timers.Timer GeneratorsTimer = new System.Timers.Timer();

        PacketClass pc = new PacketClass();
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
        private void WriteLogs(int whichLog)
        {
            switch (whichLog)
            {
                case 1:
                    {
                        using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(logRegisterFilepath, true))
                        {

                            file.WriteLine(logId + " " + cloudIpAddress + " " + DateTime.Now.ToString("hh:mm:ss") + " " + "ClientNodle (IP:" + cloudIpAddress + ") connected to our network");
                            ++logId;
                        }
                        break;
                    }
                  case 2:
                    {
                        using (System.IO.StreamWriter file =
                         new System.IO.StreamWriter(logRegisterFilepath, true))
                        {

                            file.WriteLine(logId + " " + cloudIpAddress + " " + DateTime.Now.ToString("hh:mm:ss") + " " + "Sent data package: " + word + " with label: " + label);
                            ++logId;
                        }
                        break;
                    }
                case 3:
                    {
                        using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(logRegisterFilepath, true))
                        {

                            file.WriteLine(logId + " " + cloudIpAddress + " " + DateTime.Now.ToString("hh:mm:ss") + " " + "Data successfully sent");
                            ++logId;
                        }
                        break;
                    }
                  case 4:
                    {
                        using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(logRegisterFilepath, true))
                        {

                            file.WriteLine(logId + " " + cloudIpAddress + " " + DateTime.Now.ToString("hh:mm:ss") + " " + "That Client is no longer available");
                            ++logId;
                        }
                        break;
                    }


                    
            }
        }
        #endregion Methods

        public Form1()
        {
        InitializeComponent();
            labelReceiver = new int[2];
          //  = new List<int>();
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
            xDoc.Load(ofd.FileName);


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
              //  labelReceiver[i] = value;
                lstLabelReceiver.Add(value); 
            }

            for (int i = 0; i < labelAmmount; ++i)
            {
               string path = String.Format("clientConfig/Data/pair{0}/ipAddressReceiver", i);
               string value = xDoc.SelectSingleNode(path).InnerText;
               cbSwitchReceiver.Items.Add(value);
               lstIpAdressReceiver.Add(value);
            }








            MessageBox.Show("Config has been loaded." + Environment.NewLine +  "Choose reciever in order to find proper label");
            WriteLogs(1);


        }
        //Button which switch labels
        private void btnLabelSwitch_Click(object sender, EventArgs e) 
        {

            for (int i = 0; i < labelAmmount; ++i)
                if (cbSwitchReceiver.Text == lstIpAdressReceiver[i])
            {
                label = lstLabelReceiver[i];
            }

            



        }

        private void btnEnableDataFlow_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { ' ', ',', '.', ':' };
            string text = tbMessage.Text;
            words = text.Split(delimiterChars);

            GeneratorsTimer.AutoReset = true;
            GeneratorsTimer.Enabled = true;
            GeneratorsTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            GeneratorsTimer.Interval = 6000;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {

           

           
            if (idWords == words.Length)
            {
                MessageBox.Show("Whole data succesfully sent");
                
                WriteLogs(3);
                //GeneratorsTimer.Dispose();
                GeneratorsTimer.Enabled = false;
            }
            else
            {
                word = words[idWords];
                ++idWords;
                WriteLogs(2);
                // MessageBox.Show(word);
                int[] mpls_label = { label };
                pc.CreatePacket(packetId, cloudPortNumber, 1, mpls_label, word);
                ++packetId;

                
            }  


            
          
        }

        private void btnDisableDataFlow_Click(object sender, EventArgs e)
        {
            GeneratorsTimer.Enabled = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
             WriteLogs(4);
        }
      
    }
    }

