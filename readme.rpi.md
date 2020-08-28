## install docker and docker-compose in rpi
```console
curl -sSL https://get.docker.com | sh
sudo usermod -aG docker pi

sudo apt-get install -y libffi-dev libssl-dev
sudo apt-get install -y python3 python3-pip
sudo apt-get remove python-configparser

sudo pip3 -v install docker-compose
```

## run shirka.domotics in RPi
### Download shirka.domotics from github
First ssh inside rpi and `cd` into /home, create `shirka` folder, download `shirka.domotics` and provide permissions
```console
cd /home
mkdir shirka
cd shirka
sudo git clone https://github.com/bustroker/shirka.domotics.git
sudo chmod -R 777 shirka.domotics
```

### run shirka.domotics
```console
cd shirka.domotics
docker-compose up --build -d
```

### run tests

```console 
cd shirka.domotics/Shirka.Domotics.Tests
docker build -t shirka.domotics.tests .
docker run --network host shirka.domotics.tests
```

### access nodered and grafana
- Open browser `[rpi-IP]:1880`
- Open browser `[rpi-IP]:3000`