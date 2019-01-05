# Example: Gradle Mutli Module Project
This repository contains an example of gradle multi module project.

Following instructions were used to generate this repository

  * https://www.petrikainulainen.net/programming/gradle/getting-started-with-gradle-creating-a-multi-project-build/
  * https://www.petrikainulainen.net/programming/gradle/getting-started-with-gradle-our-first-java-project/
  * https://docs.gradle.org/current/userguide/tutorial_java_projects.html#sec:examples


## Directory Structure
First, create your directory structure.

Example:

	mkdir multiproject2
	cd multiproject2
	mkdir -p {module-a,module-b}/src/main/{java,kotlin,resources}
	echo "include 'app'">>settings.gradle
	echo "include 'core'">>settings.gradle
	touch build.gradle
	

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


## Adding kotlin

https://kotlinlang.org/docs/reference/using-gradle.html

Adding to main `build.gradle`
```gradle
buildscript {
    ext.kotlin_version = '1.3.11'

    repositories {
        mavenCentral()
    }

    dependencies {
        classpath "org.jetbrains.kotlin:kotlin-gradle-plugin:$kotlin_version"
    }
}

subprojects {
    // ...
    apply plugin: 'kotlin'
}
```

If you want a call a Kotlin Class for main function procedure than you can create something like this (`@JvmStatic` required)
```kotlin
object Starter {
    
    @JvmStatic
    fun main(args: Array<String>) {
        println("hello")
    }
}
```

## Working with InteliJ
Use import function of InteliJ with Gradle Option.

## Choose Main-Class by passing gradle argument
Main class for execution can be choosen by passing arguments to gradle.

The following code extends the main build.gradle file with a task called `execute`

```gradle
task execute(type:JavaExec) {
    // https://discuss.gradle.org/t/passing-gradle-project-properties-via-command-line-to-gradlerunner/19280
    main = findProperty("mainClass")
    
    // getting dynamically all runtimeClasspath
    // https://discuss.gradle.org/t/how-to-aggregate-subproject-jars-distributions-in-a-root-project-with-base-plugin-only/9798
    classpath = files(subprojects.collect { it. sourceSets.main.runtimeClasspath })
}
```

Note: With InteliJ it wasn't possible to build the project because `mainClass` wasn't defined (this variable should be created only if we call the task). Workaround: using findProperty() method

Now we can call our desired Main-Class like in this example

	gradle -PmainClass=package.MainClassName execute 
