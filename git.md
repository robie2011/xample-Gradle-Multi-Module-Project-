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

## Diff
### File version in two different branches
```bash
git diff mybranch master myfile.cs
```

## Cleaning
 * To remove directories, run `git clean -fd`
 * To remove ignored files, run `git clean -fX`
 * To remove ignored and non-ignored files, run `git clean -fx

## Gitlab.com
Using Deploy Token: https://docs.gitlab.com/ee/user/project/deploy_tokens/

    git clone http://<username>:<deploy_token>@gitlab.example.com/tanuki/awesome_project.git
    docker login registry.example.com -u <username> -p <deploy_token>
