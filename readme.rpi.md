## Setup environment 
ssh inside the RPi.

### Install git docker and docker-compose in RPi
```console
sudo apt install git
sudo curl -sSL https://get.docker.com | sh
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
sudo mkdir shirka
cd shirka
sudo git clone https://github.com/bustroker/shirka.domotics.git
```

### Create `data` folders
Create `data` folder with folders for each component to keep their persistent data and add initial setup data. This includes:
- for nodered: default health flows.
First make the file executable and then run.
```console
cd shirka.domotics
sudo chmod +x initialize_data_folders.sh
sudo ./initialize_data_folders.sh
```

### Give permisions over all the folders and files
```
sudo chmod -R 777 /home/shirka/shirka.domotics
```

### Run shirka.domotics
```console
cd shirka.domotics
sudo docker-compose up --build -d
```

### Run tests
The raspberry IP needs to be passed in `REVERSE_PROXY_BASE_URL`
```console 
cd Shirka.Domotics.Tests 

docker build -t tests . && \
docker run --network host \
            -e REVERSE_PROXY_BASE_URL=http://192.168.1.102 \
            -e REVERSE_PROXY_NODE_PORT=8080 \
            -e REVERSE_PROXY_GRAFANA_PORT=9090 \
            -e DIRECT_NODERED_PORT=1880 \
            -e DIRECT_GRAFANA_PORT=3000 tests
```

### Access nodered and grafana
- Open browser in host machine on `http://[RPi-IP]:8080`.
- Open browser in host machine on `http://[RPi-IP]:9090`