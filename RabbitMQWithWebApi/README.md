# RabbitMQ With Two .NET 9 Web APIs

This sample contains **two ASP.NET Core Web API applications targeting .NET 9** that exchange data through **RabbitMQ**:

- **Producer API** publishes JSON messages to a RabbitMQ exchange.
- **Consumer API** listens to the RabbitMQ queue and stores received messages in memory.

## Solution structure

```text
src/
├── ProducerApi/
└── ConsumerApi/
```

## Architecture

1. Send an HTTP `POST` request to the **Producer API**.
2. The Producer API serializes the payload and publishes it to RabbitMQ.
3. RabbitMQ routes the message from the direct exchange to the queue.
4. The **Consumer API** reads the message from the queue and keeps it in memory.
5. Call the Consumer API to verify the message was received.

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) or another Docker runtime

## RabbitMQ setup

A `docker-compose.yml` file is included to start RabbitMQ locally with the management UI.

### 1. Start RabbitMQ

```bash
docker compose up -d
```

This starts RabbitMQ with:

- AMQP port: `5672`
- Management UI: `http://localhost:15672`
- Username: `guest`
- Password: `guest`

### 2. Verify RabbitMQ is running

Open the management UI in your browser:

```text
http://localhost:15672
```

Login with:

- **Username:** `guest`
- **Password:** `guest`

## Run the APIs

Open two terminals from the repository root.

### Terminal 1: Run the Producer API

```bash
dotnet run --project src/ProducerApi/ProducerApi.csproj
```

The Producer API will be available at a local URL such as:

```text
http://localhost:5062
```

### Terminal 2: Run the Consumer API

```bash
dotnet run --project src/ConsumerApi/ConsumerApi.csproj
```

The Consumer API will be available at a local URL such as:

```text
http://localhost:5167
```

> The exact ports may vary depending on your environment. Check the terminal output after `dotnet run`.

## How to exchange data

### 1. Publish a message through the Producer API

Example using `curl`:

```bash
curl -X POST http://localhost:5062/messages \
  -H "Content-Type: application/json" \
  -d '{
    "sender": "Order API",
    "text": "Order #1001 created"
  }'
```

Expected response:

```json
{
  "id": "generated-guid",
  "sender": "Order API",
  "text": "Order #1001 created",
  "sentAtUtc": "2026-03-19T12:00:00+00:00"
}
```

### 2. Read received messages from the Consumer API

```bash
curl http://localhost:5167/messages
```

Expected response:

```json
[
  {
    "id": "same-guid-as-published-message",
    "sender": "Order API",
    "text": "Order #1001 created",
    "sentAtUtc": "2026-03-19T12:00:00+00:00"
  }
]
```

## RabbitMQ configuration

Both APIs use the same configuration section in `appsettings.json`:

```json
"RabbitMq": {
  "HostName": "localhost",
  "Port": 5672,
  "UserName": "guest",
  "Password": "guest",
  "ExchangeName": "demo.exchange",
  "QueueName": "demo.queue",
  "RoutingKey": "demo.message"
}
```

If your RabbitMQ server runs elsewhere, update the values in both application settings files.

## Useful endpoints

### Producer API

- `GET /` - basic service info
- `POST /messages` - publish a message to RabbitMQ
- Swagger UI: `/swagger`

### Consumer API

- `GET /` - basic service info
- `GET /messages` - list all received messages currently stored in memory
- Swagger UI: `/swagger`

## Notes

- The Consumer API stores received messages **in memory only** for demo purposes.
- Restarting the Consumer API clears the in-memory list, but RabbitMQ keeps queued messages until consumed.
- The queue and exchange are declared automatically by the applications.
