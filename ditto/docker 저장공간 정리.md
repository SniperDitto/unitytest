
#### 도커 이미지 및 컨테이너 정리

Docker는 불필요한 이미지와 컨테이너가 많이 쌓이면 디스크 공간을 많이 차지할 수 있습니다. 사용하지 않는 이미지와 컨테이너를 정리하여 공간을 확보할 수 있습니다.


```sh
# 모든 중지된 컨테이너 삭제 
docker container prune -f 

# 사용하지 않는 모든 이미지 삭제 
docker image prune -a -f 

# 사용하지 않는 모든 네트워크 삭제 
docker network prune -f 

# 사용하지 않는 모든 볼륨 삭제 
docker volume prune -f 

# 전체 시스템 정리 
docker system prune -a -f --volumes
```

