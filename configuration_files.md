# Configuration Files

This document describes how to make configuration files configurable outside of distrbuted JAR-Package

## Intro

Configuration files are placed in `src/main/resources/` folder and during 
generation of distribution package (assemble, create jar, pack to zip/tar) automatically included in module jar-file.

Configuration files to be found by applications must (usually) exists 
in classpaths JARs or Directories (see java classpath arguments).

On generation of zip-file for distribution task by gradle, start scripts (linux/windows)
for main application are created with required JARs in classpath.

__Example Start-Script (excerpt)__

```bash
# ...
CLASSPATH=$APP_HOME/lib/opcua-client-0.1-SNAPSHOT.jar:$APP_HOME/lib/opc-ua-stack-1.3.346-197-javadoc.jar:$APP_HOME/lib/opc-ua-stack-1.3.346-SNAPSHOT.jar:$APP_HOME/lib/dataio-0.1-SNAPSHOT.jar:$APP_HOME/lib/log4j-slf4j-impl-2.11.1.jar:$APP_HOME/lib/kotlin-stdlib-jdk8-1.3.11.jar:$APP_HOME/lib/bcpkix-jdk15on-1.60.jar:$APP_HOME/lib/bcprov-jdk15on-1.60.jar:$APP_HOME/lib/jackson-module-kotlin-2.9.8.jar:$APP_HOME/lib/jackson-dataformat-properties-2.8.8.jar:$APP_HOME/lib/kafka-clients-2.0.0.jar:$APP_HOME/lib/slf4j-api-1.7.25.jar:$APP_HOME/lib/log4j-core-2.11.1.jar:$APP_HOME/lib/log4j-api-2.11.1.jar:$APP_HOME/lib/kotlin-stdlib-jdk7-1.3.11.jar:$APP_HOME/lib/kotlin-reflect-1.3.10.jar:$APP_HOME/lib/kotlin-stdlib-1.3.11.jar:$APP_HOME/lib/jackson-databind-2.9.8.jar:$APP_HOME/lib/jackson-annotations-2.9.0.jar:$APP_HOME/lib/jackson-core-2.9.8.jar:$APP_HOME/lib/kotlin-stdlib-common-1.3.11.jar:$APP_HOME/lib/annotations-13.0.jar:$APP_HOME/lib/lz4-java-1.4.1.jar:$APP_HOME/lib/snappy-java-1.1.7.1.jar
# ...
eval set -- $DEFAULT_JVM_OPTS $JAVA_OPTS $OPC_CLIENT_APPLICATION_OPTS -classpath "\"$CLASSPATH\"" ch.rajakone.opcuaclient.OpcClientApplication "$APP_ARGS"
```

## Configuration
To make our application configurable outside of jar-package we have to do these configurations

1. Exclude our configuration files from JAR-Package

```groovy
jar {
    manifest {
        attributes 'Main-Class': 'ch.rajakone.opcuaclient.OpcClientApplication'
    }

    exclude '*.properties'
}
```

2. Put configurable files in folder `main/dist/lib/conf`

3. Modify gradle start scripts classpath

```groovy
startScripts {
    classpath += files('src/dist/lib/conf')
}
```


## Links / Sources
  * https://stackoverflow.com/questions/10518603/adding-classpath-entries-using-gradles-application-plugin
