using System;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Spreadsheet.Charts;
using DevExpress.XtraCharts.Designer.Native;
using RJCP.IO.Ports;
using TanHungHa.Tabs;


namespace TanHungHa.Common
{
    public class SerialPortCommunication
    {
        /**/

        [Category("Other"), DescriptionAttribute("")]
        public string prefix { get; set; }
        [Category("Other"), DescriptionAttribute("")]
        public string suffix { get; set; }
        [Category("Other"), DescriptionAttribute("")]

        public int readTimeout { get; set; }
        [Category("Other"), DescriptionAttribute("")]
        public int writeTimeout { get; set; }
        [Category("Other"), DescriptionAttribute("")]
        public Parity parity { get; set; }
        [Category("Other"), DescriptionAttribute("")]
        public int dataBits { get; set; }
        [Category("Other"), DescriptionAttribute("")]
        public StopBits stopBits { get; set; }
        [Category("Other"), DescriptionAttribute("")]
        public Handshake handshake { get; set; }
        [Category("Other"), DescriptionAttribute("")]
        public bool isDTR { get; set; }
        [Category("Other"), DescriptionAttribute("")]
        public bool isRTS { get; set; }

        [Category("Other"), DescriptionAttribute("")]
        public string dataComport { get; set; }

        //public modeReadCOM modeRead { get; set; }

        [Category("Main"), DescriptionAttribute("Ký tự cần cắt khỏi chuỗi nhận được ví dụ Data là M1=234 cần lấy 234 thì đặt là M1=")]
        public string keyParseData { get; set; }
        [Category("Main"), DescriptionAttribute("Tên cổng kết nối nhận data Ví dụ COM1")]
        public string portName { get; set; }

        [Category("Main"), DescriptionAttribute("Tốc độ truyền dữ liệu giống với máy đo ví dụ 19200")]
        public int baudRate { get; set; }
        /**/

        private SerialPortStream serialPort;
        private byte[] receivedDataBuffer;
        private int receivedDataBufferIndex;
        public event EventHandler<byte[]> DataReceived;

        string strModeSend = "NORMAL";
        private readonly object balanceLock = new object();

        public bool isOpen = false;

