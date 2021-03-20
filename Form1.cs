using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.IO;
using Windows.Security.Cryptography;
using Windows.Storage.Streams;

namespace mBotRemoteController
{
    public partial class Form1 : Form
    {
        private BluetoothConnection _connection;
        public Form1()
        {
            InitializeComponent();
            _connection = new BluetoothConnection();

        }

        public static async Task<List<T>> GetResponse<T>(string url)
        {
            List<T> items = null;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

            var response = (HttpWebResponse)await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);
            try
            {
                Stream stream = response.GetResponseStream();
                StreamReader strReader = new StreamReader(stream);
                string text = strReader.ReadToEnd();
                items = new List<T>();
            }
            catch (WebException)
            {
                throw;
            }
            return items;
        }

       
        private void update_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            var devices = _connection.GetDeviceNames();
            
            comboBox1.Items.AddRange(devices.Select(d => d.Item1).ToArray());
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = comboBox1.SelectedIndex;
            var devices = _connection.GetDeviceNames();
            var device = devices[index];
            var baseText = this.status.Text;
            this.status.Text = baseText + "Connecting...";
            try
            {
                await _connection.Connect(device.Item2);
                this.status.Text = baseText + "Connected";
            }
            catch(Exception ex)
            {
                this.status.Text = baseText + "Not connected";
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            byte[] b = new byte[1];
            b[0] = 0xFF;

            IBuffer buffer = CryptographicBuffer.CreateFromByteArray(b);
            _connection.Send(buffer);
        }

        private void backward_Click(object sender, EventArgs e)
        {
            byte[] b = new byte[1];
            b[0] = 0xFE;

            IBuffer buffer = CryptographicBuffer.CreateFromByteArray(b);
            _connection.Send(buffer);
        }

        private void left_Click(object sender, EventArgs e)
        {
            byte[] b = new byte[1];
            b[0] = 0xFD;

            IBuffer buffer = CryptographicBuffer.CreateFromByteArray(b);
            _connection.Send(buffer);
        }

        private void right_Click(object sender, EventArgs e)
        {
            byte[] b = new byte[1];
            b[0] = 0xFC;

            IBuffer buffer = CryptographicBuffer.CreateFromByteArray(b);
            _connection.Send(buffer);
        }

        private void stop_Click(object sender, EventArgs e)
        {
            byte[] b = new byte[1];
            b[0] = 0xFB;

            IBuffer buffer = CryptographicBuffer.CreateFromByteArray(b);
            _connection.Send(buffer);
        }
    }
}
