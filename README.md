# I2P.NET

A .NET library for using the I2P Simple Anonymous Messaging (SAM v3.0) bridge.

Supported platforms:

- .NET 6.0
- .NET Standard 2.1

This includes the .NET Core, UWP and more.

## Usage:

You need to have I2P installed, and enable the SAMv3 bridge in the router console.

See the SampleApp project for a detailed example.

```csharp
// Connect to SAM bridge
var session = new I2PSession(samPort: 7656);
await session.InitializeAsync();

// Connect to a peer
var stream = await session.ConnectAsync(destination);
var writer = new BinaryWriter(stream);
writer.Write("Testing...");
```
