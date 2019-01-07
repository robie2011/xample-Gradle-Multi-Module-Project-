# Log4j2 Configuration

I was not able to use YML-Configuration file. 
Therefore properties-File was used as workaround.

```properties
status = error
name = PropertiesConfig

filters = threshold
filter.threshold.type = ThresholdFilter
filter.threshold.level = debug

appenders = console
appender.console.type = Console
appender.console.name = STDOUT
appender.console.layout.type = PatternLayout
appender.console.layout.pattern = %d{HH:mm:ss} %-5p %C:%L - %m%n


rootLogger.level = info
rootLogger.appenderRefs = stdout
rootLogger.appenderRef.stdout.ref = STDOUT

logger.rolling.name = ch.rajakone.opcuaclient
logger.rolling.level = debug
logger.rolling.appenderRefs = STDOUT

# https://logging.apache.org/log4j/2.x/manual/configuration.html#Properties
```
