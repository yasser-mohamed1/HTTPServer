using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

class SimpleHttpServer
{
    static async Task Main(string[] args)
    {
        string localIpAddress = "192.168.1.13"; // replace with your IP
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add($"http://{localIpAddress}:8080/"); // Listen on the local network IP and port 8080.

        listener.Start();

        Console.WriteLine($"HTTP Server started. Listening on http://{localIpAddress}:8080/");

        // Loop to continuously listen for HTTP requests
        while (true)
        {
            // Wait for an incoming client request asynchronously
            HttpListenerContext context = await listener.GetContextAsync();

            Task.Run(() => ProcessRequest(context));
        }
    }

    static async Task ProcessRequest(HttpListenerContext context)
    {
        HttpListenerRequest request = context.Request;
        HttpListenerResponse response = context.Response;

        string urlPath = request.Url!.AbsolutePath;
        Console.WriteLine($"Received {request.HttpMethod} request for {request.Url}");
        byte[] buffer;
        string responseBody;
        if (urlPath == "/")
        {
            responseBody = @"<!DOCTYPE html>
                               <html lang=""en"">
                                    <head>
                                        <meta charset=""UTF-8"">
                                        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                                        <title>HTTP Server in C#</title>
                                      <style>
                                         body {
                                             font-family: 'Arial', sans-serif;
                                             text-align: center;
                                             padding: 20px;
                                             background-color: #f4f4f4;
                                         }
                                      </style>
                                    </head>
                                   <body>
                                       <h1> Welcome to Yasser's HTTP Server! <h1>
                                   </body>
                                 </html>
                                    ";
        }
        else
        {
            response.StatusCode = (int)HttpStatusCode.NotFound;
            responseBody = @"<html>
                              <style>
                                 h1{
                                      color: red;
                                 }
                             </style>
                            <body>
                                <h1>404 Page not found!<h1>
                            </body>
                            </html>
                            ";
        }
        buffer = Encoding.UTF8.GetBytes(responseBody);
        response.ContentLength64 = buffer.Length;
        response.ContentType = "text/html";
        await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
    }
}