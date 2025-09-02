using System.Net;
using System.Net.Sockets;
using System.Text;
using static WinFormsApp1.Form1;

namespace WinFormsApp1
{
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
                        // await HandleClientAsync(client); // only good for single-client server
                        _ = Task.Run(() => HandleClientAsync(client));  // Run in parallel, do not await
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

                        // Determine message type
                        var text = Encoding.UTF8.GetString(data);

                        if (text.Contains("\"FirstName\"")) // Rough indicator of Message1
                        {
                            var msg2 = new Message2 // random values for msg2
                            {
                                UnitRefNumber = 1234,
                                LocationValidity = 1,
                                Latitude = 407123456,
                                Longitude = 293456789,
                                Altitude = 120
                            };
                            var response = MessageHelper.Serialize(msg2);
                            await stream.WriteAsync(response, 0, response.Length);
                            // show sent message
                            Log("[Transmitted]: " + Encoding.UTF8.GetString(response));
                        }
                        else if (text.Contains("\"Latitude\"")) // Rough indicator of Message2
                        {
                            var msg1 = new Message1 // random values for msg1
                            {
                                UnitRefNumber = 4321,
                                FirstName = "Server",
                                LastName = "Response",
                                UnitNo = 999,
                                Rank = Rank.Tegmen
                            };
                            var response = MessageHelper.Serialize(msg1);
                            await stream.WriteAsync(response, 0, response.Length);
                            // show sent message
                            Log("[Transmitted]: " + Encoding.UTF8.GetString(response));
                        }
                        else
                        {
                            Log("Received unknown message.");
                            var error = Encoding.UTF8.GetBytes("Unrecognized message");
                            await stream.WriteAsync(error, 0, error.Length);
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

        private void Log(string message)
        {
            OnLog?.Invoke(message);
        }
    }
}