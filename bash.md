# bash

## Basics

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