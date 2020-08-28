## Setup environment 
ssh inside the RPi.

### Install docker and docker-compose in RPi
```console
curl -sSL https://get.docker.com | sh
sudo usermod -aG docker pi

sudo apt-get install -y libffi-dev libssl-dev
sudo apt-get install -y python3 python3-pip
sudo apt-get remove python-configparser

sudo pip3 -v install docker-compose
```

## Run shirka.domotics in RPi
### Download shirka.domotics from github
First ssh inside rpi and `cd` into /home, create `shirka` folder, download `shirka.domotics` and provide permissions
```console
cd /home
mkdir shirka
cd shirka
sudo git clone https://github.com/bustroker/shirka.domotics.git
sudo chmod -R 777 shirka.domotics
```

### Run shirka.domotics
```console
cd shirka.domotics
docker-compose up --build -d
```

### Smoke tests
To run tests, the ENVIRONMENT_NAME variable needs to be set.
#### Set environment variable
Environment name is **only required for running automatic tests** (for the moment). Supported values are 'ENVIRONMENT_NAME=DEV' and 'ENVIRONMENT_NAME=PRE'. See `EnvironmentConfiguration` class in Shirka.Domotics.Tests.
To set the environment variable, add `ENVIRONMENT_NAME=PRE` to file /etc/environment
```console
sudo echo ENVIRONMENT_NAME=PRE >> /etc/environment
```
**Logout from RPi and login again for the new environment variable to be loaded**

#### Run tests
```console 
cd shirka.domotics/Shirka.Domotics.Tests
docker build -t tests .
docker run --network host -e ENVIRONMENT_NAME=DEV tests
```

### Access nodered and grafana
- Open browser in host machine on `http://[RPi-IP]:8080`.
- Open browser in host machine on `http://[RPi-IP]:9090`