using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using static WinFormsApp1.Form1;

namespace WinFormsApp1
{
    // Lightweight model just to extract MessageId
    public class BaseMessage
    {
        public int MessageId { get; set; }
    }

    public class TcpServer
    {
        private TcpListener _listener;
        private bool _isRunning;

        public event Action<byte[]> OnMessageReceived;
        public event Action<string> OnLog;

        public async Task StartAsync(string ip, int port)
        {
            _listener = new TcpListener(IPAddress.Parse(ip), port);
            _listener.Start();
            _isRunning = true;

            Log($"Server started on {ip}:{port}");

            _ = Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        var client = await _listener.AcceptTcpClientAsync();
                        _ = Task.Run(() => HandleClientAsync(client));
                    }
                    catch (Exception ex)
                    {
                        Log($"Listener stopped: {ex.Message}");
                        break;
                    }
                }
            });
        }

        public void Stop()
        {
            _isRunning = false;
            _listener?.Stop();
            Log("Server stopped.");
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            Log("Client connected.");

            using var stream = client.GetStream();
            var buffer = new byte[1024];

            while (_isRunning && client.Connected)
            {
                try
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        byte[] data = buffer.Take(bytesRead).ToArray();
                        OnMessageReceived?.Invoke(data);

                        string json = Encoding.UTF8.GetString(data);

                        BaseMessage baseMsg;
                        try
                        {
                            baseMsg = JsonSerializer.Deserialize<BaseMessage>(json);
                        }
                        catch
                        {
                            Log("Failed to parse MessageId.");
                            var error = Encoding.UTF8.GetBytes("Invalid message format");
                            await stream.WriteAsync(error, 0, error.Length);
                            continue;
                        }

                        switch (baseMsg.MessageId)
                        {
                            case 1:
                                // Client sent Message1, respond with Message2
                                var msg2 = new Message2
                                {
                                    UnitRefNumber = 1234,
                                    LocationValidity = 1,
                                    Latitude = 407123456,
                                    Longitude = 293456789,
                                    Altitude = 120
                                };
                                var response2 = MessageHelper.Serialize(msg2);
                                await stream.WriteAsync(response2, 0, response2.Length);
                                LogWithTimestamp("Transmitted", response2);
                                break;

                            case 2:
                                // Client sent Message2, respond with Message1
                                var msg1 = new Message1
                                {
                                    UnitRefNumber = 4321,
                                    FirstName = "Server",
                                    LastName = "Response",
                                    UnitNo = 999,
                                    Rank = Rank.Tegmen
                                };
                                var response1 = MessageHelper.Serialize(msg1);
                                await stream.WriteAsync(response1, 0, response1.Length);
                                LogWithTimestamp("Transmitted", response1);
                                break;

                            default:
                                Log($"Unknown MessageId: {baseMsg.MessageId}");
                                var unknown = Encoding.UTF8.GetBytes("Unknown MessageId");
                                await stream.WriteAsync(unknown, 0, unknown.Length);
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log("Client error: " + ex.Message);
                    break;
                }
            }

            client.Close();
            Log("Client disconnected.");
        }

        private void LogWithTimestamp(string label, byte[] data)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string json = Encoding.UTF8.GetString(data);
            Log($"[{timestamp}] [{label}]: {json}");
        }

        private void Log(string message)
        {
            OnLog?.Invoke(message);
        }
    }
}
