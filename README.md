# Simple HTTP Server in C#

This is a basic HTTP server implemented in C# using the `HttpListener` class. It listens for HTTP requests on a specified local IP address and port, and serves simple HTML content in response.

## Features

- **Basic HTML Response:** Serves a welcome message on the root path (`/`).
- **404 Error Handling:** Returns a 404 page for any other paths.

## Requirements

- .NET Core or .NET Framework
- Basic understanding of HTTP and networking

## Setup and Installation

1. **Clone the Repository:**

```bash
git clone git@github.com:yasser-mohamed1/HTTPServer.git
```

2. **Build the Project:**

```bash
cd HttpServer
dotnet build
```

3. **Run the Server:**

```bash
dotnet run
```

## Configuration

The server is configured to listen on a specific local IP address and port. You can modify the localIpAddress variable in the SimpleHttpServer class to match your local network configuration.

```csharp
string localIpAddress = "192.168.1.13";
HttpListener listener = new HttpListener();
listener.Prefixes.Add($"http://{localIpAddress}:8080/");
```

## Firewall Rules

To allow requests from other devices on the same network, you may need to configure your firewall to allow traffic on the specified port (8080 in this case). Here’s how you can do it on Windows:

1. **Open Windows Defender Firewall**

   1. Search for "Windows Defender Firewall" in the Start menu and open it.

2. **Add a New Inbound Rule**

   1. Click on "Advanced settings" on the left pane.
   1. Select "Inbound Rules" and click "New Rule…" on the right pane.
   1. Choose "Port" and click "Next".
   1. Select "TCP" and enter 8080 in the "Specific local ports" field, then click "Next".
   1. Choose "Allow the connection" and click "Next".
   1. Check all the profiles (Domain, Private, Public) and click "Next".
   1. Name the rule (e.g., "Allow HTTP Server") and click "Finish".

3. **Verify Firewall Settings**

Ensure that the rule you created is enabled and properly configured.

**Linux** (Using iptables)

1. **Open Terminal:**

Access the terminal on your Linux machine.
Add a New Rule:

Run the following command to allow traffic on port 8080:

```bash
sudo iptables -A INPUT -p tcp --dport 8080 -j ACCEPT
```

2. **Save the Configuration:**

Save the iptables rules to ensure they persist after a reboot. This varies by distribution, but you can often use:

```bash
sudo iptables-save | sudo tee /etc/iptables/rules.v4
```

3. **Verify Firewall Settings:**

Check your rules to ensure they are correctly applied:

```bash
sudo iptables -L
```

## Accessing the Server

Once the server is running and the firewall is configured, you can access the server from any device on the same network by navigating to:

```
http://your-local-ip:8080/
```
