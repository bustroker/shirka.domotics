
## InfluxDb
https://hub.docker.com/_/influxdb/?tab=description

Listens on port 8086, but port is not exposed out of docker-compose network. To be able to access the API, ssh into the container.

- Health endpoint
```console
'localhost:8086/health'
```

- Create db
```
curl -i -XPOST http://localhost:8086/query --data-urlencode "q=CREATE DATABASE bustrokerDb"
```

- Write
```
curl -i -XPOST 'http://localhost:8086/write?db=bustrokerDb' \
--data-binary 'cpu_load_short,host=server01,region=us-west value=0.64 1434055562000000000'
```

- Query
```
curl -G 'http://localhost:8086/query?pretty=true' --data-urlencode "db=bustrokerDb" --data-urlencode "q=SELECT \"value\" FROM \"cpu_load_short\" WHERE \"region\"='us-west'"
```

### InfluxDb CLI
- Connect to influxdb container
```
docker exec -it <CONTAINER_NAME> /bin/bash
```

- Run query
```
influx -database <DATABASE_NAME> -execute <QUERY> -format 'json' -pretty
```

Ej:
```
influx -database 'db0' -execute 'select * from tem_amb' -format 'json' -pretty
```