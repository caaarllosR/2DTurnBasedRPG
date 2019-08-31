git config --global user.name "caaarllosr"
git config --global user.email carlosrvmelo@gmail.com
git config --global core.editor "atom --wait"


cd D:\Desenvolvimento
mkdir test-gitflow
cd test-gitflow

git init
git remote add origin https://github.com/caaarllosR/test-gitflow.git

echo "# test-gitflow" >> README.md
git add README.md
git commit -m "first commit"

git push -u origin master


git flow init -d

git push -u origin develop

git flow feature start endpoint-api
git flow feature publish endpoint-api

touch endpoint.txt
git add --all
git commit -m "inserindo novo endpoint"
git flow feature publish endpoint-api

git flow feature finish endpoint-api
git push -u origin develop

git flow release start v1.0.0
git flow release publish v1.0.0
git flow release finish v1.0.0

git push origin master
git push origin develop
git push origin --tags

git flow hotfix start v1.0.1
git flow hotfix publish v1.0.1

git push origin master
git push origin develop
git push origin --tags
