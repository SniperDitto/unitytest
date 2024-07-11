
docker-compose.yml
```yml

services:  
  pja_api_server:  
    build:  
      context: ../../..  
      dockerfile: ap/Dockerfile  
    ports:  
      - "50051:50051"  
    depends_on:  
      - redis-node-0  
      - redis-node-1  
      - redis-node-2  
      - mongo  
    environment:  
      - AWS_ACCESS_KEY_ID  
      - AWS_SECRET_ACCESS_KEY  
      - AWS_DEFAULT_REGION  
      - CONFIG_PATH  
    env_file:  
      - ap.env  
    networks:  
      - mongodb_network  
  
  mongo:  
    image: mongo:latest  
    container_name: mongo  
    hostname: mongo  
    ports:  
      - "27018:27017"  
    volumes:  
      #- ./mongo-init.txt:/docker-entrypoint-initdb.d/mongo-init.txt:ro  
      #- /opt/homebrew/var/mongodb:/data/db      - ../../../../mongo-data:/data/db  
    env_file:  
      - .env  
    environment:  
      MONGO_INITDB_ROOT_USERNAME: ${MONGO_INITDB_ROOT_USERNAME}  
      MONGO_INITDB_ROOT_PASSWORD: ${MONGO_INITDB_ROOT_PASSWORD}  
    networks:  
      - mongodb_network  
  
  mongo-express:  
    image: mongo-express:latest  
    container_name: mongo-express  
    restart: always  
    environment:  
      ME_CONFIG_MONGODB_ADMINUSERNAME: ${MONGO_INITDB_ROOT_USERNAME}  
      ME_CONFIG_MONGODB_ADMINPASSWORD: ${MONGO_INITDB_ROOT_PASSWORD}  
      #ME_CONFIG_MONGODB_PORT: 27018  
      ME_CONFIG_MONGODB_URL: mongodb://pja_user:coconefk0801!@mongo:27017  
      ME_CONFIG_MONGODB_ENABLE_ADMIN: true  
      ME_CONFIG_BASICAUTH_USERNAME: ${MONGO_EXPRESS_USERNAME}  
      ME_CONFIG_BASICAUTH_PASSWORD: ${MONGO_EXPRESS_PASSWORD}  
    ports:  
      - 8081:8081  
    networks:  
      - mongodb_network  
    depends_on:  
      - mongo  
    links:  
      - "mongo"  
  
  
  
  redis-node-0:  
    image: redis:latest  
    ports:  
      - "7000:7000"  
    command: ["redis-server", "--port", "7000", "--cluster-enabled", "yes", "--cluster-config-file", "nodes.conf", "--cluster-node-timeout", "5000", "--appendonly", "yes"]  
    volumes:  
      - redis-data-0:/data  
  
  redis-node-1:  
    image: redis:latest  
    ports:  
      - "7001:7001"  
    command: ["redis-server", "--port", "7001", "--cluster-enabled", "yes", "--cluster-config-file", "nodes.conf", "--cluster-node-timeout", "5000", "--appendonly", "yes"]  
    volumes:  
      - redis-data-1:/data  
  
  redis-node-2:  
    image: redis:latest  
    ports:  
      - "7002:7002"  
    command: ["redis-server", "--port", "7002", "--cluster-enabled", "yes", "--cluster-config-file", "nodes.conf", "--cluster-node-timeout", "5000", "--appendonly", "yes"]  
    volumes:  
      - redis-data-2:/data  
  
volumes:  
  mongo-data:  
    driver: local  
    name: mongodb-data  
  redis-data-0:  
  redis-data-1:  
  redis-data-2:  
  
networks:  
  mongodb_network:  
    driver: bridge  
    name: mongo-network
```

컨테이너 내부는 `컨테이너이름:내부포트` 로 연결
외부(로컬)-컨테이너 는 `127.0.0.1:외부포트` 로 연결

