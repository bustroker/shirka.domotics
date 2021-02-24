## General idea
We want to deploy the domotics system described in http://tinkerman.cat/rpi3_iot_server.pdf with docker-compose.
We want to have an automated development environment and an automated deployment process to production

## Quick up and running in vagrant Virtual Machine 
To run in Raspberry PI see readme.rpi.md

### Create `data` folders
Create `data` folder with subfolders for each component to keep their persistent data, and add initial setup data. This includes:
- for nodered: default health flows.
- for grafana: nothing yet

First, make the file executable and then run.
```console
cd shirka.domotics
chmod +x initialize_data_folders.sh
./initialize_data_folders.sh
sudo chmod -R 777 /shirka.domotics.data
```

### Run manually
Build and run all the components with docker-compose
```console
cd shirka.domotics
docker-compose -f docker-compose.vagrant.yaml up -d
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
```console
curl localhost:1880/health/influxdb
```

### Run docker-compose always on boot
Looks like systemd is the way to go.
https://gist.github.com/Luzifer/7c54c8b0b61da450d10258f0abd3c917
https://selfhostedhome.com/start-docker-compose-using-systemd-on-debian/
https://techoverflow.net/2018/12/15/a-systemd-service-template-for-docker-compose/

- Install the service
```console
sudo ./install/install_service.vagrant.sh
```

- Now restart the VM 
And make sure `shirka_domotics` wakes up automatically.
```console
exit
vagrant halt
vagrant up
vagrant ssh
sudo systemctl status shirka_domotics.service
```
Make sure it's `active (running)` (in green). `Ctl+c` to go back to terminal

- Run tests
```console
cd /vagrant
./run_tests.sh
```

Expected output is:
```console
.....
Test Run Successful.
Total tests: 6
     Passed: 6
......
```

