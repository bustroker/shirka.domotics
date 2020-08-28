## General idea
We want to deploy the domotics system described in `rpi3_iot_server.pdf` with docker-compose.

## Run in vagrant VM
Vagrant VM is `dev` environment.
**To run in RPi see readme.rpi.md**

### Download repo, run Vagrant VM and ssh inside VM
```
git clone https://github.com/bustroker/shirka.domotics.git
cd shirka.domotics
vagrant up
vagrant ssh
cd ../../vagrant
ls
```
`ls` should display all the content in shirka.domotics. This will be **root-folder**.

**ALL PORTS AND ENDPOINTS ARE REFERING TO VAGRANT VM's, UNLESS SPECIFIED OTHERWISE**

### Run
Build and run all the components with docker-compose
```
cd <root-folder>
docker-compose up --build
```

Nodered is in `localhost:1880`. Open a browser in the host machine (outside VM) in `localhost:1880` to access nodered (the port 1880 from vagrant VM is mapped to port 1880 in host machine.).

Mosquitto is listening in localhost:1883, **both** in the host machine and in the VM (See mosquitto/readme.md for details.)

InfluxDb is listening http on localhost:8086,  **both** in the host machine and in the VM. It exposes its own /health endpoint (See influxdb/readme.md for details.)

### Run tests
The project Shirka.Domotics.Test tests all the /health endpoints exposed by nodered and reports results.
The tests are run in a docker container either in the VM or in the RPi. Needs to be run in host's network to be able to access services' endpoints.
```console 
cd <root-folder>/Shirka.Domotics.Tests
docker build -t shirka.domotics.tests .
docker run --network host shirka.domotics.tests
```

### Test each health endpoint separately.
There are flows implemented and deployed, to test health of different parts of the system
- nodered
nodered http endpoint `/health/nodered` just responds 200. This is to be used to test whether nodered is up.
```
curl localhost:1880/health/nodered
```

- mosquitto
nodered http endpoint `health/mosquitto` respondes 200 or 500 depending on nodered being able to publish and receive a message to a mosquitto topic, or not.
```
curl localhost:1880/health/mosquitto
```

- InfluxDB
InfluxDB exposes a `/health` endpoint for this purpose.
```
curl localhost:1880/health/influxdb
```
