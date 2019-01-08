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