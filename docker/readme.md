# Docker
## Add new user to manage docker
https://www.digitalocean.com/community/questions/how-to-fix-docker-got-permission-denied-while-trying-to-connect-to-the-docker-daemon-socket


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
```


## Truncate Logs
```
# finding logs
du -d1 -h /var/lib/docker/containers | sort -h

# truncating 1
truncate -s 0 /var/lib/docker/containers/[ContainerId]/[ContainerId]-json.log

# truncating 2
cat /dev/null > /var/lib/docker/containers/container_id/container_log_name
```
https://medium.freecodecamp.org/how-to-setup-log-rotation-for-a-docker-container-a508093912b2

https://success.docker.com/article/no-space-left-on-device-error

## Setup Log Retention

File: `/etc/docker/daemon.json`

```json
{
  "log-driver": "json-file",
  "log-opts": {
    "max-size": "10m",
    "max-file": "10"
  }
}
```

## Restart Policy
Policies: "no", always, on-failure, unless-stopped

Change:

    docker update --restart always 3715b6eddaf3


## Config
Get IP

    docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' c

## Links
  * [Dockerfile Reference](https://docs.docker.com/engine/reference/builder/)
  * [Searching docker certified images](https://https://hub.docker.com/search?operating_system=linux&source=verified&type=image&architecture=amd64)
