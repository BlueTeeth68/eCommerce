# API Gateway Docker Setup

This repository contains Docker configuration for the RushRetail API Gateway service.

## Prerequisites

- Docker
- Docker Compose

## Getting Started

### Building and Running with Docker Compose

1. Clone the repository
2. Navigate to the project root directory
3. Run the following command to build and start the services:

```bash
docker-compose up -d
```

This will:
- Build the API Gateway image
- Start the API Gateway service on port 8008
- Start a Redis instance for rate limiting

### Accessing the API Gateway

Once the services are running, the API Gateway will be available at:

```
http://localhost:8008
```

Health check endpoint:

```
http://localhost:8008/actuator/health
```

## Configuration

The Docker setup includes:

- **API Gateway Service**: Spring Cloud Gateway application
- **Redis Service**: Used for rate limiting and other caching needs

### Environment Variables

The following environment variables can be modified in the docker-compose.yml file:

- `SPRING_DATA_REDIS_HOST`: Redis host (default: redis)
- `SPRING_DATA_REDIS_PORT`: Redis port (default: 6379)

## Stopping the Services

To stop the services:

```bash
docker-compose down
```

To stop the services and remove volumes:

```bash
docker-compose down -v
```

## Building the Docker Image Separately

If you want to build the Docker image separately:

```bash
docker build -t rushretail/api-gateway .
```

## Running in Production

For production environments, consider:

1. Using Docker Swarm or Kubernetes for orchestration
2. Setting up proper logging and monitoring
3. Configuring SSL/TLS for secure communication
4. Implementing proper backup strategies for Redis data