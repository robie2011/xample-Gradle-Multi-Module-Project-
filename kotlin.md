# Kotlin

## Basics

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


### Links
  * https://www.baeldung.com/kotlin-lambda-expressions