        private static SerialPortCommunication _instance;
        private static readonly object _lock = new object();
        public static SerialPortCommunication GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SerialPortCommunication();
                    }
                }
            }
            return _instance;
        }


        public SerialPortCommunication Clone()
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(this);
            //MyLib.log(json);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SerialPortCommunication>(json);
        }

        public SerialPortCommunication()
        {
            dataComport = "";
            prefix = "";
            suffix = "";
            keyParseData = "M1=";

            portName = "COM1";
            baudRate = 9600;
            parity = Parity.None;
            dataBits = 8;
            stopBits = StopBits.One;
            handshake = Handshake.None;

            isDTR = false;
            isRTS = false;
            serialPort = null;
            readTimeout = writeTimeout = 500;
        }

   
        public void ClearData() {
            dataComport = "";
            dataComport = "";
        }
        public bool connect()
        {
            if (serialPort == null)
            {
                serialPort = new SerialPortStream(portName, baudRate, dataBits, parity, stopBits);
            }

            if (serialPort.IsOpen) {
                disConnect();
            }


            if (!serialPort.IsOpen)
            {

                serialPort.PortName = portName;
                serialPort.BaudRate = baudRate;
                serialPort.DataBits = dataBits;
                serialPort.StopBits = stopBits;
                serialPort.Parity = parity;
                serialPort.Handshake = handshake;

                serialPort.RtsEnable = isRTS;
                serialPort.DtrEnable = isDTR;

                serialPort.ReadTimeout = readTimeout;
                serialPort.WriteTimeout = writeTimeout;

                try { serialPort.Open(); } catch { return false; }
                receivedDataBuffer = new byte[serialPort.ReadBufferSize];
                receivedDataBufferIndex = 0;
                serialPort.DataReceived += SerialPort_DataReceived;
                
                this.isOpen = true;
            }

            return this.isOpen;
        }
        public bool disConnect()
        {
            if (serialPort.IsOpen)
            {
                serialPort.DataReceived -= SerialPort_DataReceived;
                serialPort.Close();

                this.isOpen = false;
            }

            return this.isOpen;
        }

        public bool getStatus()
        {
            if (serialPort == null)
            {
                return false;
            }
            else
            {
                return serialPort.IsOpen;
            }
        }

        public void Send(byte[] buffer, int offset, int count)
        {
            lock (balanceLock) {
                strModeSend = "NORMAL";
                try
                {
                    serialPort.Write(buffer, offset, count);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error sending data to serial port: " + ex.Message);
                }
            }
            
        }

        public byte[] Receive(int count)
        {
            byte[] buffer = new byte[count];
            int readCount = 0;
            while (readCount < count)
            {
                try
                {
                    int bytesRead = serialPort.Read(buffer, readCount, count - readCount);
                    if (bytesRead == 0)
                    {
                        throw new TimeoutException("Timeout waiting for data from serial port.");
                    }
                    readCount += bytesRead;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error receiving data from serial port: " + ex.Message);
                }
            }
            return buffer;
        }

        public void SendReceive(byte[] sendData, int sendOffset, int sendCount, 
            byte[] receiveData, int receiveOffset, int receiveCount)
        {
            lock (balanceLock)
            {
                strModeSend = "RECEIVE";

                try
                {
                    serialPort.Write(sendData, sendOffset, sendCount);
                    byte[] buffer = new byte[receiveCount];
                    int readCount = 0;
                    while (readCount < receiveCount)
                    {
                        int bytesRead = serialPort.Read(buffer, readCount, receiveCount - readCount);
                        if (bytesRead == 0)
                        {
                            throw new TimeoutException("Timeout waiting for data from serial port.");
                        }
                        readCount += bytesRead;
                    }
                    Array.Copy(buffer, 0, receiveData, receiveOffset, receiveCount);
                }
                catch{                  
                }

                strModeSend = "NORMAL";
            }
        }

        private void SerialPort_DataReceived(object sender, RJCP.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (strModeSend != "NORMAL") return;
            var tStart = DateTime.Now;
            int bytesToRead = serialPort.BytesToRead;

            if (bytesToRead > 0)
            {
                int bytesRead = serialPort.Read(receivedDataBuffer, receivedDataBufferIndex, bytesToRead);
                receivedDataBufferIndex += bytesRead;
                ProcessReceivedData();
                /*int queueSize_ = MyParam.commonParam.queueData.Count;
                if (queueSize_ > 0)
                {
                    var data_ = MyParam.commonParam.queueData.Dequeue();
                    FormAuto.dataPoints.Add(new FormAuto.DataPoint(DateTime.Now, Double.Parse(data_)));
                }*/
                var tStop = DateTime.Now;
                Console.WriteLine(tStop - tStart);
            }
        }

        private void ProcessReceivedData()
        {
            int endIndex = receivedDataBufferIndex - 1;
            int startIndex = 0;
            while (startIndex <= endIndex)
            {
                if (receivedDataBuffer[startIndex] == 0x01 && receivedDataBuffer[endIndex] == 0x03)
                {
                    int dataLength = endIndex - startIndex - 1;
                    byte[] receivedData = new byte[dataLength];
                    Array.Copy(receivedDataBuffer, startIndex + 1, receivedData, 0, dataLength);
                    OnDataReceived(receivedData);
                    receivedDataBufferIndex = 0;
                    break;
                }
                else
                {
                    startIndex++;
                }
            }
            if (startIndex > 0)
            {
                int remainingBytes = endIndex - startIndex + 1;
                Array.Copy(receivedDataBuffer, startIndex, receivedDataBuffer, 0, remainingBytes);
                receivedDataBufferIndex = remainingBytes;
            }


            dataComport = Encoding.UTF8.GetString(receivedDataBuffer);
            if (dataComport.Contains("\r\n") /*&& dataComport.Contains("DEV")*/) {
                string[] spliData = dataComport.Split(new[] { "\r\n" }, StringSplitOptions.None);
                dataComport = spliData[0] + "\r\n";
                Console.WriteLine(dataComport);

                if (dataComport.Contains(keyParseData))
                {
                    lock (MyParam.commonParam.queueLock)
                    {
                        if (MyParam.commonParam.queueData.Count >= MyDefine.MAX_QUEUE_DATA)
                        {
                            MyLib.log("Over queue size: " + dataComport);
                            MyLib.showDlgInfo("Please stop comport and wait a second!");
                        }
                        else
                        {
                            var data = dataComport.Replace(MyParam.commonParam.myComport.keyParseData, "");

                            string finalData = "";
                            for (int index = 0; index < data.Length; index++)
                            {
                                bool isNumber = char.IsDigit(data[index]);
                                bool isPeriod = (data[index] == '.');
                                bool isLetter = char.IsLetter(data[index]);

                                if (isNumber)
                                {
                                    finalData += data[index];
                                }
                                else if (isPeriod)
                                {
                                    if (finalData.Contains("."))
                                        break;
                                    else
                                    {
                                        finalData += data[index];
                                    }
                                }
                                else if (isLetter)
                                {
                                    break;
                                }
                            }

                            dataComport = "";

                            Console.WriteLine(finalData + ": Is data comport handle");

                            MyParam.commonParam.queueData.Enqueue(data);
                        }
                    }
                    MyLib.log(dataComport);
                }
            }
        }

        private void OnDataReceived(byte[] receivedData)
        {
            EventHandler<byte[]> handler = DataReceived;
            if (handler != null)
            {
                handler(this, receivedData);
            }
        }
        public string GetDataReceived(byte[] receivedData)
        {
            return BitConverter.ToString(receivedData, 0, receivedData.Length);
        }
    }
}
