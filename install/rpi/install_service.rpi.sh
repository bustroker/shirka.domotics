#!/bin/bash
cp ./shirka_domotics.rpi.service /etc/systemd/system/shirka_domotics.service
cd /home/shirka/shirka.domotics
chmod +x wakeup.rpi.sh
systemctl enable shirka_domotics.service
systemctl start shirka_domotics.service