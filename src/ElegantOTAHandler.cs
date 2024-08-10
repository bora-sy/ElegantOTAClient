using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ElegantOTAClient
{
    internal static class ElegantOTAHandler
    {
        private static OTAConfig config = null!;

        public static void SetConfig(OTAConfig _config)
        {
            config = _config;
        }


        public static async Task<bool> UpdateAsync(byte[] buf, byte[] MD5Hash, Action<long> ProgressCB, Action<string> ErrorCB)
        {
            
            if(!await StartAsync(MD5Hash))
            {
                ErrorCB("An error occured while starting file transfer");
                return false;
            }

            if(!await TransferAsync(buf, ProgressCB))
            {
                ErrorCB("An error occured while transferring file");
                return false;
            }
            

            return true;
        }

        private static async Task<bool> TransferAsync(byte[] buf, Action<long> ProgressCB)
        {
            HttpMessageHandler handler = config.Username == null ? new HttpClientHandler() : new HttpClientHandler()
            {
                PreAuthenticate = true,
                Credentials = new NetworkCredential(config.Username, config.Password)
            };

            var content = new MultipartFormDataContent();

            HttpClient client = new HttpClient(handler);

            bool progressLoop = true;

            try
            {
                using (MemoryStream stream = new MemoryStream(buf))
                {
                    client = new HttpClient(handler);

                    content.Add(new StreamContent(stream), "file", Path.GetFileName(config.FirmwarePath));

                    string url = $"http://{config.EP.Address.MapToIPv4()}:{config.EP.Port}/ota/upload";

                    _ = Task.Run(async delegate ()
                    {
                        try
                        {
                            long lastPos = 0;

                            while (progressLoop && stream != null)
                            {
                                if (stream.Position != lastPos)
                                {
                                    lastPos = stream.Position;
                                    ProgressCB(lastPos);
                                }

                                await Task.Delay(10);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Progress Loop Failed\nEx: " + ex.Message);
                        }
                    });

                    var resp = await client.PostAsync(url, content);


                    if (!resp.IsSuccessStatusCode) throw new Exception($"Unsuccessful Transfer (Status Code: {resp.StatusCode}) [Content: {await resp.Content.ReadAsStringAsync()}]");

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while transferring file..\nError: " + ex.Message);
                return false;
            }
            finally
            {

                progressLoop = false;

                if (handler != null) handler.Dispose();
                if (client != null) client.Dispose();
                if (content != null) content.Dispose();

            }
        }

        private static async Task<bool> StartAsync(byte[] MD5Hash)
        {
            HttpMessageHandler handler = config.Username == null ? new HttpClientHandler() : new HttpClientHandler()
            {
                PreAuthenticate = true,
                Credentials = new NetworkCredential(config.Username, config.Password)
            };

            HttpClient client = new HttpClient(handler);
            try
            {


                string hashStr = BitConverter.ToString(MD5Hash).Replace("-", "");

                string url = $"http://{config.EP.Address.MapToIPv4()}:{config.EP.Port}/ota/start?mode=firmware&hash={hashStr}";



                var res = await client.GetAsync(url);

                if (res.IsSuccessStatusCode)
                {
                    return true;
                }
                else throw new Exception($"Response code is not 200 (Response Code: {res.StatusCode}) [Response: {await res.Content.ReadAsStringAsync()}]");
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occured while starting file transfer..\nError: " + ex.Message);
                return false;
            }
            finally
            {
                if(handler != null) handler.Dispose();
                if (client != null) client.Dispose();
            }
        }

    }
}
