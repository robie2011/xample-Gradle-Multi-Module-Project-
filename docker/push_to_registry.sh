#!/bin/bash
source ./vars.sh
echo "pushing image to registry.gitlab.com: $IMAGE"
docker push $IMAGE || echo "Failure. make sure you have onced logged in to remote registry"