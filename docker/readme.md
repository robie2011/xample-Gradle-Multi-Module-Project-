# Docker

## Copy templates

```bash
npm i -g dl-repo-dir

PROJECT=/path/to/newproject
repo download robie2011/Dev-Examples 'docker/' $PROJECT
rm $PROJECT/readme.md
```

## Working with different Buildsources
 cd /build/source
 docker build -f docker/Dockerfile -t your-image-name .

## Images
  * JRE: https://hub.docker.com/_/microsoft-java-jre

## Container Initialization

https://success.docker.com/article/use-a-script-to-initialize-stateful-container-data
use entrypoint script in aproriate shell language (!)
```sh
#!/bin/sh
set -e

if [ "$1" = 'postgres' ]; then
    chown -R postgres "$PGDATA"

    if [ -z "$(ls -A "$PGDATA")" ]; then
        gosu postgres initdb
    fi

    exec gosu postgres "$@"
fi

# this forwards all cmds and arguments to exec command
exec "$@"
``


## Links
  * [Dockerfile Reference](https://docs.docker.com/engine/reference/builder/)
  * [Searching docker certified images](https://https://hub.docker.com/search?operating_system=linux&source=verified&type=image&architecture=amd64)
