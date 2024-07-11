


1. 해당 브랜치로 체크아웃
```bash
git checkout feature/home
```

2.  master rebase

```bash
git rebase master
```

충돌 시 해결
```bash
git add <conflicted-file> git rebase --continue
```

rebase를 취소하고 원래 상태로 되돌리기
```bash
git rebase --abort
```

