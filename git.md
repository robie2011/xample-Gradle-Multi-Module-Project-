# Git

## Copy subdirectory from github
```bash
npm i -g dl-repo-dir

PROJECT=/path/to/newproject
repo download robie2011/Dev-Examples 'docker/' $PROJECT
rm $PROJECT/readme.md
```

## Aliases

Add-Commit 

    git config --global alias.add-commit '!git add -A && git commit'
    # Example: git add-commit -m 'My commit message'

## Empty Repository

    git clone git@github.com:ACCOUNT/REPO.wiki.git
    cd REPO.wiki
    git checkout --orphan empty
    git rm --cached -r .
    git commit --allow-empty -m 'wiki deleted'
    git push origin empty:master --force

https://stackoverflow.com/questions/9763223/delete-github-repos-wiki
