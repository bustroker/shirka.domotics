
## Mosquitto
run
```
cd mosquitto
docker-compose up
```

test mosquitto:
install client
```
apt-get install mosquitto-clients
```

subscribe the console to some topic 
```
mosquitto_sub -h localhost -p 1883 -t "queue/messages"
```

- publish a message to same topic
```
mosquitto_pub -h localhost -p 1883 -t "queue/messages" -m "Hello world"
```

### Data
Data folders are:
- /mosquitto/config
- /mosquitto/data
- /mosquitto/log

They are bound respectively to config, data and log folders here

