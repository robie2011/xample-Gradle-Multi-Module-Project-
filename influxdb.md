# InfluxDb

## Admin

### show fields and tags structure

    SHOW FIELD KEYS [ON <database_name>] [FROM <measurement_name>]
    SHOW TAG KEYS [ON <database_name>] [FROM <measurement_name>]


​    
### authentification

https://docs.influxdata.com/influxdb/v1.7/administration/authentication_and_authorization/#grant-administrative-privileges-to-an-existing-user

    CREATE USER todd WITH PASSWORD 'influxdb41yf3'
    grant ALL on dbname to username



## Read Data

Retention Policy Reading matters

```
# data1
select * from kmax

# data1
select * from "example"."[default policyname]"."kmax"

# different data
select * from "example"."short"."kmax"
```



## Writing Data

### Syntax

NO SPACE BETWEEN MULTIPLE FIELDS OR TAGS!

```
insert {MEASUREMENT}[,tag1=tvalue1,tag2=tvalue2] [value1=vvalue1,value2=vvalue2]
```



```
# point without tag
weather temperature=82 1465839830100400200

# 2 fields without timestamp and without tag
INSERT weather temperature=12,humidity=3

insert [MEASUREMENTNAME] [field2=v1,field2=v2]
	
```



2 Tags, 2 Fields

```
INSERT weather,location=europe,village=bern temperature=12,humidity=3
```



Writing with specific retention policy

### Syntax

```
INSERT INTO DATABASE.POLICY LINEPROTOCOL
```



### Example

```
insert into example.short weather temperature=234
```



## Continuous Queries

Works only on realtime data. Inserting data with timestamp in the past has no effect!

CQs operate on realtime data. They use the **local server’s timestamp**, the `GROUP BY time()` interval, and InfluxDB’s preset time boundaries to determine when to execute and what time range to cover in the query.

<https://docs.influxdata.com/influxdb/v1.7/query_language/continuous_queries/>