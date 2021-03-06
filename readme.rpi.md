## Setup environment 
Go ahead and ssh inside the RPi.

### Create `shirka` user and delete `pi`
```console
sudo rm /etc/ssh/ssh_host* 
sudo ssh-keygen -A
sudo adduser shirka
sudo adduser shirka sudo
sudo reboot

sudo deluser --remove-home pi
```

### Install git, node, npm, docker docker-compose in RPi
```console
sudo apt install git

sudo apt install -y nodejs npm

sudo curl -sSL https://get.docker.com | sh
sudo usermod -aG docker shirka

sudo apt-get install -y libffi-dev libssl-dev
sudo apt-get install -y python3 python3-pip
sudo apt-get remove python-configparser

sudo pip3 -v install docker-compose
```

## Install shirka_domotics in RPi
### 0. Uninstall `shirka_domotics` if a previous version exists
If `shirka_domotics` has been already installed, first stop the service and disable it, 
```
sudo systemctl stop shirka_domotics.service && \
sudo systemctl disable shirka_domotics.service
```

Then, remove the content of `shirka` folder **WITHOUT REMOVING `shirka.domotics.data` FOLDER**.
Only remove `shirka.domotics.data` to start from absolute scratch and LOSE all database data.
`shirka` folder

To remove shirka **WITH DATA**
```
sudo rm -r /home/shirka/*
```

### Install
The next 4 steps are scripted in `shirka_domotics_installer.sh`. It can just be run, or alternatively the 4 steps can be followed manually as described bellow.
To run it, ssh into the RPi, and from any folder run.

#### Installation
Two options: install from absolute scratch, or keeping previous data.
- Install it from absolute scratch.
```
sudo curl https://raw.githubusercontent.com/bustroker/shirka.domotics/master/1.shirka_domotics_installer_from_scratch.rpi.sh | bash
```

- Install keeping data.
```
sudo curl https://raw.githubusercontent.com/bustroker/shirka.domotics/master/2.shirka_domotics_installer_keep_data.rpi.sh | bash
```


### 1. Download shirka.domotics from github
First ssh inside rpi and `cd` into `/home/shirka`, download `shirka.domotics` and provide permissions
```console
cd /home/shirka && \
sudo git clone https://github.com/bustroker/shirka.domotics.git
```

### 2. Create `data` folders
Create `data` folder with folders for each component to keep their persistent data and add initial setup data. This includes nodered default health flows.
It also, creates a repo in nodered data folder, to version-control nodered flows.

First make the file executable and then run.
```console
cd /home/shirka/shirka.domotics && \
sudo chmod +x initialize_data_folders.rpi.sh && \
sudo ./initialize_data_folders.rpi.sh 
```

### 3. Give permisions over all the folders and files
```console
sudo chmod -R 777 /home/pi/shirka/shirka.domotics
```

### 4. Install shirka_domotics as a systemd service
It will start automatically when boot, and restart if broken any time.
- Install the service
```console
cd /home/shirka/shirka.domotics/install/rpi && \
sudo chmod +x ./install_service.rpi.sh && \
sudo ./install_service.rpi.sh
```

- check it
```console
sudo systemctl status shirka_domotics.service
sudo journalctl -r -u shirka_domotics
```

- Now restart the RPi, and make sure `shirka_domotics` wakes up automatically.
```console
sudo reboot now
```

- Then when back inside the rpi terminal
```console
sudo systemctl status shirka_domotics.service
```

Make sure it's `active (running)` (in green). `Ctl+c` to go back to terminal

### Download nodered flows from existing repo
And reboot
```console
cd /home/shirka/shirka.domotics.data/nodered
sudo rm -r *
git remote add origin <REMOTE_GIT_REPO>
git pull origin master
npm install
sudo reboot now
```

## Run tests
In file `run_tests.sh` set variable `REVERSE_PROXY_BASE_URL` to 'http://[RPI_IP]', e.g, `REVERSE_PROXY_BASE_URL=http://192.168.1.200`.
Then go ahead and run:
```console 
cd /home/shirka/shirka.domotics && \
sudo chmod +x run_tests.sh && \
./run_tests.sh
```

## Access nodered and grafana
Through nginx reverse proxy:
- Open browser in host machine on `http://[RPi_IP]:8080` to access nodered.
- Open browser in host machine on `http://[RPi_IP]:9090` to access grafana

Direcly
- Open browser in host machine on `http://[RPi_IP]:1880` to access nodered.
- Open browser in host machine on `http://[RPi_IP]:3000` to access grafana


### Run shirka.domotics manually
```console
cd shirka.domotics && \
sudo docker-compose up --build -d
```
