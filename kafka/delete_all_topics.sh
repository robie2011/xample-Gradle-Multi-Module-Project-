#!/bin/bash
ZK_IP=zookeeper

TOPICS=$(kafka-topics --zookeeper $ZK_IP:2181 --list | grep -v "__*")

for T in $TOPICS
do
  if [ "$T" != "__consumer_offsets" ]; then
    kafka-topics --zookeeper $ZK_IP:2181 --delete --topic $T
  fi
done