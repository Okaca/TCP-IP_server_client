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
        private System.Windows.Forms.Timer autoSendTimer;

        public Form1()
        {
            InitializeComponent();
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

            autoSendTimer = new System.Windows.Forms.Timer();
            autoSendTimer.Tick += AutoSendTimer_Tick;

            comboBoxRank.Items.AddRange(new string[] { "Üsteğmen", "Teğmen", "Asteğmen" });
        }

        private async void AutoSendTimer_Tick(object sender, EventArgs e)
        {
            // Trigger the same logic as the manual send button
            await SendSelectedMessageAsync();
        }

        private async Task SendSelectedMessageAsync()
        {
            if (comboMessageType.SelectedItem.ToString() == "Message 1")
            {
                // Validate Unit Reference Number
                if (!int.TryParse(textBoxMsg1RefNo.Text, out int unitRef1) || unitRef1 < -1000 || unitRef1 > 9999)
                {
                    MessageBox.Show("Unit Reference Number must be between -1000 and 9999.", "Validation Error");
                    return;
                }

                // Validate First Name
                if (string.IsNullOrWhiteSpace(textBoxFirstName.Text) || textBoxFirstName.Text.Length > 25)
                {
                    MessageBox.Show("First Name must be a non-empty string with max 25 characters.", "Validation Error");
                    return;
                }

                // Validate Unit No
                if (!uint.TryParse(textBoxUnitNo.Text, out uint unitNo))
                {
                    MessageBox.Show("Unit No must be a valid unsigned integer.", "Validation Error");
                    return;
                }

                // Validate Last Name
                if (string.IsNullOrWhiteSpace(textBoxLastName.Text) || textBoxLastName.Text.Length > 25)
                {
                    MessageBox.Show("Last Name must be a non-empty string with max 25 characters.", "Validation Error");
                    return;
                }

                // Validate Rank
                if (comboBoxRank.SelectedIndex < 0 || comboBoxRank.SelectedIndex > 2)
                {
                    MessageBox.Show("Please select a valid Rank (0 to 2).", "Validation Error");
                    return;
                }

                // Construct and send Message1
                var msg1 = new Message1
                {
                    UnitRefNumber = unitRef1,
                    FirstName = textBoxFirstName.Text,
                    UnitNo = unitNo,
                    LastName = textBoxLastName.Text,
                    Rank = (Rank)comboBoxRank.SelectedIndex
                };

                byte[] data = MessageHelper.Serialize(msg1);
                await messenger.SendMessage(data);
                LogSentMessage(data);
            }
            else if (comboMessageType.SelectedItem.ToString() == "Message 2")
            {
                // Validate Unit Reference Number
                if (!int.TryParse(textBoxMsg2RefNo.Text, out int unitRef2) || unitRef2 < 1 || unitRef2 > 9999)
                {
                    MessageBox.Show("Unit Reference Number must be between 1 and 9999.", "Validation Error");
                    return;
                }

                // Validate Latitude
                if (!long.TryParse(textBoxLatitude.Text, out long latitude) || latitude < -32400000 || latitude > 32400000)
                {
                    MessageBox.Show("Latitude must be between -32,400,000 and 32,400,000.", "Validation Error");
                    return;
                }

                // Validate Longitude
                if (!long.TryParse(textBoxLongitude.Text, out long longitude) || longitude < -64800000 || longitude > 64800000)
                {
                    MessageBox.Show("Longitude must be between -64,800,000 and 64,800,000.", "Validation Error");
                    return;
                }

                // Validate Altitude
                if (!int.TryParse(textBoxAltitude.Text, out int altitude) || altitude < 0 || altitude > 10000)
                {
                    MessageBox.Show("Altitude must be between 0 and 10,000.", "Validation Error");
                    return;
                }

                // Construct and send Message2
                var msg2 = new Message2
                {
                    UnitRefNumber = unitRef2,
                    LocationValidity = checkBoxLocValid.Checked ? (byte)1 : (byte)0,
                    Latitude = latitude,
                    Longitude = longitude,
                    Altitude = altitude
                };

                byte[] data = MessageHelper.Serialize(msg2);
                await messenger.SendMessage(data);
                LogSentMessage(data);
            }
        }

        private void checkBoxAutoSend_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAutoSend.Checked)
            {
                autoSendTimer.Interval = (int)numericUpDownInterval.Value; // Set based on user input
                autoSendTimer.Start();
            }
            else
            {
                autoSendTimer.Stop();
            }
        }

        // interval to update live when user changes it
        private void numericUpDownInterval_ValueChanged(object sender, EventArgs e)
        {
            autoSendTimer.Interval = (int)numericUpDownInterval.Value;
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
            // client side show received message
            this.Invoke(() => listBoxLog.Items.Add("[Received]: " + messageText));
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

        private async void buttonSendMessage_Click(object sender, EventArgs e)
        {
            if (comboMessageType.SelectedItem.ToString() == "Message 1")
            {
                // Validate Unit Reference Number
                if (!int.TryParse(textBoxMsg1RefNo.Text, out int unitRef1) || unitRef1 < -1000 || unitRef1 > 9999)
                {
                    MessageBox.Show("Unit Reference Number must be between -1000 and 9999.", "Validation Error");
                    return;
                }

                // Validate First Name
                if (string.IsNullOrWhiteSpace(textBoxFirstName.Text) || textBoxFirstName.Text.Length > 25)
                {
                    MessageBox.Show("First Name must be a non-empty string with max 25 characters.", "Validation Error");
                    return;
                }

                // Validate Unit No
                if (!uint.TryParse(textBoxUnitNo.Text, out uint unitNo))
                {
                    MessageBox.Show("Unit No must be a valid unsigned integer.", "Validation Error");
                    return;
                }

                // Validate Last Name
                if (string.IsNullOrWhiteSpace(textBoxLastName.Text) || textBoxLastName.Text.Length > 25)
                {
                    MessageBox.Show("Last Name must be a non-empty string with max 25 characters.", "Validation Error");
                    return;
                }

                // Validate Rank
                if (comboBoxRank.SelectedIndex < 0 || comboBoxRank.SelectedIndex > 2)
                {
                    MessageBox.Show("Please select a valid Rank (0 to 2).", "Validation Error");
                    return;
                }

                // Construct and send Message1
                var msg1 = new Message1
                {
                    UnitRefNumber = unitRef1,
                    FirstName = textBoxFirstName.Text,
                    UnitNo = unitNo,
                    LastName = textBoxLastName.Text,
                    Rank = (Rank)comboBoxRank.SelectedIndex
                };

                byte[] data = MessageHelper.Serialize(msg1);
                await messenger.SendMessage(data);
                LogSentMessage(data);
            }
            else if (comboMessageType.SelectedItem.ToString() == "Message 2")
            {
                // Validate Unit Reference Number
                if (!int.TryParse(textBoxMsg2RefNo.Text, out int unitRef2) || unitRef2 < 1 || unitRef2 > 9999)
                {
                    MessageBox.Show("Unit Reference Number must be between 1 and 9999.", "Validation Error");
                    return;
                }

                // Validate Latitude
                if (!long.TryParse(textBoxLatitude.Text, out long latitude) || latitude < -32400000 || latitude > 32400000)
                {
                    MessageBox.Show("Latitude must be between -32,400,000 and 32,400,000.", "Validation Error");
                    return;
                }

                // Validate Longitude
                if (!long.TryParse(textBoxLongitude.Text, out long longitude) || longitude < -64800000 || longitude > 64800000)
                {
                    MessageBox.Show("Longitude must be between -64,800,000 and 64,800,000.", "Validation Error");
                    return;
                }

                // Validate Altitude
                if (!int.TryParse(textBoxAltitude.Text, out int altitude) || altitude < 0 || altitude > 10000)
                {
                    MessageBox.Show("Altitude must be between 0 and 10,000.", "Validation Error");
                    return;
                }

                // Construct and send Message2
                var msg2 = new Message2
                {
                    UnitRefNumber = unitRef2,
                    LocationValidity = checkBoxLocValid.Checked ? (byte)1 : (byte)0,
                    Latitude = latitude,
                    Longitude = longitude,
                    Altitude = altitude
                };

                byte[] data = MessageHelper.Serialize(msg2);
                await messenger.SendMessage(data);
                LogSentMessage(data);
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
                server.OnLog += msg => this.Invoke(() => listBoxServer.Items.Add(msg));

                string ip = label4.Text; // 127.0.0.1
                int port = int.Parse(textBox3.Text);

                try
                {
                    await server.StartAsync(ip, port);
                    isServerRunning = true;
                    buttonStartServer.Enabled = false;
                }
                catch (Exception ex)
                {
                    listBoxLog.Items.Add("❌ Exception in StartAsync: " + ex.Message);
                    MessageBox.Show("Server start failed: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to start server: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Server_OnMessageReceived(byte[] data)
        {
            // server side show received message
            string json = Encoding.UTF8.GetString(data);
            this.Invoke(() => listBoxServer.Items.Add("[Received]: " + json));
        }

        private void LogSentMessage(byte[] data)
        {
            // client side show sent message
            string json = Encoding.UTF8.GetString(data);
            this.Invoke(() => listBoxLog.Items.Add("[Transmitted]: " + json));
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

        private async void buttonConnect_Click(object sender, EventArgs e)
        {
            string ip = textBox1.Text.Trim();     // IP address (e.g., "127.0.0.1")
            if (!int.TryParse(textBox2.Text.Trim(), out int port))
            {
                MessageBox.Show("Invalid port number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                messenger = new TcpMessenger();
                messenger.OnMessageReceived += OnMessageReceived;

                await messenger.ConnectAsync(ip, port);
                listBoxLog.Items.Add($"Connected to server at {ip}:{port}");
                buttonConnect.Enabled = false; // Optional: disable after successful connection
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection failed: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listBoxLog.Items.Add($"Connection failed: {ex.Message}");
            }
        }
    }

}
