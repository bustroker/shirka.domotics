#!/bin/bash

# clone repo
cd /home/shirka
sudo git clone https://github.com/bustroker/shirka.domotics.git

# create persistent data folders
cd shirka.domotics 
sudo chmod +x initialize_data_folders.rpi.sh 
sudo ./initialize_data_folders.rpi.sh 

# provide permissions over the whole folder
sudo chmod -R 777 /home/shirka

# install systemd service and enable it
cd /home/shirka/shirka.domotics/install/rpi
sudo chmod +x ./install_service.rpi.sh
sudo ./install_service.rpi.sh
