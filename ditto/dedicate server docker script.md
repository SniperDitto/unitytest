

```sh
docker build -t dedicated-server .
docker run -d --name dedicated-server -p 7777:7777 dedicated-server

docker build --platform linux/arm64 -t dedicated-server .
```

https://stackoverflow.com/questions/71040681/qemu-x86-64-could-not-open-lib64-ld-linux-x86-64-so-2-no-such-file-or-direc
M1 이슈 관련 링크



windows

```sh
docker run -p 8888:7777/udp -v ~/docker_test:/usr/local/docker_test/ -dit ubuntu-netstat-vim /usr/local/docker_test/dedicated_server_deploy.sh

```


```dockerfile
FROM ubuntu 

RUN apt-get update 

RUN apt-get install vim -y 

RUN apt-get install net-tools -y
```