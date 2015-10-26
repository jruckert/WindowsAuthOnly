using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpConsoleApp
{
    public class Program
    {
        public void Main(string[] args)
        {
            UploadFile(@"BlankWordDoc.docx");
        }

        private void UploadFile(string fileName)
        {
            string baseUri = "http://localhost:5000";
            string requestUri = "/api/test/update/document";
            var clientHandler = new HttpClientHandler();
            var documentToSend = System.IO.File.ReadAllBytes(fileName);
            clientHandler.Credentials = CredentialCache.DefaultCredentials;                 
            try
            {
                using (var client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri(baseUri);
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        //var values = new[]
                        //{
                        //    new KeyValuePair<string, string>("Status", "None"),
                        //    new KeyValuePair<string, string>("ElapsedTime", new TimeSpan(0, 0, 1).ToString())                          
                        //};

                        //foreach (var keyValuePair in values)
                        //{
                        //   // multipartFormDataContent.Add(new StringContent(keyValuePair.Value),
                        //   //     String.Format("\"{0}\"", keyValuePair.Key));
                        //}                      

                        multipartFormDataContent.Add(new ByteArrayContent(documentToSend),
                            '"' + "document" + '"',
                            '"' + "document.docx" + '"');

                        var result = client.PostAsync(requestUri, multipartFormDataContent).Result;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
