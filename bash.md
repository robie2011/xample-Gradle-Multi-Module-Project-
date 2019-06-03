# bash

## Basics
Command on multiple lines
```bash
./configure --without-http_autoindex_module --without-http_ssi_module \
           --without-http_userid_module --without-http_auth_basic_module \
           --without-http_geo_module --without-http_fastcgi_module \
           --without-http_empty_gif_module  --with-openssl=/lib64
```

## Stop on error
`set -e

### Moving

```bash
# Moving file to folder
mv filename.zip /tmp/
mv filename.zip /tmp

# renaming folder (moving)
# ONLY WORKS, IF NEW FOLDER NOT EXISTS! OTHERWIESE oldFoldername will be a subdir of newFoldername
mv /path/bkp1/oldFoldername /path/prod/newFoldername
mv oldFoldername newFoldername

# moving content of old folder to new folder
mv /path/bkp1/* /path/prod/newFoldername
mv oldFoldername/* newFoldername

# moving folder f1 to parent directory /tmp/test001 (f1 will be subdir)
mv f1/ /mnt/backups
mv f1 /mnt/backups/
mv /path/original/accounting/ /mnt/backups/

# moving multiple files to folder
mv * /mnt/backups/
```

## Path/Filename Operations
```bash
# get parent directory: /directory
dirname /directory/filename.txt

# get filename only: filename.txt
basename /directory/filename.txt

# get absolute path to file/directory
realpath myfile.txt
/workingdirectory/myfile.txt
```

[Get filename without extension](https://stackoverflow.com/a/965072/2248405)

## Templating
```bash
#!/bin/sh

#define parameters which are passed in.
IMAGE=$1
PACKAGE=$2
INSTALL_PATH=$3

#define the template.
cat  << EOF
#!/bin/bash
cd ..

gradle clean && gradle distTar
cd build/distributions

docker image rm $IMAGE
docker build --no-cache -f ../../docker/Dockerfile -t $IMAGE .

cd -
cd docker
EOF

# execute script and redirect output to file
```



## Archiving

excluding folders

```bash
tar --exclude='./influx' --exclude='./protofluxtt/protofluxtt' -zcvf /tmp/docker_config.tgz .
```



### Archiving and keeping path to directories

```bash
cd /

tar --exclude='/docker_data/influx' \
	--exclude='/docker_data/protofluxtt/protofluxtt' \
	-zcvf /tmp/docker_config.tgz \
	/docker_data/ \
	/etc/letsencrypt/ \
	/var/lib/letsencrypt/
```

