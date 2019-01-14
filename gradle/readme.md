# Kotlin / Gradle Examples
This projects contains example gradle / kotlin configurations for my personal use.

## Configs

### FatJar
Putting all required libs into one Jar

```groovy
jar {

    manifest {
        attributes 'Main-Class': 'SparkStreamStarter'
    }

    // https://stackoverflow.com/questions/44197521/gradle-project-java-lang-noclassdeffounderror-kotlin-jvm-internal-intrinsics
    from { configurations.compile.collect { it.isDirectory() ? it : zipTree(it) } }

    // Whether the zip can contain more than 65535 files and/or support files greater than 4GB in size.
    // see https://docs.gradle.org/current/dsl/org.gradle.api.tasks.bundling.Jar.html#org.gradle.api.tasks.bundling.Jar:zip64
    zip64 true
}
```

### Shaodw Jar
The example above didn't worked all the time. Workaround: use [shaddow pluging](https://imperceptiblethoughts.com/shadow/getting-started/#default-java-groovy-tasks).

```groovy
buildscript {
    repositories {
        jcenter()
    }
    dependencies {
        classpath 'com.github.jengelman.gradle.plugins:shadow:4.0.3'
    }
}

apply plugin: 'com.github.johnrengelman.shadow'
apply plugin: 'java'

// optional: for big file size
shadowJar {
    zip64 true
}
```

Execute gradle task `gradle clean && gradle :spark-streams:shadowJar`

## Additional Links
  * http://www.vogella.com/tutorials/Gradle/article.html
  * https://docs.gradle.org/current/userguide/application_plugin.html
