최신 Image pull

db setting
```json
PJA
PJA_USER
PJA_LOG
PJA_CMS
```

mongodb 컨테이너 안의 쉘에서 다음 내용 실행
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


```js
db.createUser({user:"pjauser",pwd:"coconefk0801!",roles:["userAdminAnyDatabase","dbAdminAnyDatabase","readWriteAnyDatabase"]})
```