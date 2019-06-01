# Kotlin

## Basics

### Private Constructor
```kotlin
class Foo private constructor(val someData: Data) {
    companion object {
        operator fun invoke(): Foo {
            // do stuff

            return Foo(someData)
        }
    }
}
```

### Calling super-constructor
```kotlin
class AvgActivePowerStatsSerde : WrapperSerde<AvgActivePowerStats> {
    constructor() : super(
            JsonSerializer<AvgActivePowerStats>(),
            JsonDeserializer<AvgActivePowerStats>() ) {
        configure(mapOf("serializedClass" to AvgActivePowerStats::class.java), false)
    }
}
```

[see also](https://stackoverflow.com/questions/44481268/call-super-class-constructor-in-kotlin-super-is-not-an-expression)

### Referencing to methods
```kotlin
Classname::methodname
(1 ..10).forEach(::println))
```

### Using reserved Keywords
```kotlin
# with is a reserved word
val `with` = 23
println (`with`)

```

## Lambda Expression

```kotlin
val square = { number: Int -> number * number }

// if type inference doesn't work
val that : Int -> Int = { three -> three }
```

### Return

* Example 1*

```kotlin
val calculateGrade = fun(grade: Int): String {
    if (grade < 0 || grade > 100) {
        return "Error"
    } else if (grade < 40) {
        return "Fail"
    } else if (grade < 70) {
        return "Pass"
    }
 
    return "Distinction"
}
```

*Example 2*
```kotlin
val calculateGrade = { grade : Int ->
    when(grade) {
        in 0..40 -> "Fail"
        in 41..70 -> "Pass"
        in 71..100 -> "Distinction"
        else -> false
    }
}
```

### Taking as argument and working with
```kotlin
fun invokeLambda(lambda: (Double) -> Boolean) : Boolean {
    return lambda(4.329)
}
```

### Functional Interface Lambda Implementation

```kotlin
var myRunnable1 = object: Runnable {
    override fun run() {
        TODO("not implemented")
    }
}

var myRunnable2 = Runnable {
    TODO("not implemented")
}
```

## DateTime
### Basics
There are (https://www.oracle.com/technetwork/articles/java/jf14-date-time-2125367.html)
  * LocaleTime
  * LocaleDate
  * LocaleDateTime
  * ZonedDateTime
  
### Parsing
```kotlin
// old style
DateTimeFormatter f = DateTimeFormat.forPattern("yyyy-MM-dd HH:mm:ss");
DateTime dateTime = f.parseDateTime("2012-01-10 23:13:26");


// With LocalDateTime with default pattern matching?
LocalDateTime dateTime = f.parseLocalDateTime("2012-01-10 23:13:26");

// with Pattern Matching for LocalDateTime
DateTimeFormatter f = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");
LocalDateTime dateTime = LocalDateTime.from(f.parse("2012-01-10 23:13:26"));


// only locale date
DateTimeFormatter f = DateTimeFormatter.ofPattern("MMMM dd, yyyy");
LocalDate localDate = LocalDate.from(f.parse("January 13, 2012"));
```
See https://stackoverflow.com/a/8854858/2248405

  
### Calculate execution duration and show it
```kotlin
// required lib: compile group: 'org.apache.commons', name: 'commons-lang3', version: '3.8.1'
val executionTimeMs = measureTimeMillis {
    exporter.export(numericIds, dateFrom, dateTo, exportPath, "nest_")
}


println("Execution Time: " + DurationFormatUtils.formatDuration(executionTimeMs, "HH:mm:ss,SSS"))
```

### Links
  * https://www.baeldung.com/kotlin-lambda-expressions
  * [Higher-Order Functions and Lambda](https://kotlinlang.org/docs/reference/lambdas.html)
  * [Mastering Kotlin standard functions: run, with, let, also and apply](https://medium.com/@elye.project/mastering-kotlin-standard-functions-run-with-let-also-and-apply-9cd334b0ef84)
