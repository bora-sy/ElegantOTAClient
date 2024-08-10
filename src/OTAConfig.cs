using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ElegantOTAClient
{
    public class OTAConfig
    {
        public IPEndPoint EP {  get; private set; }
        public string FirmwarePath { get; private set; }
        public string? Username { get; private set; }
        public string? Password { get; private set; }

        public OTAConfig(IPEndPoint EP, string firmwarePath, string? username = null, string? password = null)
        {
            this.EP = EP;
            this.FirmwarePath = firmwarePath;
            this.Username = username;
            this.Password = password;
        }

        public byte[] Serialize()
        {
            byte[] b_firmwarePath = Encoding.UTF8.GetBytes(this.FirmwarePath);
            byte[] b_username = Username == null ? new byte[0] : Encoding.UTF8.GetBytes(this.Username);
            byte[] b_password = Password == null ? new byte[0] : Encoding.UTF8.GetBytes(this.Password);

            // IP + PORT + FirmwarePath length + FirmwarePath + UsernameLength + Username + PasswordLength + Password
            //int len = 4 + 2 + 2 + b_firmwarePath.Length + 2 + b_username.Length + 2 + b_password.Length;
            int len = 12 + b_firmwarePath.Length + b_username.Length + b_password.Length;
            byte[] buf = new byte[len];

            MemoryStream str = new MemoryStream(buf);

            byte[] ipAddr = EP.Address.MapToIPv4().GetAddressBytes();
            str.Write(ipAddr,0,4);

            ushort port = (ushort)EP.Port;
            str.Write(BitConverter.GetBytes(port));

            ushort firmpathLen = (ushort)b_firmwarePath.Length;
            str.Write(BitConverter.GetBytes(firmpathLen));
            str.Write(b_firmwarePath);

            ushort usernameLen = (ushort)b_username.Length;
            str.Write(BitConverter.GetBytes(usernameLen));
            str.Write(b_username);

            ushort passwordLen = (ushort)b_password.Length;
            str.Write(BitConverter.GetBytes(passwordLen));
            str.Write(b_password);

            return buf;
        }

        public static OTAConfig Deserialize(byte[] data)
        {
            MemoryStream str = new MemoryStream(data);
            byte[] ipBytes = new byte[4];
            str.Read(ipBytes);

            ushort port = ReadUshort(str);

            ushort firmPathLen = ReadUshort(str);
            string firmPath = ReadString(str, firmPathLen);

            ushort usernameLen = ReadUshort(str);
            string? username = ReadString(str, usernameLen);

            ushort passwordLen = ReadUshort(str);
            string? password = ReadString(str, passwordLen);

            IPEndPoint EP = new IPEndPoint(new IPAddress(ipBytes), port);

            username = username == "" ? null : username;
            password = password == "" ? null : password;

            return new OTAConfig(EP, firmPath, username, password);
            
        }

        private static ushort ReadUshort(MemoryStream str)
        {
            byte[] buf = new byte[2];
            str.Read(buf, 0, 2);
            return BitConverter.ToUInt16(buf);
        }

        private static string ReadString(MemoryStream str, int len)
        {
            byte[] buf = new byte[len];
            str.Read(buf, 0, len);

            return Encoding.UTF8.GetString(buf);
        }

    }
}
