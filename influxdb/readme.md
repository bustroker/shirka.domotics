
## InfluxDb
https://hub.docker.com/_/influxdb/?tab=description

Listen on port 8086.
To test
```console
'localhost:8086/health'
```

create db
```
curl -i -XPOST http://localhost:8086/query --data-urlencode "q=CREATE DATABASE bustrokerDb"
```

write
```
curl -i -XPOST 'http://localhost:8086/write?db=bustrokerDb' \
--data-binary 'cpu_load_short,host=server01,region=us-west value=0.64 1434055562000000000'
```

query
```
curl -G 'http://localhost:8086/query?pretty=true' --data-urlencode "db=bustrokerDb" --data-urlencode "q=SELECT \"value\" FROM \"cpu_load_short\" WHERE \"region\"='us-west'"
```
