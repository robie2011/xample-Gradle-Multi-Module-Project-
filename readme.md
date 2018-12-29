# Example: Gradle Mutli Module Project
This repository contains an example of gradle multi module project.

Following instructions were used to generate this repository

  * https://www.petrikainulainen.net/programming/gradle/getting-started-with-gradle-creating-a-multi-project-build/
  * https://www.petrikainulainen.net/programming/gradle/getting-started-with-gradle-our-first-java-project/
  * https://docs.gradle.org/current/userguide/tutorial_java_projects.html#sec:examples


## build.gradle
Main build file. Contains top level definition.

Apply configurations for all subprojects:

```gradle
subprojects {
    apply plugin: 'java'

    repositories {
        mavenCentral()
    }
}
```

apply project specific configuration (can also be done within `project/build.gradle` file)

```gradle
project(':core') {
	//Add core specific configuration here
}
```

## settings.gradle
Defines which subprojects/module should be included in the build

## Module Dependency Example
Module `app` depends on `core` module. Dependency and other project specific configurations are is defined in `/app/build.gradle`:

```gradle
apply plugin: 'application'

dependencies {
    compile project(':core')
}

mainClassName = 'Starter'
```

## create jar
To create jar, we add to main `build.gradle`

```gradle
subprojects {
    // ...
    jar {
        manifest.attributes provider: 'gradle'
    }
}
```

And add jar startup information to `/project/build.gradle`

```gradle
jar {
    manifest {
        attributes 'Main-Class': 'Starter'
    }
}
```

## gradle tasks
This examples requires installation of `gradle`. It is also possible to use the gradle wrapper so there is no need to install `gradle` on each build system.

| cmd               | desc                                        |
|-------------------|---------------------------------------------|
| `gradle run`      | run example application                     |
| `gradle projects` | show projects                               |
| `gradle clean`    | clean build                                 |
| `gradle assemble` | build olny                                  |
| `gradle distZip`  | build, create start scripts and pack to zip |

