
- [x] redis cluster 구성
	- [x] 구성 방식 정하기 (마스터3 or 레플도 만들건지)
	- [x] docker-compose 수정하기
	- [x] 연결해서 서버 켜보기 - main.go에 추가하기
- [ ] 문서화
	- [x] 초기세팅?방법
	- [x] 프로젝트에 어떤거 docker로 어떻게 구성되었는지
	- [x] dedicated server deploy
	- [ ] 
- [ ] 작업 내용 맞추기
	- [x] db이름 맞추기
	- [ ] docker 작업한거 마스터에 합칠건지?
		- [ ] 서버 켤때 docker 쓰고 안쓰고 분기 나누기?
- [ ] db, redis에 데이터 넣고 꺼내쓰고 해보기
	- [ ] mongo
	- [x] redis
- [ ] db redis 프로젝트 안에 넣은거 다시 밖으로 빼기? 용량 보고..
- [ ] 파라미터스토어 인증파일로 인증하기
- [ ] 컨테이너 띄울때 db redis 데이터 저장된 폴더 제외하고 되도록
- [ ] 유니티 데디케이트 서버 컨테이너로 띄우는것 다시 보기
	- [x] 로컬에 테스트 프로젝트 만들어서 띄우기
	- [x] dockerfile 작성, 이미지 만들기
- [ ] docker-compose에 redis 등 latest 로 되어있는것들 버전 픽스 되면 수정하기
	- [ ] dockerfile 각각 작성해서 그 시점의 redis:latest를 이미지화 해서 도커허브나 harbor같은곳에 저장


