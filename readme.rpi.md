## Setup environment 
ssh inside the RPi.

### Install git, node, npm, docker docker-compose in RPi
```console
sudo apt install git

sudo apt install -y nodejs npm

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
cd /home/pi
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
sudo chmod -R 777 /home/pi/shirka/shirka.domotics
```

### Run shirka.domotics
```console
cd shirka.domotics
sudo docker-compose up --build -d
```

### Run tests
In file `run_tests.sh` set variable `REVERSE_PROXY_BASE_URL` to 'http://[RPI_IP]', e.g, `REVERSE_PROXY_BASE_URL=http://192.168.1.200`.
Then go ahead and run:
```console 
sudo chmod +x run_tests.sh
./run_tests.sh
```

### Access nodered and grafana
- Open browser in host machine on `http://[RPi_IP]:8080` to access nodered.
- Open browser in host machine on `http://[RPi_IP]:9090` to access grafana


### Run docker-compose always on boot
- Install the service
```
cd install
sudo chmod +x ./install_service.rpi.sh
sudo ./install_service.rpi.sh
```
check it
```
sudo systemctl status shirka_domotics.service
sudo journalctl 
```

- Now restart the RPi
And make sure `shirka_domotics` wakes up automatically.
```
sudo reboot now
````

Then when back inside
````
sudo systemctl status shirka_domotics.service
```
Make sure it's `active (running)` (in green). `Ctl+c` to go back to terminal

- Run tests
```
cd /home/shirka/shirka.domotics
./run_tests.sh
```

Expected output is:
```
.....
Test Run Successful.
Total tests: 6
     Passed: 6
......
```
