
서버 프로젝트 안에 docker-compose.yml 작성


```
docker-compose.yml
│
├── pja_api_server
├── mongo
├── mongo-express
├── redis-node-0
├── redis-node-1
├── redis-node-2
├── redis-cluster-creator
└── redis-insight

```

#### 각 컨테이너 설명
- pja_api_server
	* go grpc api server
	- aws parameter store 연동을 위해 관련 내용들을 환경변수로 넣어줌
	- 추후 기빈님한테 들은대로 aws 인증 파일을 이용하는 식으로 교체하는 것도 고려 중
	- 컨테이너 간 내부 통신을 위해 `mongodb_network`, `redis_cluster` 네트워크에 연결하도록 설정
	- db, redis와 함께 docker 컨테이너로 실행하는 것을 테스트해보고 정상적으로 켜지는 것을 확인한 후, 로컬에서 서버를 실행하고 mongodb와 redis만 docker로 구성하여 
- mongo
	- 컨테이너에 볼륨 마운트하기 위해 서버 프로젝트 안에 mongodb 데이터 저장 폴더를 넣음
	- mongo-express와 함께 `mongodb_network` 구성
- mongo-express
	- mongo와 함께 `mongodb_network` 구성
- redis-node-0, 1, 2
	- redis cluster 구축을 위한 3개의 컨테이너
	- host 모드로 실행하여 로컬 서버에서 redis에 연결할 수 있도록 함
		- 이 부분에서 많은 시행착오를 겪었는데, mongodb의 경우 별도 설정 없어도 로컬에서 컨테이너의 Mongodb 접속이 가능했는데 redis의 경우 계속 timeout 에러가 발생
		- host 모드로 실행해도 로컬 쉘에서 `lsof` 명령어를 이용해 확인해봤을 때 설정해둔 포트에 아무것도 실행되지 않았는데, docker desktop에서 `features in development - enable host networking`을 사용해야 정상적으로 작동
- redis-cluster-creator
	- redis 컨테이너 3개에 대한 클러스터 설정을 할 수 있도록 커맨드를 실행하는 역할
- redis-insight
	- redis gui



