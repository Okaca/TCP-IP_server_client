using System.Net;
using System.Net.Sockets;

namespace WinFormsApp1
{
    public class TcpMessenger
    {
        private TcpClient _client;
        private NetworkStream _stream;

        public event Action<byte[]> OnMessageReceived;

        public async Task ConnectAsync(string ip, int port)
        {
            Console.WriteLine("ip : ", ip, "port : ", port);
            _client = new TcpClient();
            await _client.ConnectAsync(IPAddress.Parse(ip), port);
            _stream = _client.GetStream();
            _ = Task.Run(ReceiveLoop); // Start background receiving
        }

        public async Task SendMessage(byte[] data)
        {
            if (_stream != null)
            {
                await _stream.WriteAsync(data, 0, data.Length);
            }
        }

        private async Task ReceiveLoop()
        {
            var buffer = new byte[1024];
            while (true)
            {
                try
                {
                    int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        var data = buffer.Take(bytesRead).ToArray();
                        OnMessageReceived?.Invoke(data);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Receive error: " + ex.Message);
                    break;
                }
            }
        }

        public void Disconnect()
        {
            _stream?.Close();
            _client?.Close();
        }
    }
}