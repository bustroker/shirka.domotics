## install docker and docker-compose in rpi
```
curl -sSL https://get.docker.com | sh
sudo usermod -aG docker pi

sudo apt-get install -y libffi-dev libssl-dev
sudo apt-get install -y python3 python3-pip
sudo apt-get remove python-configparser

sudo pip3 -v install docker-compose
```

## run shirka.domotics
### Download shirka.domotics from github
Create `shirka` folder, download `shirka.domotics` and provide permissions
```
mkdir shirka
cd shirka
sudo git clone https://github.com/bustroker/shirka.domotics.git
sudo chmod -R 777 shirka.domotics
```

### run shirka.domotics
```
cd shirka.domotics
docker-compose up --build -d
```

### run tests


### access nodered and grafana
Open browser `[rpi-IP]:1880`
Open broser `[rpi-IP]:3000`