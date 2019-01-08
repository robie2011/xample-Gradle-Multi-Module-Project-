#!/bin/bash
source ./vars.sh
echo "create docker container of: $IMAGE"

docker run --net=$NETWORK --rm -it -w$WORKDIR $IMAGE