
```
docker-compose.yml
│
├── pja_api_server
├── mongo
├── mongo-express
├── redis-node-0
├── redis-node-1
├── redis-node-2
├── redis-insight
└──

```


#### pja_api_server
- go grpc api server
- go 1.22.4
- port 50051:50051
- `ap.env` 파일로부터 환경 변수 읽어옴
	- aws access key, secret access key, aws region
	- config(local.toml) path : 파일 위치 기준이 달라서 로컬에서 돌릴때랑 컨테이너에서 돌릴때랑 경로가 달라짐
- mongodb_network로 mongo, mongo-express 컨테이너와 통신

#### mongo
- mongodb 최신 버전 이미지 사용
- 

