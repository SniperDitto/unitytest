username, password, ip주소나 port는 상황에 따라 다를 수 있음

#### 컨테이너 이미지 빌드+실행
---
![[스크린샷 2024-07-02 15.33.43.png]]
docker-compose가 있는 경로에 가서 빌드+실행
db 등의 초기 설정이 안되어있으므로 ap server는 실행이 안되는 것이 정상 + 파라미터스토어의 주소
#### mongodb  init setting
---
아래 내용을 exec에 복붙한다
```js
mongosh -u 'pjauser' -p 'coconefk0801!'  

use PJA_MASTER
use PJA_USER
use PJA_LOG
use PJA_CMS  
  
use admin  
db.grantRolesToUser(  
    "pjauser",  
    [  
        { role: "readWrite", db: "PJA_MASTER" },  
        { role: "readWrite", db: "PJA_USER" },  
        { role: "readWrite", db: "PJA_LOG" },  
        { role: "readWrite", db: "PJA_CMS" }  
    ]  
)

```


![[스크린샷 2024-07-02 17.09.15.png]]


#### redis cluster 설정(cluster creator 컨테이너 없을 때 수동으로 설정)
---
아래 스크립트를 exec에 복붙

```sh
#괄호 안 부분은 로컬 쉘에서 실행 시 추가
(docker exec -it redis-0) redis-cli --cluster create 172.28.1.1:7878 172.28.1.2:7879 172.28.1.3:7880 --cluster-replicas 0 -a coconefk0801!
```

![[스크린샷 2024-07-02 18.13.16.png]]

로컬 쉘에서 아래와 같이 입력하면 접속할 수 있는데
```sh
docker exec -it redis-0 redis-cli -h 172.28.1.1 -p 7878 -c
```

cluster가 설정된 것을 확인할 수 있다.
![[스크린샷 2024-07-02 18.15.28.png]]





