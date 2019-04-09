# InfluxDb

## Admin

### show fields and key structure

    SHOW FIELD KEYS [ON <database_name>] [FROM <measurement_name>]
    
    
### authentification

https://docs.influxdata.com/influxdb/v1.7/administration/authentication_and_authorization/#grant-administrative-privileges-to-an-existing-user

    CREATE USER todd WITH PASSWORD 'influxdb41yf3'
    grant ALL on dbname to username
