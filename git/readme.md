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
