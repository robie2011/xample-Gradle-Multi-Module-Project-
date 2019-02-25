# MongoDb

## Backup
```bash

REPLICA_SET=Cluster0-shard-0
DBHOST=cluster0-shard-00-00-yvfdm.mongodb.net
USERNAME=dbAdmin
PASSWORD=secret
OUTPUTDIR=/tmp

mongodump --host=$REPLICA_SET/$DBHOST --port 27017 --authenticationDatabase admin --username $USERNAME --password $PASSWORD --ssl -o $OUTPUTDIR
```

## Restore
```bash

REPLICA_SET=Cluster0-shard-0
DBHOST=cluster0-shard-00-00-yvfdm.mongodb.net
USERNAME=dbAdmin
PASSWORD=secret
DATADIR=/tmp
DBNAME=juda

mongorestore --host=$REPLICA_SET/$DBHOST --port 27017 --authenticationDatabase admin --username $USERNAME --password $PASSWORD --ssl --db $DBNAME $DATADIR --drop
```
