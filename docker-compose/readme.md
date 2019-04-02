# Docker Compose

__Example__
```yml
version: '3'
services:
  zookeeper:
    image: confluentinc/cp-zookeeper:5.1.0
    hostname: zookeeper
    container_name: zookeeper
    environment:
      ZOOKEEPER_CLIENT_PORT: 2181
      ZOOKEEPER_TICK_TIME: 2000
    networks: 
      - kafkanet

  kafka:
    image: confluentinc/cp-kafka:5.1.0
    hostname: kafka
    container_name: kafka
    depends_on:
      - zookeeper
    ports:
      - "9091:9091"
    environment:
      KAFKA_BROKER_ID: 1
      # ... (other vars)
    networks: 
      - kafkanet

networks:
  kafkanet:
    external: true
```

## Environment Variable

```yml
    environment:
      - JUDA_MONGODB=${DB_PROD}
      - JUDA_PROXY_URLS=http://www.christsquare.com
```

  * No space on left or right side of `=`
  * No `"` for value
  * Attach container and examine real env. setup

## Configurations

### Network
  * Dedicated networks can be used. 
  * Use `external = false` to create network inside of docker compose. It won't be visible for other containers
  * Use `external = true` to create network with docker-cli (`docker network create NETWORKNAME`) and make network accessible to other non-docker-compose containers

## Links
  * [Reference](https://docs.docker.com/compose/compose-file)