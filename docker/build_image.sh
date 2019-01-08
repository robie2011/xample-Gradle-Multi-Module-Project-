#!/bin/bash
source ./vars.sh
echo "building image: $IMAGE"

cd ..

gradle clean && gradle distTar
cd build/distributions

docker image rm $IMAGE
docker build --no-cache -f ../../docker/Dockerfile -t $IMAGE .

cd -
cd docker
