# Readme

  * https://docs.confluent.io/current/kafka-mqtt/intro.html
  * https://docs.confluent.io/current/quickstart/index.html


kafka-console:

        docker run -it --net=kafkanet confluentinc/cp-kafka:5.2.0 bash
        kafka-console-consumer --bootstrap-server broker:9092 --topic temperature --from-beginning --property  print.timestamp=true --property print.key=true