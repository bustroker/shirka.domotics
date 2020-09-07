## General idea
We want to deploy the domotics system described in http://tinkerman.cat/rpi3_iot_server.pdf with docker-compose.
We want to have an automated development environment and an automated deployment process to production

## Quick up and running in vagrant Virtual Machine 
To run in Raspberry PI see readme.rpi.md

### Download repo, run Vagrant VM and ssh inside VM
```
sudo git clone https://github.com/bustroker/shirka.domotics.git
cd shirka.domotics
vagrant up
vagrant ssh
cd ../../vagrant
ls
```
`ls` should display all the content in shirka.domotics. 

**ALL THE FOLLOWING PORTS AND ENDPOINTS REFER TO VAGRANT VM's, UNLESS SPECIFIED OTHERWISE**

### Create `data` folders
Create `data` folder with folders for each component to keep their persistent data and add initial setup data. This includes:
- for nodered: default health flows.
First make the file executable and then run.
```console
chmod +x initialize_data_folders.sh
./initialize_data_folders.sh
```

### Run
Build and run all the components with docker-compose
```
cd <root-folder>
docker-compose up --build
```

Nodered is in `localhost:1880` and also throug nginx in `localhost:8080`. Open a browser in the host machine (outside VM) in `localhost:1880` to access nodered (the ports 8080 and 1880 from vagrant VM are mapped to ports 8080 and 1880 in host machine.).

Mosquitto is listening in localhost:1883, both in the host machine and in the VM (See mosquitto/readme.md for details.)

InfluxDb is listening over http on port 8086, but it's not exposed out of docker-compose network, to be able to access the API, ssh into the container. It exposes its own /health endpoint (See influxdb/readme.md for details.)

### Run tests
The project Shirka.Domotics.Test tests all the /health endpoints exposed by nodered and reports results.
The tests are run in a docker container either in the VM or in the RPi. Needs to be run in host's network to be able to access services' endpoints.
```console 
./run_tests.sh
```

### Test each health endpoint separately.
There are flows implemented and deployed, to test health of different parts of the system
- nodered
nodered http endpoint `/health/nodered` just responds 200. This is to be used to test whether nodered is up.
```console
curl localhost:1880/health/nodered # direct access
curl localhost:8080/health/nodered # access through nginx
```

- mosquitto
nodered http endpoint `health/mosquitto` respondes 200 or 500 depending on nodered being able to publish and receive a message to a mosquitto topic, or not.
```console
curl localhost:1880/health/mosquitto
```

- InfluxDB
nodered httpendpoint `/health/influxdb` endpoint responds 200 or 500 based on whether it can access influxdb health endpoint
```
curl localhost:1880/health/influxdb
```

### Run docker-compose always boot
Looks like systemd is the way to go.
https://gist.github.com/Luzifer/7c54c8b0b61da450d10258f0abd3c917
https://selfhostedhome.com/start-docker-compose-using-systemd-on-debian/
https://techoverflow.net/2018/12/15/a-systemd-service-template-for-docker-compose/