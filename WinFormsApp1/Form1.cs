using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsApp1
{

    public partial class Form1 : Form
    {
        private TcpMessenger messenger;
        private TcpServer server;
        private bool isServerRunning = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSendMsg1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            messenger = new TcpMessenger();

            // optionally hook up message receive events
            messenger.OnMessageReceived += OnMessageReceived;

            // populate combo box
            comboMessageType.Items.Add("Message 1");
            comboMessageType.Items.Add("Message 2");

            // Set default selection to "Message 1"
            comboMessageType.SelectedIndex = 0;

            comboBoxRank.Items.AddRange(new string[] { "Üsteğmen", "Teğmen", "Asteğmen" });
        }

        public static class MessageHelper
        {
            public static byte[] Serialize<T>(T message)
            {
                var json = JsonSerializer.Serialize(message);
                return Encoding.UTF8.GetBytes(json);
            }

            public static T Deserialize<T>(byte[] data)
            {
                var json = Encoding.UTF8.GetString(data);
                return JsonSerializer.Deserialize<T>(json);
            }
        }

        private void OnMessageReceived(byte[] data)
        {
            // Convert received data from bytes to string
            string messageText = Encoding.UTF8.GetString(data);

            // Because this is coming from a background thread, you must update UI on main thread
            this.Invoke(new Action(() =>
            {
                MessageBox.Show("Received: " + messageText); // Or log it to a ListBox
            }));
        }

        private void comboMessageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboMessageType.SelectedItem.ToString() == "Message 1")
            {
                panelMessage1.Visible = true;
                panelMessage1.BringToFront();

                panelMessage2.Visible = false;
            }
            else if (comboMessageType.SelectedItem.ToString() == "Message 2")
            {
                panelMessage1.Visible = false;

                panelMessage2.Visible = true;
                panelMessage2.BringToFront();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private async void buttonSendMessage_Click(object sender, EventArgs e)
        {
            if (comboMessageType.SelectedItem.ToString() == "Message 1")
            {
                var msg1 = new Message1
                {
                    UnitRefNumber = int.Parse(textBoxMsg1RefNo.Text),
                    FirstName = textBoxFirstName.Text,
                    UnitNo = uint.Parse(textBoxUnitNo.Text),
                    LastName = textBoxLastName.Text,
                    Rank = (Rank)comboBoxRank.SelectedIndex
                };

                byte[] data = MessageHelper.Serialize(msg1);
                await messenger.SendMessage(data);
            }
            else
            {
                var msg2 = new Message2
                {
                    UnitRefNumber = int.Parse(textBoxMsg2RefNo.Text),
                    LocationValidity = checkBoxLocValid.Checked ? (byte)1 : (byte)0,
                    Latitude = long.Parse(textBoxLatitude.Text),
                    Longitude = long.Parse(textBoxLongitude.Text),
                    Altitude = int.Parse(textBoxAltitude.Text)
                };

                byte[] data = MessageHelper.Serialize(msg2);
                await messenger.SendMessage(data);
            }
        }

        private async void buttonStartServer_Click(object sender, EventArgs e)
        {
            if (isServerRunning)
            {
                MessageBox.Show("Server is already running.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                server = new TcpServer();
                server.OnMessageReceived += Server_OnMessageReceived;
                server.OnLog += msg => listBoxLog.Items.Add(msg);

                string ip = "127.0.0.1"; // Or get from a textbox
                int port = int.Parse(textBox3.Text);

                await server.StartAsync(ip, port);
                isServerRunning = true;
                buttonStartServer.Enabled = false;  // Optionally disable start button
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to start server: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Server_OnMessageReceived(byte[] data)
        {
            string json = Encoding.UTF8.GetString(data);
            this.Invoke(() => listBoxLog.Items.Add("Received: " + json));
        }

        private void buttonStopServer_Click(object sender, EventArgs e)
        {
            if (!isServerRunning)
            {
                MessageBox.Show("Server is not running.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            server?.Stop();
            isServerRunning = false;
            buttonStartServer.Enabled = true;
        }
    }

}
