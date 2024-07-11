

![[스크린샷 2024-06-28 17.40.08.png]]

```sh
redis-cli --cluster create \  
  172.28.1.1:8000 \  
  172.28.1.2:8001 \  
  172.28.1.3:8002 \  
  --cluster-replicas 0 -a coconefk0801!
```
redis-cli --cluster create 172.28.1.1:8000 172.28.1.2:8001 172.28.1.3:8002 --cluster-replicas 0 -a coconefk0801!


로컬 shell로 실행 시
```sh
docker exec -it redis-8000 redis-cli --cluster create \  
  172.28.1.1:8000 \  
  172.28.1.2:8001 \  
  172.28.1.3:8002 \  
  --cluster-replicas 0 -a coconefk0801!
```


docker gateway 주소 확인
```sh
docker network inspect bridge
```
redis-cli --cluster create 172.28.1.1:8000 172.28.1.2:8001 172.28.1.3:8002 --cluster-replicas 0 -a coconefk0801!
